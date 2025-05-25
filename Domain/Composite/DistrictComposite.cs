using Domain.Interfaces;

namespace Domain.Composite;

public class DistrictComposite(string name) : ICityComponent
{
    private readonly List<IInfrastructureComponent> _quarters = new();
    public string Name { get; set; } = name;

    public decimal GetMaintenanceCost()
    {
        return _quarters.Sum(q => q.GetMaintenanceCost());
    }

    public int GetTotalArea()
    {
        var total = 0;
        foreach (var quarter in _quarters) total += quarter.Area;

        return total;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ District: {Name}");
        foreach (var quarter in _quarters)
            quarter.Display(indent + 2);
    }

    public void AddQuarter(IInfrastructureComponent quarter)
    {
        _quarters.Add(quarter);
    }

    public void RemoveQuarter(IInfrastructureComponent quarter)
    {
        _quarters.Remove(quarter);
    }
}