using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoadService : ICrudInfrastructureComponent<Road>
{
    // В круди не можу додати, бо тут вхід один тип, вихід - інший, зазвичай так не робиться, тому дженерік так не працює
    public Road Create(RoadDto dto);
}