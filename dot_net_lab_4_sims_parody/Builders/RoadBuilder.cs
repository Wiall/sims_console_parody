using dot_net_lab_4_sims_parody.Models;

namespace dot_net_lab_4_sims_parody.Builders;

/// <summary>
/// Builder for Road class, used to create roads
/// </summary>
public class RoadBuilder
{
    private readonly Road _road = new Road();

    public RoadBuilder SetArea(int area)
    {
        _road.Area = area;
        return this;
    }

    public RoadBuilder SetLights(bool hasLights)
    {
        _road.HasLights = hasLights;
        return this;
    }

    public RoadBuilder SetConstructionCost(decimal constructionCost)
    {
        _road.ConstructionCost = constructionCost;
        return this;
    }

    public RoadBuilder SetMaintenanceCost(decimal maintenanceCost)
    {
        _road.MaintenanceCost = maintenanceCost;
        return this;
    }

    public RoadBuilder SetLanes(int lanes)
    {
        _road.Lanes = lanes;
        return this;
    }

    
    /// <summary>
    /// Builds default road
    /// </summary>
    /// <returns>Road</returns>
    public Road Build()
    {
        return _road;
    }
}