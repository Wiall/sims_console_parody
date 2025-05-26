using Application.Interfaces;
using Application.Validation;
using Domain.Composite;

namespace Application.Services;

public class QuarterService : IQuarterService
{
    public QuarterComposite Create(string? name)
    {
        if (name == null)
        {
            throw new ServiceException("Quarter name is null!");
        }

        return new QuarterComposite(name);
    }

    public void AddToDistrict(DistrictComposite? district, QuarterComposite? quarter)
    {
        if (district == null)
        {
            throw new ServiceException("District is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        district.AddQuarter(quarter);
    }

    public void DeleteFromDistrict(DistrictComposite? district, QuarterComposite? quarter)
    {
        if (district == null)
        {
            throw new ServiceException("District is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        district.RemoveQuarter(quarter);
    }
}