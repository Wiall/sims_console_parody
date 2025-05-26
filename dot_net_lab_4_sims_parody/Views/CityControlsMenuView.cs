using Application.Dtos;
using Application.Validation;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Views;

public class CityControlsMenuView : IMenuView
{
    // Null warnings on _cityController are ok, sonar is just silly

    private static CityController _cityController;

    private static View _nextView = View.CityControlsMenu;

    public CityControlsMenuView(string? currentCityName, CityController cityController)
    {
        CurrentCityName = currentCityName;
        _cityController = cityController;
    }

    public static string? CurrentCityName { get; set; }

    public static readonly string[] MenuOptions = {
        "Create a District",
        "Create a Quarter",
        "Create a Building",
        "Remove a District",
        "Remove a Quarter",
        "Remove a Building",
        "Show info about city",
        // сюда додавати ще опції
        "Back to main menu"
    };

    public static readonly Dictionary<int, Action> MenuActions = new Dictionary<int, Action>
    {
        {
            0, () =>
            {
                Console.Write("Enter District`s name: ");
                var name = Console.ReadLine();

                var district = _cityController.CreateDistrict(name);
                CityStorage.GetCity(CurrentCityName).AddDistrict(district);
                Console.WriteLine($"District '{district.Name}' created.");
            }
        },
        {
            1, () =>
            {
                Console.Write("Enter a Quarter name: ");
                var name = Console.ReadLine();

                var quarter = _cityController.CreateQuarter(name);

                Console.WriteLine($"Quarter '{quarter.Name}' created.");
            }
        },
        {
            2, () =>
            {
                Console.Write("Enter a Building name: ");
                var name = Console.ReadLine();
                var buildingDto = new BuildingDto { Name = name };

                var building = _cityController.CreateBuilding(buildingDto);

                Console.WriteLine($"Building '{building.Name}' created.");
            }
        },
        {
            3, () =>
            {
                if (string.IsNullOrEmpty(CurrentCityName))
                {
                    throw new ServiceException("No city is currently open.");
                }

                var city = CityStorage.GetCity(CurrentCityName);
                ConsoleUIController.MakeHeader(city.Name);
                city.Display();
                Console.ReadLine();
            }
        },
        {
            4, () =>
            {
                
            }
        },
        {
            5, () =>
            {
                
            }
        },
        {
            6, () =>
            {
                
            }
        },
        {
            7, () =>
            {
                CurrentCityName = null;
                _nextView = View.MainMenu;
            }
        }
    };

    public string? GetCityName()
    {
        return CurrentCityName;
    }

    public View GetNextView()
    {
        return _nextView;
    }
}
