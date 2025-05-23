namespace dot_net_lab_4_sims_parody.UIHolding;

public static class MenuUI
{
    public static void MakeHeader(string str) => Console.WriteLine(string.Concat(new string('-', 46),"\n\t\t", str, "\n", new string('-', 46)));
}