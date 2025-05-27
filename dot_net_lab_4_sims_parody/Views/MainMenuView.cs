using Application.Validation;
using Domain.Composite;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;

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

                var cityNames = cities.Select(c => c.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(cityNames);
                var selectedCityName = cityNames[selectedIndex];

                CurrentCityName = selectedCityName;
                _nextView = View.CityControlsMenu;
                Console.WriteLine($"City '{selectedCityName}' is now open.");
            }
        },
        {
            2, () =>
            {
                var cities = CityStorage.Cities;

                if (cities.Count == 0)
                {
                    throw new NotFoundException("City");
                }

                var cityNames = cities.Select(c => c.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(cityNames);
                var selectedCityName = cityNames[selectedIndex];

                CityStorage.RemoveCity(selectedCityName);
                if (CurrentCityName == selectedCityName) CurrentCityName = null;
                Console.WriteLine($"City '{selectedCityName}' deleted.");
                Console.WriteLine("\nPress any button to continue...");
                Console.ReadKey();
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
