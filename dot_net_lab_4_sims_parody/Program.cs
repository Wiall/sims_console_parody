using System.Text;
using dot_net_lab_4_sims_parody.Builders;
using dot_net_lab_4_sims_parody.Composite;
using dot_net_lab_4_sims_parody.Models;

namespace dot_net_lab_4_sims_parody;

internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Hello, repo!");
        
        var school = new BuildingBuilder()
            .SetType(BuildingType.School)
            .SetFloors(3)
            .SetCapacity(500)
            .SetArea(4)
            .SetMaintenance(3000)
            .Build();

        var road = new RoadBuilder()
            .SetLanes(2)
            .SetLights(true)
            .SetArea(2)
            .SetMaintenanceCost(500)
            .Build();

        var utility = new UtilityBuilder()
            .SetType(UtilityType.WaterTower)
            .SetProductionCapacity(20000)
            .SetArea(3)
            .SetMaintenanceCost(1000)
            .Build();

        var centralDistrict = new DistrictComposite("Центральний");
        centralDistrict.Add(school);
        centralDistrict.Add(road);
        centralDistrict.Add(utility);
        var residentialDistrict = new DistrictComposite("Житловий");
        residentialDistrict.Add(new BuildingBuilder()
            .SetType(BuildingType.Apartment)
            .SetFloors(5)
            .SetCapacity(100)
            .SetArea(6)
            .SetMaintenance(2000)
            .Build());
        residentialDistrict.Add(new RoadBuilder()
            .SetLanes(1)
            .SetLights(false)
            .SetArea(2)
            .SetMaintenanceCost(300)
            .Build());

        var industrialDistrict = new DistrictComposite("Промисловий");
        industrialDistrict.Add(new UtilityBuilder()
            .SetType(UtilityType.PowerPlant)
            .SetProductionCapacity(50000)
            .SetArea(10)
            .SetMaintenanceCost(5000)
            .Build());
        industrialDistrict.Add(new RoadBuilder()
            .SetLanes(3)
            .SetLights(true)
            .SetArea(4)
            .SetMaintenanceCost(800)
            .Build());

        var city = new CityComposite("Симулянськ");
        city.Add(centralDistrict);
        city.Add(industrialDistrict);
        city.Display();
        Console.WriteLine($"Загальна вартість утримання: {city.GetMaintenanceCost()}");
        Console.WriteLine($"Загальна площа: {city.GetTotalArea()}");

    }
}