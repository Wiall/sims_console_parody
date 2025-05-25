using Application.Validation;

namespace dot_net_lab_4_sims_parody.ExceptionHandlers;

public class ServiceExceptionHandler : AbstractHandler
{
    protected override bool CanHandle(Exception ex)
    {
        return ex is ServiceException;
    }

    protected override void Process(Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
        // можна додавати більше логіки
    }
}