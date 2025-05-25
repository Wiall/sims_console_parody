using Domain.Models;

namespace Domain.Builders;

/// <summary>
/// Builder for Building class, used to create buildings
/// </summary>
public class BuildingBuilder
{
    private readonly Building _building = new Building();

    public BuildingBuilder SetType(BuildingType type)
    {
        _building.Type = type;
        return this;
    }
    
    public BuildingBuilder SetFloors(int floors)
    {
        _building.Floors = floors;
        return this;
    }
    
    public BuildingBuilder SetCapacity(int capacity)
    {
        _building.Capacity = capacity;
        return this;
    }
    
    public BuildingBuilder SetParking(bool hasParking)
    {
        _building.HasParking = hasParking;
        return this;
    }
    
    public BuildingBuilder SetArea(int area)
    {
        _building.Area = area;
        return this;
    }
    
    public BuildingBuilder SetElectricity(double electricityConsumption)
    {
        _building.ElectricityConsumption = electricityConsumption;
        return this;
    }
    
    public BuildingBuilder SetWater(double waterConsumption)
    {
        _building.WaterConsumption = waterConsumption;
        return this;
    }
    
    public BuildingBuilder SetIncome(decimal income)
    {
        _building.Income = income;
        return this;
    }
    
    public BuildingBuilder SetMaintenance(decimal maintenanceCost)
    {
        _building.MaintenanceCost = maintenanceCost;
        return this;
    }
    
    public BuildingBuilder SetPrice(decimal price)
    {
        _building.Price = price;
        return this;
    }
    
    /// <summary>
    /// Builds default building
    /// </summary>
    /// <returns>Building</returns>
    public Building Build()
    {
        return _building;
    }
}