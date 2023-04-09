using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace LojaDeGames
{
    public class Games
    {
        List<Games> gamesList = new List<Games>();
        public int Id { get; set; }
        public string Nome;
        public string Descricao;
        public int FaixaEtaria;
        public double Valor;
        public bool Status;
        private List<Games> listaDeGames = new List<Games>();
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Games()
        {
            Id = 1;
            Nome = "";
            Descricao = "";
            Status = true;
        }
        public string CriarGame()
        { 
            Games game = new Games();
            game.Id = listaDeGames.Count;
            Console.WriteLine("Digite o nome do jogo");
            game.Nome = Console.ReadLine();
            var verifica = VerificarLetras(game.Nome);
            while (verifica == false)
            {
                Console.WriteLine("o campo nome não pode conter números ou ser nulo, por favor digitem o nome do game");
                Console.WriteLine("Digite o nome do jogo");
                game.Nome = Console.ReadLine();
                verifica = VerificarLetras(game.Nome);
            }

            Console.WriteLine("Descrição: ");
            game.Descricao = Console.ReadLine();

            Console.WriteLine("Faixa etaria do jogo :");
            string idadePermitida = Console.ReadLine();
            bool ehNumero = int.TryParse(idadePermitida, out int faixaEtaria);

            if (ehNumero == false || faixaEtaria > 18)
            {
                Console.WriteLine("valor invalido, a maior faixa etaria é 18");
                LimpaTela();
                return "";
            }

            game.FaixaEtaria = faixaEtaria;
            game.Status = true;
            Console.WriteLine("digite o valor do game");
            string preco = Console.ReadLine();
            bool valorGame = double.TryParse(preco, out double valor);
            if (valorGame == false)
            {
                Console.WriteLine("É necessario informar o valor do jogo");
                return "";
            }
            else if (valor > 350)
            {
                Console.WriteLine("o maior valor que um jogo pode ter é ate 350 R$");
                return "";
            }

            game.Valor = valor;
            game.DataCriacao = DateTime.Now;


            Console.WriteLine($"O id é : {game.Id}\n" +
                $"O nome do Game é : {game.Nome}\n" +
                $"Faixa Etaria de idade: {game.FaixaEtaria}\n" +
                $"O status do game : {game.Status}\n" +
                $"Descrição do Game: {game.Descricao}\n" +
                $"Data de criação : {game.DataCriacao}\n" +
                $"O valor do jogo é : {game.Valor}\n");
            listaDeGames.Add(game);
            LimpaTela();

            return "";

        }


        public string EditarCategoria()
        {

            Console.WriteLine($"Qual Categoria voce deseja editar? digite o id ou nome");
            var escolhaNomeOunumero = Console.ReadLine();
            var game = listaDeGames.FirstOrDefault(g => g.Id.ToString().Equals(escolhaNomeOunumero));

            while (game == null)
            {
                Console.WriteLine("Nome ou id incorreto por favor digite um nome ou id valido");
                Console.WriteLine($"Qual Categoria voce deseja editar? digite o id ou nome");
                var escolha = Console.ReadLine();
                game = listaDeGames.FirstOrDefault(g => g.Id.ToString().Equals(escolha));
            }

            Console.WriteLine($"Voce esta atualizando o game {game.Nome}, Digite o novo nome do Game");
            game.Nome = Console.ReadLine();
            var eh = VerificarLetras(game.Nome);
            while (eh == false)
            {
                Console.WriteLine("o campo nome não pode conter numeros ou ser nulo por favor digite um nome valido");
                game.Nome = Console.ReadLine();
                eh = VerificarLetras(game.Nome);
            }

            Console.WriteLine("Descrição: ");
            game.Descricao = Console.ReadLine();

            Console.WriteLine("Faixa etaria do jogo :");
            string idadePermitida = Console.ReadLine();
            bool ehNumero = int.TryParse(idadePermitida, out int faixaEtaria);
            if (ehNumero == false || faixaEtaria > 18)
            {
                Console.WriteLine("valor invalido, as faixa etarias de games vai de 0 a 18 ");
                LimpaTela();
                return "";
            }

            game.FaixaEtaria = faixaEtaria;

            Console.WriteLine("digite o valor do game");
            string preco = Console.ReadLine();
            bool valorGame = double.TryParse(preco, out double valor);
            if (valorGame == false)
            {
                Console.WriteLine("É necessario informar o valor do  jogo");
                return "";
            }
            else if (valor > 350)
            {
                Console.WriteLine("o maior valor que um jogo pode ter é ate 350 R$");
                return "";
            }
            game.Valor = valor;

            Console.WriteLine("Digite se a categoria esta ativa ou inativa");
            string inserindoValorDoStatus = Console.ReadLine();
            bool conversãoDoValor = bool.TryParse(inserindoValorDoStatus, out bool valorDoStatus);
            if (conversãoDoValor == true)
            {
                game.Status = valorDoStatus;
            }
            else
            {
                Console.WriteLine("o valor do status deve ser true or falso");
                LimpaTela();
                return "";
            }

            game.DataAtualizacao = DateTime.Now;


            Console.WriteLine($"O id é : {game.Id}\n" +
                $"O nome do Game é : {game.Nome}\n" +
                $"Faixa Etaria de idade: {game.FaixaEtaria}\n" +
                $"O status do game : {game.Status}\n" +
                $"Data de criação : {game.DataCriacao}\n" +
                $"A data de atualização foi: {game.DataAtualizacao} \n");
            LimpaTela();

            return "";
        }
        public bool VerificarLetras(string nome)
        {

            int regex = Regex.Matches(nome, @"[a-zA-Zá-úÁ-Ú' ']").Count;
            if (!String.IsNullOrWhiteSpace(nome) && nome.Length > 0 && nome.Length <= 50 && regex == nome.Length)
            {
                return true;
            }
            return false;
        }
        public void LimpaTela()
        {
            Console.ReadKey();
            Console.Clear();
        }

        public string Pesquisa()
        {
            bool escolhaWhile = false;
            while (escolhaWhile==false)
            {
                Console.WriteLine("Escolha por qual das opções voce deseja pesquisar\n" +
                                  "1-nome\n2-ID\n3-status\n");
                string pesquisa = Console.ReadLine();
                switch (pesquisa)
                {
                
                    case "1":

                        Console.WriteLine("Digite o nome do game");
                        string nome = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(nome)) return "";

                       IEnumerable<Games> pesquisaPorNome = listaDeGames.Where(g => g.Nome.StartsWith(nome));
                        if (pesquisaPorNome == null || !pesquisaPorNome.Any())
                        {
                            List<Games> lista = new List<Games>() { };
                            Console.WriteLine("nenhum game foi encontrado", lista);
                            LimpaTela();
                            return "";
                        }


                        foreach (Games g in pesquisaPorNome)
                        {
                            Console.WriteLine($"O id do Game é :{g.Id}\n" +
                                              $"O nome do Game é: {g.Nome}\n" +
                                              $"A Descrição: {g.Descricao}\n" +
                                             $"Cadastrado no sistema em : {g.DataCriacao}\n" +
                                             $"O status do game está : {g.Status}\n" +
                                             $"===================================================================\n");
                        };
                                       
                        LimpaTela();
                        escolhaWhile=true;
                        break;

                    case "2":
                        Console.WriteLine("Digite o ID que deseja visualizar");
                        string valorID = Console.ReadLine();
                        int id = int.Parse(valorID);
                        var pesquisaporID = listaDeGames.FirstOrDefault(g => g.Id == id);
                        if (pesquisaporID == null)
                        {
                            List<Games> lista = new List<Games> { };
                            Console.WriteLine("nenhum game foi encontrado", lista);
                            return "";
                        }
                        Console.WriteLine($"O id do Game é :{pesquisaporID.Id}\n" +
                                              $"O nome do Game é: {pesquisaporID.Nome}\n" +
                                              $"A Descrição: {pesquisaporID.Descricao}\n" +
                                             $"Cadastrado no sistema em : {pesquisaporID.DataCriacao}\n" +
                                             $"$\"Atualizado no sistema em : {pesquisaporID.DataAtualizacao}\n" +
                                             $"O status do game está : {pesquisaporID.Status}\n" +
                                             $"===================================================================\n");

                        LimpaTela();
                        escolhaWhile = true;
                        break;


                    case "3":
                        Console.WriteLine("digite o status que deseja visualizar");
                        string valorDoStatus = Console.ReadLine();
                        bool? statusConvert = bool.TryParse(valorDoStatus, out bool status);
                        if (statusConvert == null) return "";

                        var pesquisaPorStatus = listaDeGames.Where(g => g.Status == status);
                        if (pesquisaPorStatus == null || !pesquisaPorStatus.Any())
                        {

                            List<Games> lista = new List<Games> { };
                            Console.WriteLine("nenhum game foi encontrado", lista);
                            
                            return "";
                        }
                        
                        foreach(Games g in pesquisaPorStatus)
                        {
                            Console.WriteLine($"O id do Game é :{g.Id}\n" +
                                              $"O nome do Game é: {g.Nome}\n" +
                                              $"A Descrição: {g.Descricao}\n" +
                                             $"Cadastrado no sistema em : {g.DataCriacao}\n" +
                                             $"Atualizado no sistema em : {g.DataAtualizacao}\n" +
                                             $"O status do game está : {g.Status}\n"+
                                             $"===================================================================\n");
                        }
                        LimpaTela();
                        escolhaWhile = true;
                        break;

                    default:
                        Console.WriteLine("por favor digite uma das tres opções");
                        break;

                }
            }
                return "";

        }

        public string DeletarCategoria()
        {
            Console.WriteLine("Digite o id do game que voce deseja deletar");
            string pesquisarPorId= Console.ReadLine();
            bool convert = int.TryParse(pesquisarPorId, out int id);
            if(convert== false)
            {
                Console.WriteLine("Por favor digite um id valido");
                return "";
            };
            var listaDelete= listaDeGames.FirstOrDefault(g => g.Id == id);
            listaDeGames.Remove(listaDelete);
            Console.WriteLine($"O item {listaDelete.Nome} foi deletado");
            LimpaTela();
            return "";
        }
    }

}