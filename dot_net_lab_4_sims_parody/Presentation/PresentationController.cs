using Application.Dtos;
using Application.Interfaces;
using dot_net_lab_4_sims_parody.UIHolding;

namespace dot_net_lab_4_sims_parody.Presentation;

public class PresentationController
{
    private readonly IBuildingService _buildingService;
    private readonly IDistrictService _districtService;
    private readonly IQuarterService _quarterService;

    public PresentationController(
        IBuildingService buildingService,
        IDistrictService districtService,
        IQuarterService quarterService)
    {
        _buildingService = buildingService;
        _districtService = districtService;
        _quarterService = quarterService;
    }

    public void Run()
    {
        // тут основне меню або логіка сценаріїв
        string[] mainOptions = { "Створити район", "Створити квартал", "Створити будівлю", "Вийти" };
        var selected = ConsoleUIController.MenuHold(mainOptions);

        switch (selected)
        {
            case 0:
                CreateDistrict();
                break;
            case 1:
                CreateQuarter();
                break;
            case 2:
                CreateBuilding();
                break;
            case 3:
                Environment.Exit(0);
                break;
        }
    }

    private void CreateDistrict()
    {
        Console.Write("Введіть назву району: ");
        var name = Console.ReadLine();
        var district = _districtService.Create(name);
        Console.WriteLine($"Район '{district.Name}' створено.");
    }

    private void CreateQuarter()
    {
        Console.Write("Введіть назву кварталу: ");
        var name = Console.ReadLine();
        var quarter = _quarterService.Create(name);
        Console.WriteLine($"Квартал '{quarter.Name}' створено.");
    }

    private void CreateBuilding()
    {
        // приклад запиту DTO
        Console.Write("Назва будівлі: ");
        var name = Console.ReadLine();

        var dto = new BuildingDto { Name = name };
        var building = _buildingService.Create(dto);
        Console.WriteLine($"Будівлю '{building.Name}' створено.");
    }
}