using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IUtilityService : ICrudInfrastructureComponent<Utility>
{
    // В круди не можу додати, бо тут вхід один тип, вихід - інший, зазвичай так не робиться, тому дженерік так не працює
    public Utility Create(UtilityDto dto);
}
