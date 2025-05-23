using System;
using System.Collections.Generic;
using dot_net_lab_4_sims_parody.Builders;
namespace dot_net_lab_4_sims_parody.Composite;

/// <summary>
/// Composite class representing a city district
/// </summary>
public class DistrictComposite : ICityComponent
{
    public string Name { get; set; }
    private readonly List<ICityComponent> _components = new();

    public DistrictComposite(string name)
    {
        Name = name;
    }

    public void Add(ICityComponent component)
    {
        _components.Add(component);
    }

    public void Remove(ICityComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + $" District: {Name}");
        foreach (var component in _components)
        {
            component.Display(depth + 2);
        }
    }

    public decimal GetMaintenanceCost()
    {
        decimal total = 0;
        foreach (var component in _components)
        {
            total += component.GetMaintenanceCost();
        }
        return total;
    }

    public int GetTotalArea()
    {
        int total = 0;
        foreach (var component in _components)
        {
            total += component.GetTotalArea();
        }
        return total;
    }
}
