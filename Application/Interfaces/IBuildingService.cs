using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IBuildingService : ICrudInfrastructureComponent<Building>
{
    public Building Create(BuildingDto? dto);
}