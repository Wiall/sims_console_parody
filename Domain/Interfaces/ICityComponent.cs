namespace Domain.Interfaces;

public interface ICityComponent
{
    void Display(int depth = 0);
    decimal GetMaintenanceCost();
    int GetTotalArea();
}