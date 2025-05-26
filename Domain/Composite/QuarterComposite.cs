using Domain.Interfaces;

namespace Domain.Composite;

public class QuarterComposite : AbstractInfrastructureComponent
{
    public List<AbstractInfrastructureComponent> Components { get; set; } = new();

    public QuarterComposite(string name)
    {
        Name = name;
    }


    public override decimal GetMaintenanceCost()
    {
        return Components.Sum(c => c.GetMaintenanceCost());
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}+ Quarter: {Name}");
        foreach (var component in Components)
            component.Display(indent + 2);
    }

    public void AddComponent(AbstractInfrastructureComponent component)
    {
        Components.Add(component);
    }

    public void RemoveComponent(AbstractInfrastructureComponent component)
    {
        Components.Remove(component);
    }
}