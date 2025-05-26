using Domain.Models;

namespace dot_net_lab_4_sims_parody.Views;

public interface IMenuView
{
    static View _nextView;

    static string? CurrentCityName { get; set; }

    static string[]? MenuOptions { get; set; }

    static Dictionary<int, Action>? MenuActions { get; set; }

    string? GetCityName();

    View GetNextView();
}

public enum View
{
    MainMenu,
    CityControlsMenu
}
