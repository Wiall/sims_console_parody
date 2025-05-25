using Domain.Interfaces;

namespace Domain.Models;

/// <summary>
///     Building model class
/// </summary>
public class Building : IInfrastructureComponent
{
    public BuildingType Type { get; set; } // Тип будівлі по типу "Школа" чи "Офіс"
    public int Floors { get; set; } = 1; // Кількість поверхів
    public int Capacity { get; set; } // Місткість будівлі (люди)
    public bool HasParking { get; set; } // Чи має парковку
    public double ElectricityConsumption { get; set; } = 10f; // Споживання електрики
    public double WaterConsumption { get; set; } = 1000f; // Споживання води
    public decimal Income { get; set; } // Прибуток з будівлі (оренда, інші прибутки)
    public decimal MaintenanceCost { get; set; } // Ціна утримання будівлі
    public decimal Price { get; set; } // Ціна будівництва
    public string Name => $"{Type} Building";
    public int Area { get; set; } = 1; // Площа на планері (плейсхолдер, залежить як реалізований буде планер)

    public void Display(int depth = 0)
    {
        Console.WriteLine(new string(' ', depth) + $"- Building: {Type}, Floors: {Floors}, Income: {Income}");
    }

    public decimal GetMaintenanceCost()
    {
        return MaintenanceCost;
    }

    /// <summary>
    ///     Profit calculation function
    /// </summary>
    /// <returns>Clear profit</returns>
    public decimal GetProfit()
    {
        return Income - MaintenanceCost;
    }

    public int GetTotalArea()
    {
        return Area;
    }
}