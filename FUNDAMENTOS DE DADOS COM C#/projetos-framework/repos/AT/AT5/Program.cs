using System.Globalization;

namespace AT_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Contagem Regressiva para a Formatura ===");

            // Data de formatura definida manualmente
            DateTime dataFormatura = new DateTime(2029, 04, 30);

            DateTime dataAtual;
            bool dataValida = false;

            // Entrada e validação da data atual
            do
            {
                Console.Write("Digite a data atual (formato: dd/MM/yyyy): ");
                string entrada = Console.ReadLine();

                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataAtual))
                {
                    if (dataAtual > DateTime.Today)
                    {
                        Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                    }
                    else
                    {
                        dataValida = true;
                    }
                }
                else
                {
                    Console.WriteLine("Data inválida! Por favor, insira no formato correto.");
                }

            } while (!dataValida);

            // Verifica se a data de formatura já passou
            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("\nParabéns! Você já deveria estar formado!");
            }
            else
            {
                // Calcula a diferença exata em anos, meses e dias
                int anos = dataFormatura.Year - dataAtual.Year;
                int meses = dataFormatura.Month - dataAtual.Month;
                int dias = dataFormatura.Day - dataAtual.Day;

                // Ajusta caso os dias ou meses sejam negativos
                if (dias < 0)
                {
                    meses--;
                    dias += DateTime.DaysInMonth(dataAtual.Year, (dataAtual.Month == 12 ? 1 : dataAtual.Month + 1));
                }

                if (meses < 0)
                {
                    anos--;
                    meses += 12;
                }

                Console.WriteLine($"\nFaltam {anos} ano(s), {meses} mês(es) e {dias} dia(s) para sua formatura!");

                // Se faltar menos de 6 meses (menos de 180 dias aproximadamente)
                TimeSpan diferencaTotal = dataFormatura - dataAtual;
                if (diferencaTotal.TotalDays <= 180)
                {
                    Console.WriteLine("\nA reta final chegou! Prepare-se para a formatura!");
                }
            }
        }
    }
}
