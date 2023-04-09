using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeGames
{
    public class Menu
    {
      
        Games games = new Games();
        public Menu(Games game)
        {
            games=game;
        }
        public  void MenuEscolha()
        {

            bool escolhawhile = false;
            while(!escolhawhile) 
            {
                 MenuOpcoes();
                string escolha = Console.ReadLine().ToString();
                switch (escolha)
                {
                    case "1":
                           games.CriarGame();
                        break;

                    case "2":
                        games.EditarCategoria();
                        break;
                    case "3":
                        games.CriarGame();
                          break;
                   
                    case "4":
                        games.Pesquisa();
                        break;

                    case "5":
                        escolhawhile= true;
                        break;

                    default:
                        Console.WriteLine("Por gentileza digite uma das opçoes acima");
                      games.LimpaTela();
                        break;
                }
            }
        }  

        public static void MenuOpcoes()
        {
            Console.WriteLine("Escolha no menu sua Ação");
            Console.WriteLine("1-Adicionar Game\n2-Editar\n3-Deletar\n4-Pesquisar\n5-Sair\n");
        }
    }
}
