using dot_net_lab_4_sims_parody.Interfaces;

public class DistrictComposite(string name) : ICityComponent
{
    public string Name { get; set; } = name;
    private readonly List<IInfrastructureComponent> _quarters = new();

    public void AddQuarter(IInfrastructureComponent quarter) => _quarters.Add(quarter);
    public void RemoveQuarter(IInfrastructureComponent quarter) => _quarters.Remove(quarter);

    public decimal GetMaintenanceCost() =>
        _quarters.Sum(q => q.GetMaintenanceCost());

    public int GetTotalArea()
    {
        int total = 0;
        foreach (var quarter in _quarters)
        {
            total += quarter.Area;
        }

        return total;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ District: {Name}");
        foreach (var quarter in _quarters)
            quarter.Display(indent + 2);
    }
}
