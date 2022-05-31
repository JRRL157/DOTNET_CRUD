using DIO.Series;
using DIO.Filmes;

namespace DIO.Series{

    class Program{

        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repoFilmes = new FilmeRepositorio();
        private static void Listar(){
            System.Console.WriteLine("Séries: !");            
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                System.Console.WriteLine("Nenhuma série foi cadastrada!");                
            }

            foreach(Serie serie in lista){
                if(!serie.retornaExcluido())
                    System.Console.WriteLine($"#ID {serie.retornaId()} | Título {serie.retornoTitulo()}");
                else
                    System.Console.WriteLine($"#ID {serie.retornaId()} | Título {serie.retornoTitulo()} (**EXCLUÍDO**)");
            }

            System.Console.WriteLine("Filmes!");

            var filmes = repoFilmes.Lista();

            if(filmes.Count == 0){
                System.Console.WriteLine("Nenhum filme foi cadastrado!");
            }

            foreach(Filme filme in filmes){
                if(!filme.retornaExcluido()){
                    System.Console.WriteLine($"#ID {filme.retornaId()} | Título {filme.retornoTitulo()}");
                }else
                    System.Console.WriteLine($"#ID {filme.retornaId()} | Título {filme.retornoTitulo()} (**EXCLUÍDO**)");
            }
        }
        private static void Inserir(){
            System.Console.WriteLine("Série(1) ou Filme(2)?");
            int esc = int.Parse(Console.ReadLine());
            while(esc != 1 && esc != 2)
                esc = int.Parse(Console.ReadLine());
            
            foreach(int x in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine($"{x} - {Enum.GetName(typeof(Genero),x)}");
            }
            
            System.Console.WriteLine("Digite o gênero:");
            int genero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Título:");
            string titulo = System.Console.ReadLine();

            System.Console.WriteLine("Ano de início:");
            int ano = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Descrição:");
            string desc = Console.ReadLine();
            
            if(esc == 2){
                System.Console.WriteLine("Oscar:");
                int oscar = int.Parse(System.Console.ReadLine());
                Filme novo = new Filme(repoFilmes.ProximoId(),(Genero)genero,titulo,desc,ano,oscar);
                repoFilmes.Insere(novo);
            }else{
                Serie nova = new Serie(repositorio.ProximoId(),(Genero)genero,titulo,desc,ano);
                repositorio.Insere(nova);
            }

        }
        private static void Atualizar(){
            System.Console.WriteLine("Série(1) ou Filme(2)?");
            int esc = int.Parse(Console.ReadLine());
            while(esc != 1 && esc != 2)
                esc = int.Parse(Console.ReadLine());
                        
            System.Console.WriteLine("Digite o ID:");
            int id = int.Parse(System.Console.ReadLine());
            
            foreach(int x in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine($"{x} - {Enum.GetName(typeof(Genero),x)}");
            }
            
            System.Console.WriteLine("Digite o gênero:");
            int genero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Título:");
            string titulo = System.Console.ReadLine();

            System.Console.WriteLine("Ano de início:");
            int ano = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Descrição:");
            string desc = Console.ReadLine();
            
            if(esc == 2){
                System.Console.WriteLine("Oscar:");
                int oscar = int.Parse(System.Console.ReadLine());
                Filme novo = new Filme(id,(Genero)genero,titulo,desc,ano,oscar);
                repoFilmes.Atualiza(id,novo);
            }else{
                Serie nova = new Serie(id,(Genero)genero,titulo,desc,ano);
                repositorio.Atualiza(id,nova);
            }

        }
        private static void Excluir(){
            System.Console.WriteLine("Série(1) ou Filme(2)?");
            int esc = int.Parse(Console.ReadLine());
            while(esc != 1 && esc != 2)
                esc = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o ID:");
            int id = int.Parse(System.Console.ReadLine());

            if(esc == 1)
                repositorio.Exclui(id);
            else{
                repoFilmes.Exclui(id);
            }
        }
        private static void Visualizar(){
            System.Console.WriteLine("Série(1) ou Filme(2)?");
            int esc = int.Parse(Console.ReadLine());
            while(esc != 1 && esc != 2)
                esc = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o ID:");
            int id = int.Parse(System.Console.ReadLine());

            if(esc == 1)
                System.Console.WriteLine(repositorio.RetornaPorId(id).ToString());
            else
                System.Console.WriteLine(repoFilmes.RetornaPorId(id).ToString());
        }
        static void Main(string[] args){
            string opcao = ObterOpcaoUsuario();

            while(opcao != "X"){
                switch(opcao){
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;                    
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                }
                opcao = ObterOpcaoUsuario();
            }
            
        }        
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            System.Console.WriteLine("------DIO Séries e Filmes-----");
            System.Console.WriteLine("1 - Listar");
            System.Console.WriteLine("2 - Inserir");
            System.Console.WriteLine("3 - Atualizar");
            System.Console.WriteLine("4 - Excluir");
            System.Console.WriteLine("5 - Visualizar");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string op = System.Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }

    }

}
