using System.Text;
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Composite;
using Domain.Models;
using dot_net_lab_4_sims_parody.ExceptionHandlers;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;
using Microsoft.Extensions.DependencyInjection;

namespace dot_net_lab_4_sims_parody;

internal static class Program
{
    public static void Main()
    {
        // УВАГА ПОЧИТАЙТЕ
        // мда, напхав я кнешн по самі, і навіть DI піднялась, і найжахливіше, що з першого разу
        // я кнешн люблю DI і все ще отримую дофамінові хіти, коли вона працює, але мені здається, що тут вона може бути трошки зайвою
        // ЗА DI - вона все ще треба, бо білдер грає роль в сервісах, тобто він все одно корисний бла бла
        // ПРОТИ DI - у нас є білдер, через що всі ці сервіси і DI не потрібні, бо білдер і так ізолює шари
        // якщо прибирати DI, то треба сюди перенести dto-шки (або якось обійти їх при роботі з юзером)
        // і Validation, який треба буде теж викликати при роботі з юзером, там все ясно
        //
        // Я ще більше перестаю любити Application Layer тому
        // ІНСТРУКЦІЯ ЯК ПРИБРАТИ APPLICATION
        // Берете BuilderExtensions, Dtos, Validation, переносите в цей проект (не забудьте поміняти їм неймспейси
        // Прибираєте мій код, розкоменчуєте свій
        // Замість того, щоб юзати Builder тепер можете збирати поля в Dto-шку і кликати ApplyDto
        // Наприклад:
        // Було:
        // var school = new BuildingBuilder()
        //     .SetType(BuildingType.School)
        //     .SetFloors(3)
        //     .SetCapacity(500)
        //     .SetArea(4)
        //     .SetMaintenance(3000)
        //     .Build();
        // Стало:
        // new BuildingDto()
        // {
        //     Type = BuildingType.School,
        //     Floors = 3,
        //     Capacity = 500,
        //     Area = 400,
        //     MaintenanceCost = 3000,
        // }
        //
        // var school = new BuildingBuilder()
        //    .ApplyDto(dto)
        //    .Build();
        //
        // Не забувайте про валідації

        // Оце акшуаллі мій патерн кста, ги)
        var serviceExceptionHandler = new ServiceExceptionHandler();
        var outOfRangeExceptionHandler = new OutOfRangeExceptionHandler();
        var genericExceptionHandler = new GenericExceptionHandler();

        serviceExceptionHandler.SetNext(outOfRangeExceptionHandler);
        outOfRangeExceptionHandler.SetNext(genericExceptionHandler);
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello, repo!");

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var buildingService = serviceProvider.GetRequiredService<IBuildingService>();
            var roadService = serviceProvider.GetRequiredService<IRoadService>();
            var utilityService = serviceProvider.GetRequiredService<IUtilityService>();
            var quarterService = serviceProvider.GetRequiredService<IQuarterService>();
            var districtService = serviceProvider.GetRequiredService<IDistrictService>();

            var centralQuarter = quarterService.Create("Центральний квартал");
            var residentialQuarter = quarterService.Create("Житловий квартал");
            var industrialQuarter = quarterService.Create("Промисловий квартал");

            var centralDistrict = districtService.Create("Центральний район");
            var residentialDistrict = districtService.Create("Житловий район");
            var industrialDistrict = districtService.Create("Промисловий район");

            // CityService це дурна ідея, тому буде отак
            var city = new CityComposite("Симулянськ");

            var school = buildingService.Create(new BuildingDto
            {
                Type = BuildingType.School,
                Floors = 3,
                Capacity = 500,
                Area = 400,
                MaintenanceCost = 3000
            });

            var road = roadService.Create(new RoadDto
            {
                Type = RoadType.TransitOnly,
                Lanes = 2,
                HasLights = true,
                Area = 2,
                MaintenanceCost = 3000
            });

            var utility = utilityService.Create(new UtilityDto
            {
                Type = UtilityType.WaterTower,
                ProductionCapacity = 20000,
                Area = 3,
                MaintenanceCost = 1000
            });

            buildingService.AddToQuarter(centralQuarter, school);
            roadService.AddToQuarter(centralQuarter, road);
            utilityService.AddToQuarter(centralQuarter, utility);

            buildingService.AddToQuarter(residentialQuarter, buildingService.Create(new BuildingDto
            {
                Type = BuildingType.Apartment,
                Floors = 5,
                Capacity = 100,
                Area = 6,
                MaintenanceCost = 2000
            }));
            roadService.AddToQuarter(residentialQuarter, roadService.Create(new RoadDto
            {
                Lanes = 1,
                HasLights = false,
                Area = 2,
                MaintenanceCost = 300
            }));

            utilityService.AddToQuarter(industrialQuarter, utilityService.Create(new UtilityDto
            {
                Type = UtilityType.PowerPlant,
                ProductionCapacity = 50000,
                Area = 10,
                MaintenanceCost = 5000
            }));
            roadService.AddToQuarter(industrialQuarter, roadService.Create(new RoadDto
            {
                Lanes = 3,
                HasLights = true,
                Area = 4,
                MaintenanceCost = 800
            }));

            quarterService.AddToDistrict(centralDistrict, centralQuarter);
            quarterService.AddToDistrict(residentialDistrict, residentialQuarter);
            quarterService.AddToDistrict(industrialDistrict, industrialQuarter);

            districtService.AddToCity(city, centralDistrict);
            districtService.AddToCity(city, residentialDistrict);
            districtService.AddToCity(city, industrialDistrict);

            // Лишив старий код
            /*
            // === Створення будівель, доріг, інфраструктури ===
            var school = new BuildingBuilder()
                .SetType(BuildingType.School)
                .SetFloors(3)
                .SetCapacity(500)
                .SetArea(4)
                .SetMaintenance(3000)
                .Build();

            var road = new RoadBuilder()
                .SetLanes(2)
                .SetType(RoadType.TransitOnly)
                .SetLights(true)
                .SetArea(2)
                .SetMaintenanceCost(500)
                .Build();

            var utility = new UtilityBuilder()
                .SetType(UtilityType.WaterTower)
                .SetProductionCapacity(20000)
                .SetArea(3)
                .SetMaintenanceCost(1000)
                .Build();

            // === Центральний квартал ===
            var centralQuarter = new QuarterComposite("Центральний квартал");
            centralQuarter.AddComponent(school);
            centralQuarter.AddComponent(road);
            centralQuarter.AddComponent(utility);

            // === Житловий квартал ===
            var residentialQuarter = new QuarterComposite("Житловий квартал");
            residentialQuarter.AddComponent(new BuildingBuilder()
                .SetType(BuildingType.Apartment)
                .SetFloors(5)
                .SetCapacity(100)
                .SetArea(6)
                .SetMaintenance(2000)
                .Build());
            residentialQuarter.AddComponent(new RoadBuilder()
                .SetLanes(1)
                .SetLights(false)
                .SetArea(2)
                .SetMaintenanceCost(300)
                .Build());

            // === Промисловий квартал ===
            var industrialQuarter = new QuarterComposite("Промисловий квартал");
            industrialQuarter.AddComponent(new UtilityBuilder()
                .SetType(UtilityType.PowerPlant)
                .SetProductionCapacity(50000)
                .SetArea(10)
                .SetMaintenanceCost(5000)
                .Build());
            industrialQuarter.AddComponent(new RoadBuilder()
                .SetLanes(3)
                .SetLights(true)
                .SetArea(4)
                .SetMaintenanceCost(800)
                .Build());

            // === Райони ===
            var centralDistrict = new DistrictComposite("Центральний район");
            centralDistrict.AddQuarter(centralQuarter);

            var residentialDistrict = new DistrictComposite("Житловий район");
            residentialDistrict.AddQuarter(residentialQuarter);

            var industrialDistrict = new DistrictComposite("Промисловий район");
            industrialDistrict.AddQuarter(industrialQuarter);

            // === Місто ===
            var city = new CityComposite("Симулянськ");
            city.AddDistrict(centralDistrict);
            city.AddDistrict(residentialDistrict);
            city.AddDistrict(industrialDistrict);
            */

            // Оцю шнягу можна буде в City service
            city.Display();
            Console.WriteLine($"\nЗагальна вартість утримання: {city.GetMaintenanceCost()}");
            Console.WriteLine($"Загальна площа: {city.GetTotalArea()}");

            string? currentCityName = null;

            var menuOptions = new[]
            {
                "Create city",
                "Open city",
                "Delete city",
                "Show info about city",
                "Exit"
            };

            var menuActions = new Dictionary<int, Action>
            {
                {
                    0, () =>
                    {
                        Console.Write("Enter city name: ");
                        var name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(name)) return;

                        if (CityStorage.GetCity(name) != null)
                        {
                            Console.WriteLine("City already exists.");
                            return;
                        }

                        var newCity = new CityComposite(name);
                        CityStorage.AddCity(newCity);
                        currentCityName = name;
                        Console.WriteLine($"City '{name}' created.");
                    }
                },
                {
                    1, () =>
                    {
                        Console.Write("Enter city name to open: ");
                        var name = Console.ReadLine();
                        if (CityStorage.GetCity(name) != null)
                        {
                            currentCityName = name;
                            Console.WriteLine($"City '{name}' is now open.");
                        }
                        else
                        {
                            Console.WriteLine("City not found.");
                        }
                    }
                },
                {
                    2, () =>
                    {
                        Console.Write("Enter city name to delete: ");
                        var name = Console.ReadLine();
                        if (CityStorage.GetCity(name) != null)
                        {
                            CityStorage.RemoveCity(name);
                            if (currentCityName == name) currentCityName = null;
                            Console.WriteLine($"City '{name}' deleted.");
                        }
                        else
                        {
                            Console.WriteLine("City not found.");
                        }
                    }
                },
                {
                    3, () =>
                    {
                        if (string.IsNullOrEmpty(currentCityName))
                        {
                            Console.WriteLine("No city is currently open.");
                            return;
                        }

                        var city = CityStorage.GetCity(currentCityName);
                        ConsoleUIController.MakeHeader(city.Name);
                        city.Display();
                        Console.ReadLine();
                    }
                },
                { 4, () => Environment.Exit(0) }
            };
            do
            {
                CityStorage.LoadAll();
                ConsoleUIController.RunMenu(menuActions, menuOptions);       
                CityStorage.SaveAll();
            } while (DateTime.Now < new DateTime(2077, 1, 1));
            
        }
        catch (Exception ex)
        {
            // Працює як годинничок, уже відловлювало мені помилки
            serviceExceptionHandler.Handle(ex);
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IBuildingService, BuildingService>();
        services.AddTransient<IRoadService, RoadService>();
        services.AddTransient<IUtilityService, UtilityService>();
        services.AddTransient<IQuarterService, QuarterService>();
        services.AddTransient<IDistrictService, DistrictService>();
    }
}