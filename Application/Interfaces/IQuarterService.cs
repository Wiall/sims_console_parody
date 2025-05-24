using Domain.Composite;

namespace Application.Interfaces;
public interface IQuarterService
{
    void Add(DistrictComposite district, QuarterComposite quarter);

    void Update(DistrictComposite district, QuarterComposite quarter);

    void Delete(DistrictComposite district, QuarterComposite quarter);
}
