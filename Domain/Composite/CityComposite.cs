using Domain.Interfaces;

namespace Domain.Composite;

/// <summary>
///     Composite class representing a city as a set of districts
/// </summary>
public class CityComposite(string name) : ICityComponent
{
    private readonly List<ICityComponent> _districts = new();
    public string Name { get; set; } = name;

    public decimal GetMaintenanceCost()
    {
        return _districts.Sum(d => d.GetMaintenanceCost());
    }

    public void Display(int indent = 0)
    {
        foreach (var district in _districts)
        {
            district.Display(indent + 2);
            Console.WriteLine();
        }
    }

    public int GetTotalArea()
    {
        var total = 0;
        foreach (var district in _districts) total += district.GetTotalArea();
        return total;
    }

    public void AddDistrict(ICityComponent district)
    {
        _districts.Add(district);
    }

    public void RemoveDistrict(ICityComponent district)
    {
        _districts.Remove(district);
    }
}