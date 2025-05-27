namespace dot_net_lab_4_sims_parody.UIHolding;

public static class ConsoleUIController
{
    public static void MakeHeader(string str)
    {
        Console.WriteLine(string.Concat(new string('-', 46), "\n\t\t", str, "\n", new string('-', 46)));
    }

    public static int MenuHold(string[] options)
    {
        var selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            MakeHeader("Menu");

            for (var i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine($"\t{options[i]}");
                Console.ResetColor();
            }

            var keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = selectedIndex == 0 ? options.Length - 1 : selectedIndex - 1;
            else if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % options.Length;
        } while (key != ConsoleKey.Enter);

        return selectedIndex;
    }

    public static void RunMenu(Dictionary<int, Action> menuActions, string[] options)
    {
        var selectedIndex = MenuHold(options);

        if (menuActions.TryGetValue(selectedIndex, out var action))
        {
            Console.Clear();
            action.Invoke();
        }
        else
        {
            Console.WriteLine("Wrong input.");
        }

        Console.WriteLine("\nPress any button to continue...");
        Console.ReadKey();
    }
}