using Domain.Interfaces;

namespace Domain.Models;

public class Utility : IInfrastructureComponent
{
    public UtilityType Type { get; set; } // Тип, наприклад: "PowerPlant", "WaterTower"
    public double ProductionCapacity { get; set; } = 0; // Обсяг, який виробляється
    public decimal ConstructionCost { get; set; } // Вартість будівництва
    public decimal MaintenanceCost { get; set; } // Вартість утримання
    public string Name => $"{Type} Utility";
    public int Area { get; set; } = 1;

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"- Infrastructure: {Type}, Capacity: {ProductionCapacity}");
    }

    public decimal GetMaintenanceCost()
    {
        return MaintenanceCost;
    }

    public int GetTotalArea()
    {
        return Area;
    }
}