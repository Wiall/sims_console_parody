using Application.Dtos;
using Application.Interfaces;
using Domain.Composite;
using Domain.Models;

namespace dot_net_lab_4_sims_parody.Presentation;

public class CityController
{
    private readonly IBuildingService _buildingService;
    private readonly IDistrictService _districtService;
    private readonly IQuarterService _quarterService;
    private readonly IRoadService _roadService;
    private readonly IUtilityService _utilityService;

    public CityController(
        IBuildingService buildingService,
        IDistrictService districtService,
        IQuarterService quarterService,
        IRoadService roadService,
        IUtilityService utilityService)
    {
        _buildingService = buildingService;
        _districtService = districtService;
        _quarterService = quarterService;
        _roadService = roadService;
        _utilityService = utilityService;
    }

    public DistrictComposite CreateDistrict(string? name)
    {
        return _districtService.Create(name);
    }

    public QuarterComposite CreateQuarter(string? name)
    {
        return _quarterService.Create(name);
    }

    public Building CreateBuilding(BuildingDto building)
    {
        return _buildingService.Create(building);
    }
    
    public Road CreateRoad(RoadDto road)
    {
        return _roadService.Create(road);
    }
    
    public Utility CreateUtility(UtilityDto utility)
    {
        return _utilityService.Create(utility);
    }

    public void AddQuarterToDistrict(DistrictComposite? district, QuarterComposite? quarter)
    {
        _quarterService.AddToDistrict(district, quarter);
    }

    public void AddBuildingToQuarter(Building building, QuarterComposite quarter)
    {
        _buildingService.AddToQuarter(quarter, building);
    }
    
    public void AddRoadToQuarter(Road road, QuarterComposite quarter)
    {
        _roadService.AddToQuarter(quarter, road);
    }
    
    public void AddUtilityToQuarter(Utility utility, QuarterComposite quarter)
    {
        _utilityService.AddToQuarter(quarter, utility);
    }
}