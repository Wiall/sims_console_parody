using Domain.Models;

namespace Application.Dtos;

public class RoadDto
{
    public string? Name { get; set; }
    public RoadType? Type { get; set; }
    public int? Area { get; set; } = 1; // Площа(?) дороги (можна юзать як довжину)
    public bool? HasLights { get; set; } // Чи є вуличне освітлення
    public decimal? ConstructionCost { get; set; } // Вартість будівництва
    public decimal? MaintenanceCost { get; set; } // Вартість утримання
    public int? Lanes { get; set; } = 1; // Кількість смуг
}