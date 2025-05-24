using Application.BuilderExtensions;
using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Domain.Builders;
using Domain.Composite;

namespace Application.Services;

public class BuildingService : IBuildingService
{
    // думаю, може отут не додавати до квартала, а просто повертати, але тоді треба окрема функція для додавання
    // головна фіча сервісів - валідація, її можна перенести в Presentation, але там може губитись
    public void Add(QuarterComposite quarter, BuildingDto dto)
    {
        ValidateDtos.ValidateBuildingDto(dto);

        quarter.AddComponent(new BuildingBuilder()
            .ApplyDto(dto)
            .Build());
    }

    public void Delete(QuarterComposite quarter, BuildingDto dto)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }

    public void Update(QuarterComposite quarter, BuildingDto dto)
    {
        throw new NotImplementedException();
        // я нінаю як ми вибиратимемо їх зі списку, може взагалі його прибрати
    }
}
