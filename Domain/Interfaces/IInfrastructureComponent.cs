namespace Domain.Interfaces;

public interface IInfrastructureComponent
{
    string Name { get; }
    int Area { get; }
    decimal GetMaintenanceCost();
    void Display(int indent = 0);
}
