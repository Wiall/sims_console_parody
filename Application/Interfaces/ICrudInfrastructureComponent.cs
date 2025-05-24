using Application.Dtos;
using Domain.Composite;

namespace Application.Interfaces;

public interface ICrudInfrastructureComponent<TModel>
    where TModel : class
{
    void Add(QuarterComposite quarter, TModel dto);

    void Update(QuarterComposite quarter, TModel dto);

    void Delete(QuarterComposite quarter, TModel dto);
}
