namespace Domain.Interfaces;

public interface IInfrastructureComponent
{
    string Name { get; }

    int Area { get; set; }

    decimal GetMaintenanceCost();

    void Display(int indent = 0);
}