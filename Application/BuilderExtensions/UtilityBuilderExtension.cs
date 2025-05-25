using Application.Dtos;
using Domain.Builders;

namespace Application.BuilderExtensions;

public static class UtilityBuilderExtension
{
    public static UtilityBuilder ApplyDto(this UtilityBuilder builder, UtilityDto dto)
    {
        if (dto.Type.HasValue)
            builder.SetType(dto.Type.Value);

        if (dto.ProductionCapacity.HasValue)
            builder.SetProductionCapacity(dto.ProductionCapacity.Value);

        if (dto.Area.HasValue)
            builder.SetArea(dto.Area.Value);

        if (dto.ConstructionCost.HasValue)
            builder.SetConstructionCost(dto.ConstructionCost.Value);

        if (dto.MaintenanceCost.HasValue)
            builder.SetMaintenanceCost(dto.MaintenanceCost.Value);

        return builder;
    }
}