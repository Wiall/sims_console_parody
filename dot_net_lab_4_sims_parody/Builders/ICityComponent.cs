namespace dot_net_lab_4_sims_parody.Builders;

public interface ICityComponent
{
    void Display(int depth = 0);
    decimal GetMaintenanceCost();
    int GetTotalArea();
}
