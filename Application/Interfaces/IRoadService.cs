using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoadService : ICrudInfrastructureComponent<Road>
{
    public Road Create(RoadDto? dto);
}