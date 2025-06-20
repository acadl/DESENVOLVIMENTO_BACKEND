namespace AT_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Contagem de Dias até o Próximo Aniversário ===");

            DateTime dataNascimento;
            bool dataValida = false;

            // Solicita a data de nascimento e valida o formato
            do
            {
                Console.Write("Digite sua data de nascimento (formato: dd/MM/yyyy): ");
                string entrada = Console.ReadLine();

                if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                {
                    dataValida = true;
                }
                else
                {
                    Console.WriteLine("Data inválida! Tente novamente.");
                }
            } while (!dataValida);

            DateTime hoje = DateTime.Today;

            // Cria a data do próximo aniversário no ano atual
            DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

            // Se o aniversário deste ano já passou, calcula para o próximo ano
            if (proximoAniversario < hoje)
            {
                proximoAniversario = proximoAniversario.AddYears(1);
            }

            // Calcula a diferença em dias
            TimeSpan diferenca = proximoAniversario - hoje;
            int diasFaltando = diferenca.Days;

            Console.WriteLine($"\nFaltam {diasFaltando} dias para o seu próximo aniversário!");

            // Mensagem especial se faltar menos de 7 dias
            if (diasFaltando < 7)
            {
                Console.WriteLine("Está chegando! Que venha a festa!");
            }
        }
    }
}
