namespace dot_net_lab_4_sims_parody.Interfaces;

public interface IInfrastructureComponent
{
    string Name { get; }
    int Area { get; }
    decimal GetMaintenanceCost();
    void Display(int indent = 0);
}
