using System.Text.Json;
using Domain.Composite;

namespace dot_net_lab_4_sims_parody.Presentation;

public static class CityStorage
{
    private const string FilePath = "cities.json";

    private static List<CityComposite> _cities = new();

    public static IReadOnlyList<CityComposite> Cities => _cities.AsReadOnly();


    public static void AddCity(CityComposite city)
    {
        _cities.Add(city);
        SaveAll();
    }

    public static void RemoveCity(string name)
    {
        _cities.RemoveAll(c => c.Name == name);
        SaveAll();
    }

    public static CityComposite? GetCity(string name)
    {
        return _cities.FirstOrDefault(c => c.Name == name);
    }

    public static void SaveAll()
    {
        var json = JsonSerializer.Serialize(_cities, new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true // опціонально — якщо потрібна серіалізація полів
        });
        File.WriteAllText(FilePath, json);
    }

    public static void LoadAll()
    {
        if (!File.Exists(FilePath))
        {
            _cities = new List<CityComposite>();
            return;
        }

        var json = File.ReadAllText(FilePath);
        _cities = JsonSerializer.Deserialize<List<CityComposite>>(json) ?? new List<CityComposite>();
        Console.WriteLine("Cities loaded.");
    }
}