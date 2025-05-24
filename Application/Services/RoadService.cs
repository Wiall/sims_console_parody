using Application.BuilderExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Domain.Builders;
using Domain.Composite;

namespace Application.Services;

public class RoadService : IRoadService
{
    // думаю, може отут не додавати до квартала, а просто повертати, але тоді треба окрема функція для додавання
    // головна фіча сервісів - валідація, її можна перенести в Presentation, але там може губитись
    public void Add(QuarterComposite quarter, RoadDto dto)
    {
        ValidateDtos.ValidateRoadDto(dto);

        quarter.AddComponent(new RoadBuilder()
            .ApplyDto(dto)
            .Build());
    }

    public void Delete(QuarterComposite quarter, RoadDto dto)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }

    public void Update(QuarterComposite quarter, RoadDto dto)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }
}