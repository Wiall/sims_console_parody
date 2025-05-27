using Application.Dtos;
using Application.Services;
using Application.Validation;
using Domain.Composite;
using Domain.Models;
using dot_net_lab_4_sims_parody.Presentation;

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
                Console.WriteLine("Road types:");
                for (var i = 1; i <= Enum.GetValues(typeof(RoadType)).Length; i++)
                {
                    Console.WriteLine($"{i}.{Enum.GetValues<RoadType>()[i - 1]}");
                }
                Console.Write("Enter road type: ");
                var type = (RoadType)Enum.Parse(typeof(RoadType), Console.ReadLine(), true);
                
                Console.Write("Enter road name: ");
                var name = Console.ReadLine();
                
                Console.Write("Enter road area: ");
                var area = int.Parse(Console.ReadLine());
                
                Console.Write("Enter road construction cost: ");
                var constructionCost = decimal.Parse(Console.ReadLine());
                
                Console.Write("Enter whether road has lights: ");
                var hasLights = bool.Parse(Console.ReadLine());
                
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
                _cityController.AddRoadToQuarter(road, CurrentQuarter);
                Console.WriteLine("Road created.");
            }
        },
        {
            1, () =>
            {
                Console.WriteLine("Building types:");
                for (var i = 1; i <= Enum.GetValues(typeof(BuildingType)).Length; i++)
                {
                    Console.WriteLine($"{i}.{Enum.GetValues<BuildingType>()[i - 1]}");
                }
                Console.Write("Enter building type: ");
                var type = (BuildingType)Enum.Parse(typeof(BuildingType), Console.ReadLine(), true);
                
                Console.Write("Enter building name: ");
                var name = Console.ReadLine();
                
                Console.Write("Enter building area: ");
                var area = int.Parse(Console.ReadLine());
                
                Console.Write("Enter building people capacity: ");
                var capacity = int.Parse(Console.ReadLine());
                
                Console.Write("Enter whether building has parking: ");
                var hasParking = bool.Parse(Console.ReadLine());

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
                
                _cityController.AddBuildingToQuarter(building, CurrentQuarter);
                Console.WriteLine("Building created.");
            }
        },
        {
            2, () =>
            {
                Console.WriteLine("Utility types:");
                for (var i = 1; i <= Enum.GetValues(typeof(UtilityType)).Length; i++)
                {
                    Console.WriteLine($"{i}.{Enum.GetValues<UtilityType>()[i - 1]}");
                }
                Console.Write("Enter utility type: ");
                var type = (UtilityType)Enum.Parse(typeof(UtilityType), Console.ReadLine(), true);
                
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
                
                _cityController.AddUtilityToQuarter(utility, CurrentQuarter);
                Console.WriteLine("Utility created.");
            }
        },
        {
            3, () =>
            {
                var roads = CurrentQuarter.Roads;

                if (roads.Count == 0)
                {
                    throw new NotFoundException("Road");
                }
                
                Console.WriteLine("Roads:");
                for (var i = 1; i <= roads.Count; i++)
                {
                    Console.WriteLine($"{i}.{roads[i - 1].Name}");
                }
                Console.Write("Enter a Road name: ");
                var name = Console.ReadLine();
                if (CurrentQuarter.Roads.Any(r => r.Name == name))
                {
                    var road = CurrentQuarter.Roads
                        .FirstOrDefault(r => r.Name == name);
                    CurrentQuarter.RemoveRoad(road);
                    Console.WriteLine($"Road '{name}' is now removed.");
                }
                else
                {
                    throw new NotFoundException("Road");
                }
            } 
        },
        {
            4, () =>
            {
                var buildings = CurrentQuarter.Buildings;

                if (buildings.Count == 0)
                {
                    throw new NotFoundException("Building");
                }
                
                Console.WriteLine("Buildings:");
                for (var i = 1; i <= buildings.Count; i++)
                {
                    Console.WriteLine($"{i}.{buildings[i - 1].Name}");
                }
                Console.Write("Enter a Building name: ");
                var name = Console.ReadLine();
                if (CurrentQuarter.Buildings.Any(b => b.Name == name))
                {
                    var building = CurrentQuarter.Buildings
                        .FirstOrDefault(b => b.Name == name);
                    CurrentQuarter.RemoveBuilding(building);
                    Console.WriteLine($"Building '{name}' is now removed.");
                }
                else
                {
                    throw new NotFoundException("Building");
                }
            } 
        },
        {
            5, () =>
            {
                var utilities = CurrentQuarter.Utilities;

                if (utilities.Count == 0)
                {
                    throw new NotFoundException("Utility");
                }
                
                Console.WriteLine("Utilities:");
                for (var i = 1; i <= utilities.Count; i++)
                {
                    Console.WriteLine($"{i}.{utilities[i - 1].Name}");
                }
                Console.Write("Enter a Utility name: ");
                var name = Console.ReadLine();
                if (CurrentQuarter.Utilities.Any(u => u.Name == name))
                {
                    var utility = CurrentQuarter.Utilities
                        .FirstOrDefault(u => u.Name == name);
                    CurrentQuarter.RemoveUtility(utility);
                    Console.WriteLine($"Utility '{name}' is now removed.");
                }
                else
                {
                    throw new NotFoundException("Utility");
                }
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
