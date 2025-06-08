namespace TP3._9
{
    public class Matricula
    {
        public string NomeDoAluno { get; set; }
        public string Curso { get; set; }
        public string Situacao { get; set; }
        public string DataInicial { get; set; }
        public int NumeroMatricula { get; set; }

        public void Trancar()
        {
            Situacao = "Trancada";
            Console.WriteLine("Alterando o status da situação para " + Situacao);
        }
        public void Reativar()
        {
            Situacao = "Ativada";
            Console.WriteLine("Alterando o status da situação para " + Situacao);
        }
        public void ExibirInformacoes()
        {
            Console.WriteLine($"O aluno {NomeDoAluno} está inscrito no curso {Curso} sob a matrícula {NumeroMatricula}.");
            Console.WriteLine($"Status da matrícula: {Situacao}. Data de início: {DataInicial}.");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar uma matrícula
            Matricula matricula1 = new Matricula
            {
                NomeDoAluno = "João da Silva",
                Curso = "Engenharia de Software",
                Situacao = "Ativa",
                DataInicial = "08/06/2025",
                NumeroMatricula = 123456
            };

            // Exibir informações iniciais
            matricula1.ExibirInformacoes();

            // Trancar matrícula
            matricula1.Trancar();
            matricula1.ExibirInformacoes();

            // Reativar matrícula
            matricula1.Reativar();
            matricula1.ExibirInformacoes();
        }
    }
}


