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

    public CityController(
        IBuildingService buildingService,
        IDistrictService districtService,
        IQuarterService quarterService)
    {
        _buildingService = buildingService;
        _districtService = districtService;
        _quarterService = quarterService;
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

    public void AddQuarterToDistrict(DistrictComposite? district, QuarterComposite? quarter)
    {
        _quarterService.AddToDistrict(district, quarter);
    }
}