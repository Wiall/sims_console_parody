using Domain.Models;

namespace Application.Dtos;
public class UtilityDto
{
    public string Name => $"{Type} Utility";
    public UtilityType? Type { get; set; }            // Тип, наприклад: "PowerPlant", "WaterTower"
    public double? ProductionCapacity { get; set; } = 0;      // Обсяг, який виробляється
    public decimal? ConstructionCost { get; set; }            // Вартість будівництва
    public decimal? MaintenanceCost { get; set; }             // Вартість утримання
    public int? Area { get; set; }                            // Площа
}
