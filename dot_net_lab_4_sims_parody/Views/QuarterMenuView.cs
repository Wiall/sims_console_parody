using Application.Dtos;
using Application.Services;
using Application.Validation;
using Domain.Composite;
using Domain.Models;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Views;

public class QuarterMenuView : IMenuView
{
    private static CityController _cityController;
    
    public static string? CurrentCityName { get; set; }

    public QuarterMenuView(string? currentCityName, DistrictComposite? currentDistrict, QuarterComposite? currentQuarter, CityController cityController)
    {
        CurrentCityName = currentCityName;
        CurrentDistrict = currentDistrict;
        CurrentQuarter = currentQuarter;
        _cityController = cityController;
    }

    private static View _nextView = View.QuarterMenu;
    
    public static QuarterComposite? CurrentQuarter { get; set; }
    
    public static DistrictComposite? CurrentDistrict { get; set; }

    public static readonly string[] MenuOptions =
    {
        "Create a Road",
        "Create a Building",
        "Create a Utility",
        "Remove a Road",
        "Remove a Building",
        "Remove a Utility",
        "Go to district"
    };

    public static readonly Dictionary<int, Action> MenuActions = new Dictionary<int, Action>
    {
        {
            0, () =>
            {
                var roadTypeOptions = Enum.GetNames(typeof(RoadType));
                int selectedIndex = ConsoleUIController.MenuHold(roadTypeOptions);
                var type = (RoadType)Enum.Parse(typeof(RoadType), roadTypeOptions[selectedIndex]);
                
                Console.Write("Enter road name: ");
                var name = Console.ReadLine();
                
                Console.Write("Enter road area: ");
                var area = int.Parse(Console.ReadLine());
                
                Console.Write("Enter road construction cost: ");
                var constructionCost = decimal.Parse(Console.ReadLine());
                
                Console.Write("Select if road has lights: ");
                var hasLightsOptions = new[] { "True", "False" };
                int selectedLightsIndex = ConsoleUIController.MenuHold(hasLightsOptions);
                bool hasLights = selectedLightsIndex == 0;
                
                Console.Write("Enter road lanes amount: ");
                var lanes = int.Parse(Console.ReadLine());
                
                Console.Write("Enter road maintenance cost: ");
                var maintenanceCost = decimal.Parse(Console.ReadLine());
                var road = _cityController.CreateRoad(new RoadDto
                {
                    Area = area,
                    ConstructionCost = constructionCost,
                    HasLights = hasLights,
                    Lanes = lanes,
                    MaintenanceCost = maintenanceCost,
                    Type = type,
                    Name = name
                });
                var city = CityStorage.GetCity(CurrentCityName);
                var district = city?.Districts.FirstOrDefault(d => d.Name == CurrentDistrict?.Name);
                var quarter = district?.Quarters.FirstOrDefault(q => q.Name == CurrentQuarter?.Name);

                if (quarter == null)
                {
                    Console.WriteLine("Quarter not found.");
                    return;
                }

                _cityController.AddRoadToQuarter(road, quarter);

                CityStorage.SaveAll();
            }
        },
        {
    1, () =>
    {
        var buildingTypeOptions = Enum.GetNames(typeof(BuildingType));
        int selectedIndex = ConsoleUIController.MenuHold(buildingTypeOptions);
        var type = (BuildingType)Enum.Parse(typeof(BuildingType), buildingTypeOptions[selectedIndex]);
        
        Console.Write("Enter building name: ");
        var name = Console.ReadLine();
        
        Console.Write("Enter building area: ");
        var area = int.Parse(Console.ReadLine());
        
        Console.Write("Enter building people capacity: ");
        var capacity = int.Parse(Console.ReadLine());
        
        Console.Write("Select if building has parking: ");
        var hasParkingOptions = new[] { "True", "False" };
        int selectedParkingIndex = ConsoleUIController.MenuHold(hasParkingOptions);
        bool hasParking = selectedParkingIndex == 0;

        Console.Write("Enter building floors amount: ");
        var floors = int.Parse(Console.ReadLine());
        
        Console.Write("Enter building electricity consumption: ");
        var electricityConsumption = double.Parse(Console.ReadLine());
        
        Console.Write("Enter building water consumption: ");
        var waterConsumption = double.Parse(Console.ReadLine());
        
        Console.Write("Enter building income: ");
        var income = decimal.Parse(Console.ReadLine());

        Console.Write("Enter building maintenance cost: ");
        var maintenanceCost = decimal.Parse(Console.ReadLine());

        Console.Write("Enter building price: ");
        var price = decimal.Parse(Console.ReadLine());

        var building = _cityController.CreateBuilding(new BuildingDto
        {
            Area = area,
            Capacity = capacity,
            ElectricityConsumption = electricityConsumption,
            WaterConsumption = waterConsumption,
            HasParking = hasParking,
            Floors = floors,
            Income = income,
            MaintenanceCost = maintenanceCost,
            Name = name,
            Price = price,
            Type = type
        });

        var city = CityStorage.GetCity(CurrentCityName);
        var district = city?.Districts.FirstOrDefault(d => d.Name == CurrentDistrict?.Name);
        var quarter = district?.Quarters.FirstOrDefault(q => q.Name == CurrentQuarter?.Name);

        if (quarter == null)
        {
            Console.WriteLine("Quarter not found.");
            return;
        }

        _cityController.AddBuildingToQuarter(building, quarter);
        Console.WriteLine("Building created.");
        CityStorage.SaveAll();
    }
},
{
    2, () =>
    {
        var utilityTypeOptions = Enum.GetNames(typeof(UtilityType));
        int selectedIndex = ConsoleUIController.MenuHold(utilityTypeOptions);
        var type = (UtilityType)Enum.Parse(typeof(UtilityType), utilityTypeOptions[selectedIndex]);
        
        Console.Write("Enter utility name: ");
        var name = Console.ReadLine();
        
        Console.Write("Enter utility area: ");
        var area = int.Parse(Console.ReadLine());
        
        Console.Write("Enter building production capacity: ");
        var productionCapacity = double.Parse(Console.ReadLine());

        Console.Write("Enter building maintenance cost: ");
        var maintenanceCost = decimal.Parse(Console.ReadLine());

        Console.Write("Enter building construction cost: ");
        var constructionCost = decimal.Parse(Console.ReadLine());

        var utility = _cityController.CreateUtility(new UtilityDto
        {
            Area = area,
            MaintenanceCost = maintenanceCost,
            ConstructionCost = constructionCost,
            ProductionCapacity = productionCapacity,
            Type = type,
            Name = name
        });

        var city = CityStorage.GetCity(CurrentCityName);
        var district = city?.Districts.FirstOrDefault(d => d.Name == CurrentDistrict?.Name);
        var quarter = district?.Quarters.FirstOrDefault(q => q.Name == CurrentQuarter?.Name);

        if (quarter == null)
        {
            Console.WriteLine("Quarter not found.");
            return;
        }

        _cityController.AddUtilityToQuarter(utility, quarter);
        Console.WriteLine("Utility created.");
        CityStorage.SaveAll();
    }
},

        {
            3, () =>
            {
                var roads = CurrentQuarter.Roads;
                if (roads.Count == 0) throw new NotFoundException("Road");

                var roadNames = roads.Select(r => r.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(roadNames);
                var selectedRoad = roads[selectedIndex];

                CurrentQuarter.RemoveRoad(selectedRoad);
                Console.WriteLine($"Road '{selectedRoad.Name}' is now removed.");
            } 
        },
        {
            4, () =>
            {
                var buildings = CurrentQuarter.Buildings;
                if (buildings.Count == 0) throw new NotFoundException("Building");

                var buildingNames = buildings.Select(b => b.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(buildingNames);
                var selectedBuilding = buildings[selectedIndex];

                CurrentQuarter.RemoveBuilding(selectedBuilding);
                Console.WriteLine($"Building '{selectedBuilding.Name}' is now removed.");
                CityStorage.SaveAll();
            } 
        },
        {
            5, () =>
            {
                var utilities = CurrentQuarter.Utilities;
                if (utilities.Count == 0) throw new NotFoundException("Utility");

                var utilityNames = utilities.Select(u => u.Name).ToArray();
                int selectedIndex = ConsoleUIController.MenuHold(utilityNames);
                var selectedUtility = utilities[selectedIndex];

                CurrentQuarter.RemoveUtility(selectedUtility);
                Console.WriteLine($"Utility '{selectedUtility.Name}' is now removed.");
                CityStorage.SaveAll();
            } 
        },
        {
            6, () =>
            {
                _nextView = View.DistrictMenu;
                CurrentQuarter = null;
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
