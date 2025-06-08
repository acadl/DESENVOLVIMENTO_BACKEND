namespace TP3._6
{
    public class Ingresso
    {
        public string NomeDoShow { get; set; } // Reponsavel por armazenar o nome do show. Será essencial para identificar o evento para o qual o ingresso foi comprado.
        public double Preco { get; set; } // Reponsavel por armazenar o preço do ingresso. Será utilizado para calcular, por exemplo, a receita total do evento.
        public int QuantidadeDisponivel { get; set; } // Indica a quantidade de ingressos disponiveis para venda. Importante para controlar o estoque e evitar vendas além do limite.

        // Construtor com parâmetros
        public Ingresso(string nomeDoShow, double preco, int quantidadeDisponivel)
        {
            NomeDoShow = nomeDoShow;
            Preco = preco;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        public void AlterarPreco(double novoPreco)
        {
            Console.WriteLine("Alterando o preço do ingresso de R$ " + Preco + " para R$ " + novoPreco);
            Preco = novoPreco; // Atualiza o preço do ingresso com o novo valor fornecido.
        }
        public void AlterarQuantidade(int novaQuantidade)
        {
            Console.WriteLine("Alterando a quantidade de ingressos de " + QuantidadeDisponivel + " para " + novaQuantidade + " unidades ");
            QuantidadeDisponivel = novaQuantidade; // Atualiza quantidade de ingressos com o novo valor fornecido.
        }
        public void ExibirInformacoes()
        {
            Console.WriteLine($"O show {NomeDoShow}, cujo ingresso terá o valor de R$ {Preco} terá {QuantidadeDisponivel} ingressos disponiveis.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um ingresso com propriedades (uso de set)
            Ingresso ingresso1 = new Ingresso("Rock in Rio", 350.00, 1000);

            // Exibindo informações iniciais
            ingresso1.ExibirInformacoes();

            ingresso1.AlterarPreco(400.00);         // Chama o método para alterar o preço
            ingresso1.AlterarQuantidade(950);       // Chama o método para alterar a quantidade

            // Confirmando as alterações
            ingresso1.ExibirInformacoes();

            // Explicação sobre construtores
            Console.WriteLine("\nExplicação:");
            Console.WriteLine("O uso de construtores facilita a criação de objetos ao permitir que todos os valores essenciais");
            Console.WriteLine("sejam definidos já no momento da instância, evitando a necessidade de chamadas separadas para cada propriedade.");

        }
    }

}


