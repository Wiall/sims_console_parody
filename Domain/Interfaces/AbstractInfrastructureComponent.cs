namespace Domain.Interfaces;

public abstract class AbstractInfrastructureComponent
{
    public string Name { get; set; } = string.Empty;

    public int Area { get; set; } = 1;

    public abstract decimal GetMaintenanceCost();

    public abstract void Display(int indent = 0);
}