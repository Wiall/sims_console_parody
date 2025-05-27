using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces;

public interface IUtilityService : ICrudInfrastructureComponent<Utility>
{
    public Utility Create(UtilityDto? dto);
}