using Application.Dtos;
using Domain.Builders;

namespace Application.BuilderExtensions;

public static class RoadBuilderExtension
{
    public static RoadBuilder ApplyDto(this RoadBuilder builder, RoadDto dto)
    {
        if (dto.Type.HasValue)
            builder.SetType(dto.Type.Value);

        if (dto.HasLights.HasValue)
            builder.SetLights(dto.HasLights.Value);

        if (dto.Area.HasValue)
            builder.SetArea(dto.Area.Value);

        if (dto.ConstructionCost.HasValue)
            builder.SetConstructionCost(dto.ConstructionCost.Value);

        if (dto.MaintenanceCost.HasValue)
            builder.SetMaintenanceCost(dto.MaintenanceCost.Value);

        if (dto.Lanes.HasValue)
            builder.SetLanes(dto.Lanes.Value);

        return builder;
    }
}