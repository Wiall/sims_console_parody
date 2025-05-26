using Domain.Interfaces;

namespace Domain.Composite;

public class DistrictComposite(string name) : ICityComponent
{
    public List<AbstractInfrastructureComponent> Quarters { get; set; } = new();
    public string Name { get; set; } = name;

    public decimal GetMaintenanceCost()
    {
        return Quarters.Sum(q => q.GetMaintenanceCost());
    }

    public int GetTotalArea()
    {
        var total = 0;
        foreach (var quarter in Quarters) total += quarter.Area;

        return total;
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth)}+ District: {Name}");
        foreach (var quarter in Quarters)
            quarter.Display(depth + 2);
    }

    public void AddQuarter(AbstractInfrastructureComponent quarter)
    {
        Quarters.Add(quarter);
    }

    public void RemoveQuarter(AbstractInfrastructureComponent quarter)
    {
        Quarters.Remove(quarter);
    }
}