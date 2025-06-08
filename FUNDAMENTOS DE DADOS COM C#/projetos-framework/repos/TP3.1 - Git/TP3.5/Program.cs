namespace TP3._5
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
            // Criando um ingresso com propriedades (uso de set)
            Ingresso ingresso1 = new Ingresso();
            ingresso1.NomeDoShow = "Rock in Rio";
            ingresso1.Preco = 350.00;
            ingresso1.QuantidadeDisponivel = 1000;

            // Exibindo informações iniciais
            ingresso1.ExibirInformacoes();

            // Alterando valores diretamente via propriedades (uso de set)
            ingresso1.Preco = 200.00;
            ingresso1.QuantidadeDisponivel = 900;

            // Mostrando valores com get
            Console.WriteLine("Novo preço acessado com get: R$ " + ingresso1.Preco);
            Console.WriteLine("Nova quantidade acessada com get: " + ingresso1.QuantidadeDisponivel + " unidades");

            // Confirmando as alterações
            ingresso1.ExibirInformacoes();

            // Explicação
            Console.WriteLine("\nExplicação:");
            Console.WriteLine("As propriedades 'get' e 'set' permitem acessar e modificar os atributos da classe de forma segura e organizada.");
            Console.WriteLine("Mesmo sem encapsulamento total, elas facilitam a leitura e manutenção do código.");
        }
    }

}

