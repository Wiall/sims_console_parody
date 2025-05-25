using Domain.Interfaces;

namespace Domain.Composite;

public class QuarterComposite(string name) : IInfrastructureComponent
{
    private readonly List<IInfrastructureComponent> _components = new();
    public string Name { get; set; } = name;
    public int Area => _components.Sum(c => c.Area);

    public decimal GetMaintenanceCost()
    {
        return _components.Sum(c => c.GetMaintenanceCost());
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ Quarter: {Name}");
        foreach (var component in _components)
            component.Display(indent + 2);
    }

    public void AddComponent(IInfrastructureComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(IInfrastructureComponent component)
    {
        _components.Remove(component);
    }
}