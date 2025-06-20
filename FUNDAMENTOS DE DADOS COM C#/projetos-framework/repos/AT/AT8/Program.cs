namespace AT_8
{
    // Classe base: Funcionario
    class Funcionario
    {
        // Propriedades comuns a todos os funcionários
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBase { get; set; }

        // Construtor
        public Funcionario(string nome, string cargo, decimal salarioBase)
        {
            Nome = nome;
            Cargo = cargo;
            SalarioBase = salarioBase;
        }

        // Método para calcular o salário (pode ser sobrescrito pelas subclasses)
        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }

        // Exibe os dados do funcionário
        public void ExibirSalario()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: R$ {CalcularSalario():F2}");
            Console.WriteLine();
        }
    }

    // Subclasse: Gerente (herda de Funcionario)
    class Gerente : Funcionario
    {
        // Construtor da subclasse
        public Gerente(string nome, decimal salarioBase)
            : base(nome, "Gerente", salarioBase)
        {
        }

        // Sobrescrevendo o método para incluir o bônus de 20%
        public override decimal CalcularSalario()
        {
            return SalarioBase * 1.20m; // Adiciona 20% de bônus
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Cadastro de Funcionários - Herança ===\n");

            // Criando um funcionário comum
            Funcionario funcionario = new Funcionario("Carlos Souza", "Analista", 3000);
            funcionario.ExibirSalario();

            // Criando um gerente
            Gerente gerente = new Gerente("Mariana Lima", 5000);
            gerente.ExibirSalario();
        }
    }
}
