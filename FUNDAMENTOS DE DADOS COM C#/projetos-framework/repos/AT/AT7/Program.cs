namespace AT_7
{
    class ContaBancaria
    {
        // Propriedade pública: Nome do titular
        public string Titular { get; set; }

        // Atributo privado: Saldo da conta (não pode ser acessado diretamente)
        private decimal saldo;

        // Método para depositar dinheiro na conta
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
        }

        // Método para sacar dinheiro da conta
        public void Sacar(decimal valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
        }

        // Método para exibir o saldo atual
        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Banco Digital - Encapsulamento ===");

            // Criando uma conta bancária
            ContaBancaria conta = new ContaBancaria();
            conta.Titular = "João Silva";

            Console.WriteLine($"\nTitular: {conta.Titular}\n");

            // Depósito de R$500
            conta.Depositar(500);

            // Exibir saldo
            conta.ExibirSaldo();

            // Tentativa de saque de R$700 (saldo insuficiente)
            Console.WriteLine("\nTentativa de saque: R$ 700,00");
            conta.Sacar(700);

            // Saque de R$200
            conta.Sacar(200);

            // Exibir saldo final
            conta.ExibirSaldo();

            // Teste: Tentativa de depósito negativo
            Console.WriteLine("\nTentativa de depósito negativo:");
            conta.Depositar(-50);
        }
    }
}
