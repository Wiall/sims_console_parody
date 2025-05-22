namespace dot_net_lab_4_sims_parody.Models;

public class Utility
{
    public string Type { get; set; } = "Utility";            // Тип, наприклад: "PowerPlant", "WaterTower"
    public double ProductionCapacity { get; set; } = 0;      // Обсяг, який виробляється
    public decimal ConstructionCost { get; set; }            // Вартість будівництва
    public decimal MaintenanceCost { get; set; }             // Вартість утримання
    public int Area { get; set; }                            // Площа
}