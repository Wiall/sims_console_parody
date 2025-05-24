using Application.Interfaces;
using Domain.Composite;

namespace Application.Services;
public class DistrictService : IDistrictService
{
    public DistrictComposite Creatre(string name)
    {
        return new DistrictComposite(name);
    }

    public void Add(CityComposite city, DistrictComposite district)
    {
        city.AddDistrict(district);
    }

    public void Delete(CityComposite city, DistrictComposite district)
    {
        city.RemoveDistrict(district);
    }

    public void Update(CityComposite city, DistrictComposite district)
    {
        throw new NotImplementedException();
        // я нінаю як це рішать, може взагалі його прибрати
    }
}