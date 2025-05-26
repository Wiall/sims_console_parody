using Domain.Interfaces;
using Domain.Models;

namespace Domain.Composite;

public class QuarterComposite(string name) : IInfrastructureComponent
{
    public List<Building> Buildings { get; set; } = new();

    public List<Road> Roads { get; set; } = new();

    public List<Utility> Utilities { get; set; } = new();

    public string Name { get; set; } = name;

    public int Area { get; set; } = 1;


    public decimal GetMaintenanceCost()
    {
        decimal total = 0;
        total += Buildings.Sum(c => c.GetMaintenanceCost());
        total += Roads.Sum(c => c.GetMaintenanceCost());
        total += Utilities.Sum(c => c.GetMaintenanceCost());

        return total;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ Quarter: {Name}");
        foreach (var building in Buildings)
        {
            building.Display(indent + 2);
        }

        foreach (var road in Roads)
        {
            road.Display(indent + 2);
        }

        foreach (var utility in Utilities)
        {
            utility.Display(indent + 2);
        }
    }

    public void AddBuilding(Building building)
    {
        Buildings.Add(building);
    }

    public void AddRoad(Road road)
    {
        Roads.Add(road);
    }

    public void AddUtility(Utility utility)
    {
        Utilities.Add(utility);
    }

    public void RemoveBuilding(Building building)
    {
        Buildings.Remove(building);
    }

    public void RemoveRoad(Road road)
    {
        Roads.Remove(road);
    }

    public void RemoveUtility(Utility utility)
    {
        Utilities.Remove(utility);
    }
}