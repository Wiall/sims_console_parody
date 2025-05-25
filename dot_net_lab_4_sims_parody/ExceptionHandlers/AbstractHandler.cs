namespace dot_net_lab_4_sims_parody.ExceptionHandlers;

public abstract class AbstractHandler
{
    protected AbstractHandler _next;

    public void SetNext(AbstractHandler next)
    {
        _next = next;
    }

    public void Handle(Exception ex)
    {
        if (CanHandle(ex))
            Process(ex);
        else if (_next != null)
            _next.Handle(ex);
        else
            throw ex;
    }

    protected abstract bool CanHandle(Exception ex);
    protected abstract void Process(Exception ex);
}