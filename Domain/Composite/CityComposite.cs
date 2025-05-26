using Domain.Interfaces;

namespace Domain.Composite;

/// <summary>
///     Composite class representing a city as a set of districts
/// </summary>
public class CityComposite(string name) : ICityComponent
{
    public List<DistrictComposite> Districts { get; set; } = new();
    public string Name { get; set; } = name;

    public decimal GetMaintenanceCost()
    {
        return Districts.Sum(d => d.GetMaintenanceCost());
    }

    public void Display(int depth = 0)
    {
        foreach (var district in Districts)
        {
            district.Display(depth + 2);
            Console.WriteLine();
        }
    }

    public int GetTotalArea()
    {
        var total = 0;
        foreach (var district in Districts) total += district.GetTotalArea();
        return total;
    }

    public void AddDistrict(DistrictComposite district)
    {
        Districts.Add(district);
    }

    public void RemoveDistrict(DistrictComposite district)
    {
        Districts.Remove(district);
    }
}