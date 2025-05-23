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

        // === Створення будівель, доріг, інфраструктури ===
        var school = new BuildingBuilder()
            .SetType(BuildingType.School)
            .SetFloors(3)
            .SetCapacity(500)
            .SetArea(4)
            .SetMaintenance(3000)
            .Build();

        var road = new RoadBuilder()
            .SetLanes(2)
            .SetType(RoadType.TransitOnly)
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

        // === Центральний квартал ===
        var centralQuarter = new QuarterComposite("Центральний квартал");
        centralQuarter.AddComponent(school);
        centralQuarter.AddComponent(road);
        centralQuarter.AddComponent(utility);

        // === Житловий квартал ===
        var residentialQuarter = new QuarterComposite("Житловий квартал");
        residentialQuarter.AddComponent(new BuildingBuilder()
            .SetType(BuildingType.Apartment)
            .SetFloors(5)
            .SetCapacity(100)
            .SetArea(6)
            .SetMaintenance(2000)
            .Build());
        residentialQuarter.AddComponent(new RoadBuilder()
            .SetLanes(1)
            .SetLights(false)
            .SetArea(2)
            .SetMaintenanceCost(300)
            .Build());

        // === Промисловий квартал ===
        var industrialQuarter = new QuarterComposite("Промисловий квартал");
        industrialQuarter.AddComponent(new UtilityBuilder()
            .SetType(UtilityType.PowerPlant)
            .SetProductionCapacity(50000)
            .SetArea(10)
            .SetMaintenanceCost(5000)
            .Build());
        industrialQuarter.AddComponent(new RoadBuilder()
            .SetLanes(3)
            .SetLights(true)
            .SetArea(4)
            .SetMaintenanceCost(800)
            .Build());

        // === Райони ===
        var centralDistrict = new DistrictComposite("Центральний район");
        centralDistrict.AddQuarter(centralQuarter);

        var residentialDistrict = new DistrictComposite("Житловий район");
        residentialDistrict.AddQuarter(residentialQuarter);

        var industrialDistrict = new DistrictComposite("Промисловий район");
        industrialDistrict.AddQuarter(industrialQuarter);

        // === Місто ===
        var city = new CityComposite("Симулянськ");
        city.AddDistrict(centralDistrict);
        city.AddDistrict(residentialDistrict);
        city.AddDistrict(industrialDistrict);

        city.Display();
        Console.WriteLine($"\nЗагальна вартість утримання: {city.GetMaintenanceCost()}");
        Console.WriteLine($"Загальна площа: {city.GetTotalArea()}");
    }
}
