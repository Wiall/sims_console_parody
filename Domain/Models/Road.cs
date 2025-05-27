using Domain.Interfaces;

namespace Domain.Models;

public class Road : IInfrastructureComponent
{
    public RoadType Type { get; set; }
    public bool HasLights { get; set; } // Чи є вуличне освітлення
    public decimal ConstructionCost { get; set; } // Вартість будівництва
    public decimal MaintenanceCost { get; set; } // Вартість утримання
    public int Lanes { get; set; } = 1; // Кількість смуг
    public string Name => $"{Type} Road";
    public int Area { get; set; } = 1;

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) +
                          $"- Road: {Lanes} lanes, Type: {Type} Lights: {(HasLights ? "yes" : "no")}");
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