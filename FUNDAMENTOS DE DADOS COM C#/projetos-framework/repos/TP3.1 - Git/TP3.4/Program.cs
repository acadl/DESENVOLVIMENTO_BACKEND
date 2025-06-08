namespace TP3._4
{
    public class Ingresso
    {
        public string NomeDoShow { get; set; } // Reponsavel por armazenar o nome do show. Será essencial para identificar o evento para o qual o ingresso foi comprado.
        public double Preco { get; set; } // Reponsavel por armazenar o preço do ingresso. Será utilizado para calcular, por exemplo, a receita total do evento.
        public int QuantidadeDisponivel { get; set; } // Indica a quantidade de ingressos disponiveis para venda. Importante para controlar o estoque e evitar vendas além do limite.
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
            // Criando um ingresso
            Ingresso ingresso1 = new Ingresso
            {
                NomeDoShow = "Rock in Rio",
                Preco = 350.00,
                QuantidadeDisponivel = 1000
            };

            // Exibindo as informações iniciais
            ingresso1.ExibirInformacoes();

            // Alterando preço e quantidade
            ingresso1.AlterarPreco(400.00);
            ingresso1.AlterarQuantidade(950);

            // Exibindo novamente para ver as alterações
            ingresso1.ExibirInformacoes();
        }
    }

}
