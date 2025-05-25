using Domain.Composite;

namespace Application.Interfaces;

public interface ICrudInfrastructureComponent<TModel>
    where TModel : class
{
    void AddToQuarter(QuarterComposite quarter, TModel dto);

    void Update(QuarterComposite quarter, TModel dto);

    void DeleteFromQuarter(QuarterComposite quarter, TModel dto);
}