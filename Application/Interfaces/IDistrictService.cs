using Domain.Composite;

namespace Application.Interfaces;
public interface IDistrictService
{
    void Add(CityComposite city, DistrictComposite district);

    void Update(CityComposite city, DistrictComposite district);

    void Delete(CityComposite city, DistrictComposite district);
}
