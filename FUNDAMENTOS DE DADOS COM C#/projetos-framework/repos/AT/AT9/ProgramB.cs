namespace AT_9_parte_B_
{
    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public string ParaLinhaDeArquivo()
        {
            return $"{Nome};{Quantidade};{Preco:F2}";
        }

        public static Produto DeLinhaDeArquivo(string linha)
        {
            string[] partes = linha.Split(';');
            if (partes.Length != 3)
                throw new Exception("Formato de linha inválido.");

            return new Produto
            {
                Nome = partes[0],
                Quantidade = int.Parse(partes[1]),
                Preco = decimal.Parse(partes[2])
            };
        }

        public void Exibir()
        {
            Console.WriteLine($"Produto: {Nome} | Quantidade: {Quantidade} | Preço: R$ {Preco:F2}");
        }
    }
    internal class Program
    {
        const string CaminhoArquivo = "estoque.txt";
        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n=== Controle de Estoque (Arquivo) ===");
                Console.WriteLine("1 - Inserir Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        InserirProduto();
                        break;

                    case 2:
                        ListarProdutos();
                        break;

                    case 3:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 3);
        }

        static void InserirProduto()
        {
            Produto p = new Produto();

            Console.Write("Nome do produto: ");
            p.Nome = Console.ReadLine();

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int qtd))
            {
                Console.WriteLine("Quantidade inválida!");
                return;
            }
            p.Quantidade = qtd;

            Console.Write("Preço unitário: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            p.Preco = preco;

            try
            {
                using (StreamWriter sw = File.AppendText(CaminhoArquivo))
                {
                    sw.WriteLine(p.ParaLinhaDeArquivo());
                }
                Console.WriteLine("Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        static void ListarProdutos()
        {
            if (!File.Exists(CaminhoArquivo))
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            string[] linhas = File.ReadAllLines(CaminhoArquivo);

            if (linhas.Length == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("\n--- Produtos Cadastrados ---");
            foreach (string linha in linhas)
            {
                try
                {
                    Produto p = Produto.DeLinhaDeArquivo(linha);
                    p.Exibir();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler produto: {ex.Message}");
                }
            }
        }
    }
}
