using Application.Interfaces;
using Domain.Composite;

namespace Application.Services;
public class DistrictService : IDistrictService
{
    public DistrictComposite Create(string name)
    {
        return new DistrictComposite(name);
    }

    public void AddToCity(CityComposite city, DistrictComposite district)
    {
        city.AddDistrict(district);
    }

    public void DeleteFromCity(CityComposite city, DistrictComposite district)
    {
        city.RemoveDistrict(district);
    }

    public void Update(CityComposite city, DistrictComposite district)
    {
        throw new NotImplementedException();
        // я нінаю як це рішать, може взагалі його прибрати
    }
}