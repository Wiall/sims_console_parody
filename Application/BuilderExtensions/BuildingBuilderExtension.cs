using Application.Dtos;
using Domain.Builders;

namespace Application.BuilderExtensions;
public static class BuildingBuilderExtension
{
    public static BuildingBuilder ApplyDto(this BuildingBuilder builder, BuildingDto dto)
    {
        if (dto.Type.HasValue)
            builder.SetType(dto.Type.Value);

        if (dto.Floors.HasValue)
            builder.SetFloors(dto.Floors.Value);

        if (dto.Capacity.HasValue)
            builder.SetCapacity(dto.Capacity.Value);

        if (dto.HasParking.HasValue)
            builder.SetParking(dto.HasParking.Value);

        if (dto.Area.HasValue)
            builder.SetArea(dto.Area.Value);

        if (dto.ElectricityConsumption.HasValue)
            builder.SetElectricity(dto.ElectricityConsumption.Value);

        if (dto.WaterConsumption.HasValue)
            builder.SetWater(dto.WaterConsumption.Value);

        if (dto.Income.HasValue)
            builder.SetIncome(dto.Income.Value);

        if (dto.MaintenanceCost.HasValue)
            builder.SetMaintenance(dto.MaintenanceCost.Value);

        if (dto.Price.HasValue)
            builder.SetPrice(dto.Price.Value);

        return builder;
    }
}
