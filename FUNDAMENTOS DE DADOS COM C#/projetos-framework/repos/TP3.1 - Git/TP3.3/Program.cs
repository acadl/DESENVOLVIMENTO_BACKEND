namespace TP3._3
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
  
}
