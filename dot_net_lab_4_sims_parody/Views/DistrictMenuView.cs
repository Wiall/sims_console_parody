using Application.Validation;
using Domain.Composite;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Views;

public class DistrictMenuView : IMenuView
{
    private static CityController _cityController;
    
    public static string? CurrentCityName { get; set; }

    public DistrictMenuView(string? currentCityName, DistrictComposite? currentDistrict, QuarterComposite? currentQuarter, CityController? cityController)
    {
        CurrentCityName = currentCityName;
        CurrentDistrict = currentDistrict;
        CurrentQuarter = currentQuarter;
        _cityController = cityController;
    }

    private static View _nextView = View.DistrictMenu;
    
    public static DistrictComposite? CurrentDistrict { get; set; }
    
    public static QuarterComposite? CurrentQuarter { get; set; }


    public static readonly string[] MenuOptions =
    {
        "Create a Quarter",
        "Open a Quarter",
        "Remove a Quarter",
        "Go to city"
    };

    public static readonly Dictionary<int, Action> MenuActions = new Dictionary<int, Action>
    {
        {
            0, () =>
            {
                Console.Write("Enter quarter name: ");
                var name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return;
                
                var quarter = _cityController.CreateQuarter(name);
                var city = CityStorage.GetCity(CurrentCityName);
                city.Districts.FirstOrDefault(CurrentDistrict).AddQuarter(quarter);
                Console.WriteLine($"Quarter '{quarter.Name}' created.");
            }
        },
        {
            1, () =>
            {
                CurrentDistrict = CityStorage.GetCity(CurrentCityName).Districts
                    .FirstOrDefault(d => d.Name == CurrentDistrict.Name);
                var quarters = CurrentDistrict.Quarters;

                if (quarters.Count == 0)
                {
                    throw new NotFoundException("Quarters");
                }

                var quarterNames = quarters.Select(q => q.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(quarterNames);
                var selectedQuarter = quarters[selectedIndex];

                CurrentQuarter = selectedQuarter;
                _nextView = View.QuarterMenu;
                Console.WriteLine($"Quarter '{selectedQuarter.Name}' is now open.");
            }
        },
        {
            2, () =>
            {
                CurrentDistrict = CityStorage.GetCity(CurrentCityName).Districts
                    .FirstOrDefault(d => d.Name == CurrentDistrict.Name);
                var quarters = CurrentDistrict.Quarters;

                if (quarters.Count == 0)
                {
                    throw new NotFoundException("Quarters");
                }

                var quarterNames = quarters.Select(q => q.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(quarterNames);
                var selectedQuarter = quarters[selectedIndex];

                CurrentDistrict.RemoveQuarter(selectedQuarter);
                CurrentDistrict = null;
                Console.WriteLine($"Quarter '{selectedQuarter.Name}' is now removed.");
            }
        },
        {
            3, () =>
            {
                _nextView = View.CityControlsMenu;
                CurrentDistrict = null;
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
    
    public QuarterComposite? GetQuarter()
    {
        return CurrentQuarter;
    }
}
