using dot_net_lab_4_sims_parody.Models;

namespace dot_net_lab_4_sims_parody.Builders;

/// <summary>
/// Builder for Utility class, used to create utilities
/// </summary>
public class UtilityBuilder
{
    private readonly Utility _utility = new Utility();

    public UtilityBuilder SetType(string type)
    {
        _utility.Type = type;
        return this;
    }

    public UtilityBuilder SetProductionCapacity(double capacity)
    {
        _utility.ProductionCapacity = capacity;
        return this;
    }

    public UtilityBuilder SetConstructionCost(decimal cost)
    {
        _utility.ConstructionCost = cost;
        return this;
    }

    public UtilityBuilder SetMaintenanceCost(decimal cost)
    {
        _utility.MaintenanceCost = cost;
        return this;
    }

    public UtilityBuilder SetArea(int area)
    {
        _utility.Area = area;
        return this;
    }

    /// <summary>
    /// Builds default utility
    /// </summary>
    /// <returns>Utility</returns>
    public Utility Build()
    {
        return _utility;
    }
}