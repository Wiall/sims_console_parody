using dot_net_lab_4_sims_parody.Builders;

namespace dot_net_lab_4_sims_parody.Composite;

public class QuarterComposite(string name) : IInfrastructureComponent
{
    public string Name { get; set; } = name;
    public int Area => _components.Sum(c => c.Area);
    private readonly List<IInfrastructureComponent> _components = new();

    public void AddComponent(IInfrastructureComponent component) => _components.Add(component);
    public void RemoveComponent(IInfrastructureComponent component) => _components.Remove(component);

    public decimal GetMaintenanceCost() =>
        _components.Sum(c => c.GetMaintenanceCost());

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ Quarter: {Name}");
        foreach (var component in _components)
            component.Display(indent + 2);
    }
}
