namespace dot_net_lab_4_sims_parody.Models;

/// <summary>
/// Enumeration of all available building types in the city simulation.
/// </summary>
public enum BuildingType
{
    Residential,
    Apartment,
    Office,
    School,
    University,
    Hospital,
    PoliceStation,
    FireStation,
    ShoppingMall,
    Stadium,
    Factory,
    Warehouse,
    Library,
    Museum,
    Cinema,
    Hotel,
    Restaurant,
    Bank,
    Courthouse,
    Skyscraper
}

/// <summary>
/// Specifies types of roads typically used in urban planning.
/// </summary>
public enum RoadType
{
    /// <summary>Main road with high traffic capacity, used for connecting districts or cities.</summary>
    Arterial,

    /// <summary>Smaller road connecting residential areas to arterial roads.</summary>
    Collector,

    /// <summary>Road within residential areas with low traffic and speed limits.</summary>
    Local,

    /// <summary>Multi-lane road designed for long-distance travel with limited access points.</summary>
    Highway,

    /// <summary>Smaller street primarily used in commercial or mixed-use zones.</summary>
    Commercial,

    /// <summary>Private road typically within gated communities or private properties.</summary>
    Private,

    /// <summary>Pedestrian-only street with no vehicle access.</summary>
    Pedestrian,

    /// <summary>Dedicated road or path for bicycles.</summary>
    BicycleLane,

    /// <summary>Elevated or underground road used to bypass traffic or obstacles.</summary>
    Overpass,

    /// <summary>Road used exclusively for public transport such as buses or trams.</summary>
    TransitOnly
}


/// <summary>
/// Enumeration of all available utility types in the city simulation.
/// </summary>
public enum UtilityType
{
    PowerPlant,
    SolarPanel,
    WindTurbine,
    WaterTower,
    WaterTreatmentPlant,
    SewagePlant,
    GasStation,
    CommunicationTower,
    DataCenter,
    HeatingPlant,
    WasteRecyclingCenter
}
