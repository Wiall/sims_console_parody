using dot_net_lab_4_sims_parody.Builders;

namespace dot_net_lab_4_sims_parody.Models;

public class Utility : ICityComponent
{
    public UtilityType Type { get; set; }            // Тип, наприклад: "PowerPlant", "WaterTower"
    public double ProductionCapacity { get; set; } = 0;      // Обсяг, який виробляється
    public decimal ConstructionCost { get; set; }            // Вартість будівництва
    public decimal MaintenanceCost { get; set; }             // Вартість утримання
    public int Area { get; set; }                            // Площа
    
    public void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $" Infrastructure: {Type}, Capacity: {ProductionCapacity}");
    }

    public decimal GetMaintenanceCost() => MaintenanceCost;
    public int GetTotalArea() => Area;
}