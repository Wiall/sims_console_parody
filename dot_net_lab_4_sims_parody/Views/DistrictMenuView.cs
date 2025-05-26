using Application.Validation;
using Domain.Composite;
using dot_net_lab_4_sims_parody.Presentation;

namespace dot_net_lab_4_sims_parody.Views;

public class DistrictMenuView : IMenuView
{
    private static CityController _cityController;
    
    public static string? CurrentCityName { get; set; }

    public DistrictMenuView(string? currentCityName, DistrictComposite? currentDistrict, CityController cityController)
    {
        CurrentCityName = currentCityName;
        CurrentDistrict = currentDistrict;
        _cityController = cityController;
    }

    private static View _nextView = View.DistrictMenuView;
    
    public static DistrictComposite? CurrentDistrict { get; set; }

    public static readonly string[] MenuOptions =
    {
        "Create Quarter",
        "Edit Quarter",
        "Remove Quarter",
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
            1, () => throw new NotImplementedException()
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

                Console.WriteLine("Quarters:");
                for (var i = 1; i <= quarters.Count; i++)
                {
                    Console.WriteLine($"{i}.{quarters[i - 1].Name}");
                }
                    
                Console.Write("Enter a Quarter name: ");
                var name = Console.ReadLine();
                if (CurrentDistrict.Quarters.Any(d => d.Name == name))
                {
                    CurrentDistrict = null;
                    var quarter = CurrentDistrict.Quarters
                        .FirstOrDefault(d => d.Name == name);
                    CurrentDistrict.RemoveQuarter(quarter);
                    Console.WriteLine($"Quarter '{name}' is now removed.");
                }
                else
                {
                    throw new NotFoundException("Quarter");
                }
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
}
