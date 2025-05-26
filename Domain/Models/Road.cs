using Domain.Interfaces;

namespace Domain.Models;

public class Road : AbstractInfrastructureComponent
{
    public RoadType Type { get; set; }
    public bool HasLights { get; set; } // Чи є вуличне освітлення
    public decimal ConstructionCost { get; set; } // Вартість будівництва
    public decimal MaintenanceCost { get; set; } // Вартість утримання
    public int Lanes { get; set; } = 1; // Кількість смуг
    public Road()
    {
        Name = $"{Type} Road";
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) +
                          $"- Road: {Lanes} lanes, Type: {Type} Lights: {(HasLights ? "yes" : "no")}");
    }

    public override decimal GetMaintenanceCost()
    {
        return MaintenanceCost;
    }

    public int GetTotalArea()
    {
        return Area;
    }
}