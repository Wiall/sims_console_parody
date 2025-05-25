namespace dot_net_lab_4_sims_parody.ExceptionHandlers;
public class GenericExceptionHandler : AbstractHandler
{
    protected override bool CanHandle(Exception ex) => true;

    protected override void Process(Exception ex)
    {
        Console.WriteLine($"Невідома помилка: {ex.Message}");
        // можна додавати більше логіки
    }
}
