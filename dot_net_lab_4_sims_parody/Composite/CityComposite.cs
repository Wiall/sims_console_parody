using dot_net_lab_4_sims_parody.Builders;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Composite;

/// <summary>
/// Composite class representing a city as a set of districts
/// </summary>
public class CityComposite : ICityComponent
{
    public string Name { get; set; }
    private readonly List<ICityComponent> _districts = new();

    public CityComposite(string name)
    {
        Name = name;
    }

    public void Add(ICityComponent district)
    {
        _districts.Add(district);
    }

    public void Remove(ICityComponent district)
    {
        _districts.Remove(district);
    }

    public void Display(int depth = 0)
    {
        MenuUI.MakeHeader(Name);
        foreach (var district in _districts)
        {
            district.Display(depth + 2);
            Console.WriteLine();
        }
    }

    public decimal GetMaintenanceCost()
    {
        decimal total = 0;
        foreach (var district in _districts)
        {
            total += district.GetMaintenanceCost();
        }
        return total;
    }

    public int GetTotalArea()
    {
        int total = 0;
        foreach (var district in _districts)
        {
            total += district.GetTotalArea();
        }
        return total;
    }
}
