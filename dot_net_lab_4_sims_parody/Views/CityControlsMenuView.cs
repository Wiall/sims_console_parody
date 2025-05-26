using Application.Dtos;
using Application.Validation;
using Domain.Composite;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Views;

public class CityControlsMenuView : IMenuView
{
    // Null warnings on _cityController are ok, sonar is just silly

    private static CityController _cityController;

    private static View _nextView = View.CityControlsMenu;
    
    public static DistrictComposite? CurrentDistrict { get; set; }

    public CityControlsMenuView(string? currentCityName, DistrictComposite? currentDistrict, CityController cityController)
    {
        CurrentDistrict = currentDistrict;
        CurrentCityName = currentCityName;
        _cityController = cityController;
    }

    public static string? CurrentCityName { get; set; }

    public static readonly string[] MenuOptions = {
        "Create a District",
        "Open a District",
        "Remove a District",
        "Show info about city",
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
                CurrentDistrict = district;
                var city = CityStorage.GetCity(CurrentCityName);
                city.AddDistrict(district);

                Console.WriteLine($"District '{district.Name}' created.");
            }
        },
        {
            1, () =>
            {
                var districts = CityStorage.GetCity(CurrentCityName).Districts;

                if (districts.Count == 0)
                {
                    throw new NotFoundException("District");
                }

                Console.WriteLine("Districts:");
                for (var i = 1; i <= districts.Count; i++)
                {
                    Console.WriteLine($"{i}.{districts[i - 1].Name}");
                }
                    
                Console.Write("Enter a District name: ");
                var name = Console.ReadLine();
                if (CityStorage.GetCity(CurrentCityName).Districts.Any(d => d.Name == name))
                {
                    CurrentDistrict = CityStorage.GetCity(CurrentCityName)?.Districts
                        .FirstOrDefault(d => d.Name == name);
                    _nextView = View.DistrictMenuView;
                    Console.WriteLine($"District '{name}' is now open.");
                }
                else
                {
                    throw new NotFoundException("District");
                }
            }
        },
        {
            2, () =>
            {
                var districts = CityStorage.GetCity(CurrentCityName).Districts;

                if (districts.Count == 0)
                {
                    throw new NotFoundException("District");
                }

                Console.WriteLine("Districts:");
                for (var i = 1; i <= districts.Count; i++)
                {
                    Console.WriteLine($"{i}.{districts[i - 1].Name}");
                }
                    
                Console.Write("Enter a District name: ");
                var name = Console.ReadLine();
                if (CityStorage.GetCity(CurrentCityName).Districts.Any(d => d.Name == name))
                {
                    CurrentDistrict = null;
                    var district = CityStorage.GetCity(CurrentCityName)?.Districts
                        .FirstOrDefault(d => d.Name == name);
                    var city = CityStorage.GetCity(CurrentCityName);
                    city.RemoveDistrict(district);
                    Console.WriteLine($"District '{name}' is now removed.");
                }
                else
                {
                    throw new NotFoundException("District");
                }
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
                CurrentCityName = null;
                _nextView = View.MainMenu;
            }
        }
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
        return CurrentDistrict;
    }
}
