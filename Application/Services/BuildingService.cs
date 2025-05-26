using Application.BuilderExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Domain.Builders;
using Domain.Composite;
using Domain.Models;

namespace Application.Services;

public class BuildingService : IBuildingService
{
    public Building Create(BuildingDto? dto)
    {
        ValidateDtos.ValidateBuildingDto(dto);

        return new BuildingBuilder()
            .ApplyDto(dto)
            .Build();
    }

    public void AddToQuarter(QuarterComposite? quarter, Building? model)
    {
        if (model == null)
        {
            throw new ServiceException("Structure is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        quarter.AddComponent(model);
    }

    public void DeleteFromQuarter(QuarterComposite? quarter, Building? model)
    {
        if (model == null)
        {
            throw new ServiceException("Structure is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        quarter.RemoveComponent(model);
    }
}