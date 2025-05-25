using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IBuildingService : ICrudInfrastructureComponent<Building>
{
    // В круди не можу додати, бо тут вхід один тип, вихід - інший, зазвичай так не робиться, тому дженерік так не працює
    public Building Create(BuildingDto dto);
}