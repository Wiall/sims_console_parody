using Application.Interfaces;
using Application.Validation;
using Domain.Composite;
using System.Reflection;

namespace Application.Services;

public class DistrictService : IDistrictService
{
    public DistrictComposite Create(string? name)
    {
        if (name == null)
        {
            throw new ServiceException("District name is null!");
        }

        return new DistrictComposite(name);
    }

    public void AddToCity(CityComposite? city, DistrictComposite? district)
    {
        if (city == null)
        {
            throw new ServiceException("City is null!");
        }

        if (district == null)
        {
            throw new ServiceException("District is null!");
        }

        city.AddDistrict(district);
    }

    public void DeleteFromCity(CityComposite? city, DistrictComposite? district)
    {
        if (city == null)
        {
            throw new ServiceException("City is null!");
        }

        if (district == null)
        {
            throw new ServiceException("District is null!");
        }

        city.RemoveDistrict(district);
    }
}