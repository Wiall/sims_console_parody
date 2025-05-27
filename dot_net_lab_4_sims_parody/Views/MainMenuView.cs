using Application.Validation;
using Domain.Composite;
using dot_net_lab_4_sims_parody.Presentation;

namespace dot_net_lab_4_sims_parody.Views;

public class MainMenuView : IMenuView
{
    public MainMenuView(string? currentCityName)
    {
        CurrentCityName = currentCityName;
    }

    private static View _nextView = View.MainMenu;

    public static string? CurrentCityName { get; set; }

    public static readonly string[] MenuOptions =
    {
        "Create city",
        "Open city",
        "Delete city",
        "Exit"
    };

    public static readonly Dictionary<int, Action> MenuActions = new Dictionary<int, Action>
    {
        {
            0, () =>
            {
                Console.Write("Enter city name: ");
                var name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return;

                if (CityStorage.GetCity(name) != null)
                {
                    throw new ServiceException("City already exists!");
                }

                var newCity = new CityComposite(name);
                CityStorage.AddCity(newCity);
                CurrentCityName = name;
                Console.WriteLine($"City '{name}' created.");
            }
        },
        {
            1, () =>
            {
                var cities = CityStorage.Cities;

                if (cities.Count == 0)
                {
                    throw new NotFoundException("City");
                }

                Console.WriteLine("Cities:");
                for (var i = 1; i <= cities.Count; i++)
                {
                    Console.WriteLine($"{i}.{cities[i - 1].Name}");
                }
                
                Console.Write("Enter city name to open: ");
                var name = Console.ReadLine();
                if (CityStorage.GetCity(name) != null)
                {
                    CurrentCityName = name;
                    _nextView = View.CityControlsMenu;
                    Console.WriteLine($"City '{name}' is now open.");
                }
                else
                {
                    throw new NotFoundException("City");
                }
            }
        },
        {
            2, () =>
            {
                Console.Write("Enter city name to delete: ");
                var name = Console.ReadLine();
                if (CityStorage.GetCity(name) != null)
                {
                    CityStorage.RemoveCity(name);
                    if (CurrentCityName == name) CurrentCityName = null;
                    Console.WriteLine($"City '{name}' deleted.");
                }
                else
                {
                    throw new NotFoundException("City");
                }
            }
        },
        { 3, () => Environment.Exit(0) }
    };

    public string? GetName()
    {
        return CurrentCityName;
    }

    public View GetNextView()
    {
        return _nextView;
    }

    public DistrictComposite? GetDistrict()
    {
        return null;
    }
    
    public QuarterComposite? GetQuarter()
    {
        return null;
    }
}
