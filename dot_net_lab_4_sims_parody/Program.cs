using System.Data.SqlTypes;
using Application.Interfaces;
using Application.Services;
using Domain.Composite;
using dot_net_lab_4_sims_parody.ExceptionHandlers;
using dot_net_lab_4_sims_parody.Presentation;
using dot_net_lab_4_sims_parody.UIHolding;
using dot_net_lab_4_sims_parody.Views;
using Microsoft.Extensions.DependencyInjection;

namespace dot_net_lab_4_sims_parody;

internal static class Program
{
    public static void Main()
    {
        var serviceExceptionHandler = new ServiceExceptionHandler();
        var outOfRangeExceptionHandler = new OutOfRangeExceptionHandler();
        var genericExceptionHandler = new GenericExceptionHandler();
        var notFoundExceptionHandler = new NotFoundExceptionHandler();

        serviceExceptionHandler.SetNext(outOfRangeExceptionHandler);
        outOfRangeExceptionHandler.SetNext(notFoundExceptionHandler);
        notFoundExceptionHandler.SetNext(genericExceptionHandler);
        
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var buildingService = serviceProvider.GetRequiredService<IBuildingService>();
        var roadService = serviceProvider.GetRequiredService<IRoadService>();
        var utilityService = serviceProvider.GetRequiredService<IUtilityService>();
        var quarterService = serviceProvider.GetRequiredService<IQuarterService>();
        var districtService = serviceProvider.GetRequiredService<IDistrictService>();

        var cityController = new CityController(buildingService, districtService, quarterService, roadService, utilityService);
        string? currentCityName = null;
        DistrictComposite? currentDistrict = null;
        QuarterComposite? currentQuarter = null;
        var nextView = View.MainMenu;
        IMenuView view;

        do
        {
            try
            {
                switch (nextView)
                {
                    case View.MainMenu:
                        view = new MainMenuView(currentCityName);
                        CityStorage.LoadAll();
                        ConsoleUIController.RunMenu(MainMenuView.MenuActions, MainMenuView.MenuOptions); // Було б класно викликати тут view, але я не хочу це імплементувати
                        CityStorage.SaveAll();
                        currentCityName = view.GetName();
                        nextView = view.GetNextView();
                        break;
                    case View.CityControlsMenu:
                        view = new CityControlsMenuView(currentCityName, currentDistrict, cityController);
                        CityStorage.LoadAll();
                        ConsoleUIController.RunMenu(CityControlsMenuView.MenuActions, CityControlsMenuView.MenuOptions);
                        CityStorage.SaveAll();
                        currentCityName = view.GetName();
                        currentDistrict = view.GetDistrict();
                        nextView = view.GetNextView();
                        break;
                    case View.DistrictMenu:
                        view = new DistrictMenuView(currentCityName,
                            CityStorage.GetCity(currentCityName).Districts.FirstOrDefault(currentDistrict),
                            currentQuarter, cityController);
                        CityStorage.LoadAll();
                        ConsoleUIController.RunMenu(DistrictMenuView.MenuActions, DistrictMenuView.MenuOptions);
                        CityStorage.SaveAll();
                        currentCityName = view.GetName();
                        currentDistrict = view.GetDistrict();
                        currentQuarter = view.GetQuarter();
                        nextView = view.GetNextView();
                        break;
                    case View.QuarterMenu:
                        view = new QuarterMenuView(currentCityName,
                            CityStorage.GetCity(currentCityName).Districts.FirstOrDefault(currentDistrict),
                            currentQuarter, cityController);
                        CityStorage.LoadAll();
                        ConsoleUIController.RunMenu(QuarterMenuView.MenuActions, QuarterMenuView.MenuOptions);
                        CityStorage.SaveAll();
                        currentCityName = view.GetName();
                        currentDistrict = view.GetDistrict();
                        currentQuarter = view.GetQuarter();
                        nextView = view.GetNextView();
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                serviceExceptionHandler.Handle(ex);
            }
        } while (DateTime.Now < new DateTime(2077, 1, 1));
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