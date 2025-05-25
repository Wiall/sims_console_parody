using Application.Interfaces;
using Domain.Composite;

namespace Application.Services;

public class QuarterService : IQuarterService
{
    public QuarterComposite Create(string name)
    {
        return new QuarterComposite(name);
    }

    public void AddToDistrict(DistrictComposite district, QuarterComposite quarter)
    {
        district.AddQuarter(quarter);
    }

    public void DeleteFromDistrict(DistrictComposite district, QuarterComposite quarter)
    {
        district.RemoveQuarter(quarter);
    }

    public void Update(DistrictComposite district, QuarterComposite quarter)
    {
        throw new NotImplementedException();
        // я нінаю як це рішать, може взагалі його прибрати
    }
}