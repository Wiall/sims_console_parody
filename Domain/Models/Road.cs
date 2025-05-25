using Domain.Interfaces;

namespace Domain.Models;

public class Road : IInfrastructureComponent
{
    public string Name => $"{Type} Road";
    public RoadType Type { get; set; }
    public int Area { get; set; } = 1;                 // Площа(?) дороги (можна юзать як довжину)
    public bool HasLights { get; set; }                // Чи є вуличне освітлення
    public decimal ConstructionCost { get; set; }      // Вартість будівництва
    public decimal MaintenanceCost { get; set; }       // Вартість утримання
    public int Lanes { get; set; } = 1;                // Кількість смуг
    
    public void Display(int depth = 0)
    {
        Console.WriteLine(new string(' ', depth) + $"- Road: {Lanes} lanes, Type: {Type} Lights: {(HasLights ? "yes" : "no")}");
    }

    public decimal GetMaintenanceCost() => MaintenanceCost;
    public int GetTotalArea() => Area;
}
