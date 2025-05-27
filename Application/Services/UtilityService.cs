using Application.BuilderExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Domain.Builders;
using Domain.Composite;
using Domain.Models;

namespace Application.Services;

public class UtilityService : IUtilityService
{
    public Utility Create(UtilityDto? dto)
    {
        ValidateDtos.ValidateUtilityDto(dto);

        return new UtilityBuilder()
            .ApplyDto(dto)
            .Build();
    }

    public void AddToQuarter(QuarterComposite? quarter, Utility? model)
    {
        if (model == null)
        {
            throw new ServiceException("Structure is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        quarter.AddUtility(model);
    }

    public void DeleteFromQuarter(QuarterComposite? quarter, Utility? model)
    {
        if (model == null)
        {
            throw new ServiceException("Structure is null!");
        }

        if (quarter == null)
        {
            throw new ServiceException("Quarter is null!");
        }

        quarter.RemoveUtility(model);
    }
}