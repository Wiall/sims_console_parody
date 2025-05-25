using Application.Validation;

namespace dot_net_lab_4_sims_parody.ExceptionHandlers;

public class OutOfRangeExceptionHandler : AbstractHandler
{
    protected override bool CanHandle(Exception ex)
    {
        return ex is OutOfRangeException;
    }

    protected override void Process(Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
        // можна додавати більше логіки
    }
}