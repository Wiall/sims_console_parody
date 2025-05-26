using Domain.Composite;

namespace Application.Interfaces;

public interface IDistrictService
{
    DistrictComposite Create(string? name);

    void AddToCity(CityComposite? city, DistrictComposite? district);

    void DeleteFromCity(CityComposite? city, DistrictComposite? district);
}