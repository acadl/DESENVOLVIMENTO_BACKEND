namespace TP3._2
{
    public class Ingresso
    {
        public string NomeDoShow { get; set; } // Reponsavel por armazenar o nome do show. Será essencial para identificar o evento para o qual o ingresso foi comprado.
        public double Preco { get; set; } // Reponsavel por armazenar o preço do ingresso. Será utilizado para calcular, por exemplo, a receita total do evento.
        public int QuantidadeDisponivel { get; set; } // Indica a quantidade de ingressos disponiveis para venda. Importante para controlar o estoque e evitar vendas além do limite.

    }
}
