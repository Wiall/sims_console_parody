using Application.Validation;

namespace dot_net_lab_4_sims_parody.ExceptionHandlers;

public class NotFoundExceptionHandler : AbstractHandler
{
    protected override bool CanHandle(Exception ex)
    {
        return ex is NotFoundException;
    }

    protected override void Process(Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
        Console.WriteLine("\nPress any button to continue...");
        Console.ReadKey();
    }
}
