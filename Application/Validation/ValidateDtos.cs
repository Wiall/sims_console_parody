using Application.Dtos;

namespace Application.Validation;

public class ValidateDtos
{
    public static void ValidateBuildingDto(BuildingDto building)
    {
        if (building == null)
        {
            throw new ServiceException("Building object is null");
        }

        if (building.Type != null
            && (building.Type < Domain.Models.BuildingType.Residential || building.Type > Domain.Models.BuildingType.Skyscraper))
        {
            throw new ServiceException("Illegal Building type");
        }

        if (building.Floors != null
            && building.Floors < 1)
        {
            throw new OutOfRangeException("Building Floors");
        }

        if (building.Capacity != null
            && building.Capacity < 1)
        {
            throw new OutOfRangeException("Building Capacity");
        }

        if (building.Area != null
            && building.Area < 1)
        {
            throw new OutOfRangeException("Building Area");
        }

        if (building.ElectricityConsumption != null
            && building.ElectricityConsumption < 1)
        {
            throw new OutOfRangeException("Building Electricity Consumption");
        }

        if (building.WaterConsumption != null
            && building.WaterConsumption < 1)
        {
            throw new OutOfRangeException("Building Water Consumption");
        }

        if (building.Income != null
            && building.Income < 1)
        {
            throw new OutOfRangeException("Building Income");
        }

        if (building.MaintenanceCost != null
            && building.MaintenanceCost < 1)
        {
            throw new OutOfRangeException("Building Maintenance Cost");
        }

        if (building.Price != null
            && building.Price < 1)
        {
            throw new OutOfRangeException("Building Price");
        }
    }

    public static void ValidateRoadDto(RoadDto road)
    {
        if (road == null)
        {
            throw new ServiceException("Road object is null");
        }

        if (road.Type != null
            && (road.Type < Domain.Models.RoadType.Arterial || road.Type > Domain.Models.RoadType.TransitOnly))
        {
            throw new ServiceException("Illegal Road type");
        }

        if (road.Area != null
            && road.Area < 1)
        {
            throw new OutOfRangeException("Road Area");
        }

        if (road.ConstructionCost != null
            && road.ConstructionCost < 1)
        {
            throw new OutOfRangeException("Road Construction Cost");
        }

        if (road.MaintenanceCost != null
            && road.MaintenanceCost < 1)
        {
            throw new OutOfRangeException("Road Maintenance Cost");
        }

        if (road.Lanes != null
            && road.Lanes < 1)
        {
            throw new OutOfRangeException("Road Lanes");
        }
    }

    public static void ValidateUtilityDto(UtilityDto utility)
    {
        if (utility == null)
        {
            throw new ServiceException("Utility object is null");
        }

        if (utility.Type != null
            && (utility.Type < Domain.Models.UtilityType.PowerPlant || utility.Type > Domain.Models.UtilityType.WasteRecyclingCenter))
        {
            throw new ServiceException("Illegal Utility type");
        }

        if (utility.Area != null
            && utility.Area < 1)
        {
            throw new OutOfRangeException("Utility Area");
        }

        if (utility.ConstructionCost != null
            && utility.ConstructionCost < 1)
        {
            throw new OutOfRangeException("Utility Construction Cost");
        }

        if (utility.MaintenanceCost != null
            && utility.MaintenanceCost < 1)
        {
            throw new OutOfRangeException("Utility Maintenance Cost");
        }

        if (utility.ProductionCapacity != null
            && utility.ProductionCapacity < 1)
        {
            throw new OutOfRangeException("Utility Production Capacity");
        }
    }
}
