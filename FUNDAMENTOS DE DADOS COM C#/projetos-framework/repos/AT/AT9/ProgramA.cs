namespace AT_9_parte_A_
{
    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public void Exibir()
        {
            Console.WriteLine($"Produto: {Nome} | Quantidade: {Quantidade} | Preço: R$ {Preco:F2}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Produto[] estoque = new Produto[5];
            int contador = 0;
            int opcao;

            do
            {
                Console.WriteLine("\n=== Controle de Estoque ===");
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
                        if (contador >= 5)
                        {
                            Console.WriteLine("Limite de produtos atingido!");
                            break;
                        }

                        Produto p = new Produto();
                        Console.Write("Nome do produto: ");
                        p.Nome = Console.ReadLine();

                        Console.Write("Quantidade: ");
                        if (!int.TryParse(Console.ReadLine(), out int qtd))
                        {
                            Console.WriteLine("Quantidade inválida!");
                            break;
                        }
                        p.Quantidade = qtd;

                        Console.Write("Preço unitário: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
                        {
                            Console.WriteLine("Preço inválido!");
                            break;
                        }
                        p.Preco = preco;

                        estoque[contador] = p;
                        contador++;
                        Console.WriteLine("Produto cadastrado com sucesso!");
                        break;

                    case 2:
                        Console.WriteLine("\n--- Produtos Cadastrados ---");
                        if (contador == 0)
                        {
                            Console.WriteLine("Nenhum produto cadastrado.");
                        }
                        else
                        {
                            for (int i = 0; i < contador; i++)
                            {
                                estoque[i].Exibir();
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Encerrando...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 3);
        }
    }
}
