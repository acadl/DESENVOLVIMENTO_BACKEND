namespace TP3._8
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
}

