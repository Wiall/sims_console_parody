using Application.BuilderExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Domain.Builders;
using Domain.Composite;
using Domain.Models;

namespace Application.Services;

public class RoadService : IRoadService
{
    // думаю, може отут не додавати до квартала, а просто повертати, але тоді треба окрема функція для додавання
    // головна фіча сервісів - валідація, її можна перенести в Presentation, але там може губитись
    public Road Create(RoadDto dto)
    {
        ValidateDtos.ValidateRoadDto(dto);

        return new RoadBuilder()
            .ApplyDto(dto)
            .Build();
    }

    public void AddToQuarter(QuarterComposite quarter, Road model)
    {
        quarter.AddComponent(model);
    }

    public void DeleteFromQuarter(QuarterComposite quarter, Road model)
    {
        quarter.RemoveComponent(model);
    }

    public void Update(QuarterComposite quarter, Road model)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }
}