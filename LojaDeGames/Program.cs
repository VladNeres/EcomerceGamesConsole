using LojaDeGames;

public class Program
{
    public static void Main(string [] args)
    {
        try
        {
            Games games= new Games();
           Menu menu = new Menu(games);

            menu.MenuEscolha();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}