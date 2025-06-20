namespace AT_6
{
    class Aluno
    {
        // Propriedades da classe Aluno
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public double MediaNotas { get; set; }

        // Método para exibir os dados do aluno
        public void ExibirDados()
        {
            Console.WriteLine("\n=== Dados do Aluno ===");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
        }

        // Método para verificar a aprovação
        public string VerificarAprovacao()
        {
            if (MediaNotas >= 7.0)
            {
                return "Aprovado";
            }
            else
            {
                return "Reprovado";
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Cadastro de Aluno ===");

            // Criando um objeto Aluno com dados de exemplo
            Aluno aluno = new Aluno();

            // Preenchendo os dados
            aluno.Nome = "João Silva";
            aluno.Matricula = "2025001";
            aluno.Curso = "Análise e Desenvolvimento de Sistemas";
            aluno.MediaNotas = 8.2;

            // Exibindo os dados
            aluno.ExibirDados();

            // Verificando e exibindo a aprovação
            string resultado = aluno.VerificarAprovacao();
            Console.WriteLine($"Situação: {resultado}");
        }
    }
}
