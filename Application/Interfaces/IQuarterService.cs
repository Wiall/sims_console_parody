using Domain.Composite;

namespace Application.Interfaces;

public interface IQuarterService
{
    QuarterComposite Create(string? name);

    void AddToDistrict(DistrictComposite? district, QuarterComposite? quarter);

    void DeleteFromDistrict(DistrictComposite? district, QuarterComposite? quarter);
}