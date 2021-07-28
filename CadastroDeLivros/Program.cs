using System;

namespace CadastroDeLivros
{
    class Program
    {
        static LivrosRepositorio repositorio = new LivrosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = OpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        AtualizarLivros();
                        break;
                    case "4":
                        ExcluirLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = OpcaoUsuario();
            }

            Console.ReadLine();
        }

        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("---- CADASTRO DE LIVROS ----");
            Console.WriteLine();
            Console.WriteLine("O que deseja fazer: ");

            Console.WriteLine("1- Listar Liros Cadastrados ");
            Console.WriteLine("2- Cadastrar novo Livro ");
            Console.WriteLine("3- Atualizar livro ");
            Console.WriteLine("4- Excluir livros ");
            Console.WriteLine("5- Visualizar livro ");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();


            return opcao;
        }

        private static void ListarLivros()
        {
            Console.WriteLine("Listar Livros");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não foi encontrado nenhum cadastro");
                return;
            }
            foreach (var livro in lista)
            {
                var livroExcluido = livro.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (livroExcluido ? "--> Livro Excluido" : ""));
            }
        }

        private static void InserirLivro()
        {
            Console.WriteLine("Cadastrar Livro");

            Console.Write("Título: ");
            string lTitulo = Console.ReadLine();

            Console.Write("Autor: ");
            string lAutor = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Assunto)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Assunto), i));
            }
            Console.Write("Digite o assunto entre as opções acima: ");
            int lAssunto = int.Parse(Console.ReadLine());

            Console.Write("Numero de paginas: ");
            int lNumPaginas = int.Parse(Console.ReadLine());

            Console.Write("Peso: ");
            float lPeso = float.Parse(Console.ReadLine());

            Console.Write("Ano de Lançamento: ");
            int lLancamento = int.Parse(Console.ReadLine());

            Livro novoLivro = new Livro(id: repositorio.ProximoId(),
                                        titulo: lTitulo,
                                        autor: lAutor,
                                        assunto: (Assunto)lAssunto,
                                        numPagina: lNumPaginas,
                                        peso: lPeso,
                                        lancamento: lLancamento);

            repositorio.Inserir(novoLivro);
        }

        private static void AtualizarLivros()
        {
            Console.Write("ID do Livro: ");
            int idLivroAlterar = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            string lTitulo = Console.ReadLine();

            Console.Write("Autor: ");
            string lAutor = Console.ReadLine();

            foreach (int i in Enum.GetValues(typeof(Assunto)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Assunto), i));
            }
            Console.Write("Digite o assunto entre as opções acima: ");
            int lAssunto = int.Parse(Console.ReadLine());

            Console.Write("Numero de paginas: ");
            int lNumPaginas = int.Parse(Console.ReadLine());

            Console.Write("Peso: ");
            float lPeso = float.Parse(Console.ReadLine());

            Console.Write("Ano de Lançamento: ");
            int lLancamento = int.Parse(Console.ReadLine());

            Livro atualizaLivro = new Livro(id: idLivroAlterar,
                                        titulo: lTitulo,
                                        autor: lAutor,
                                        assunto: (Assunto)lAssunto,
                                        numPagina: lNumPaginas,
                                        peso: lPeso,
                                        lancamento: lLancamento);

            repositorio.Atualizar(idLivroAlterar, atualizaLivro);

        }


        private static void ExcluirLivro()
        {
            Console.Write("Qual Id deseja excluir: ");
            int idLivroExcluir = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir: S para excluir - N para voltar ao menu");
            string op = Console.ReadLine();
            if(op == "S")
            {
                repositorio.Excluir(idLivroExcluir);
            }
            else
            {
                ExcluirLivro();
            }
           
        }

        private static void VisualizarLivro()
        {
            Console.Write("Qual Id do livro que deseja visualizar: ");
            int idLivro = int.Parse(Console.ReadLine());

            var livro = repositorio.RetornaPorId(idLivro);

            Console.WriteLine(livro);
        }

    }
}
