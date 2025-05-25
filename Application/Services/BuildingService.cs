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
    // думаю, може отут не додавати до квартала, а просто повертати, але тоді треба окрема функція для додавання
    // головна фіча сервісів - валідація, її можна перенести в Presentation, але там може губитись
    public Building Create(BuildingDto dto)
    {
        ValidateDtos.ValidateBuildingDto(dto);

        return new BuildingBuilder()
            .ApplyDto(dto)
            .Build();
    }

    public void AddToQuarter(QuarterComposite quarter, Building model)
    {
        quarter.AddComponent(model);
    }

    public void DeleteFromQuarter(QuarterComposite quarter, Building model)
    {
        quarter.RemoveComponent(model);
    }

    public void Update(QuarterComposite quarter, Building model)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }
}