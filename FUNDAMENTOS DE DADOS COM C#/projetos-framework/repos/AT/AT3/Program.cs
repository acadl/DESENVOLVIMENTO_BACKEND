namespace AT_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numero1, numero2, resultado = 0;
            int opcao;
            bool entradaValida = false;

            Console.WriteLine("=== Calculadora Simples ===");

            // Entrada do primeiro número com validação
            do
            {
                Console.Write("Digite o primeiro número: ");
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out numero1))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            } while (!entradaValida);

            entradaValida = false; // Reinicia para o próximo número

            // Entrada do segundo número com validação
            do
            {
                Console.Write("Digite o segundo número: ");
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out numero2))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            } while (!entradaValida);

            // Exibe o menu de operações
            Console.WriteLine("\nEscolha a operação:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");

            // Entrada da operação com validação
            do
            {
                Console.Write("Digite a opção (1-4): ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcao) && opcao >= 1 && opcao <= 4)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Escolha entre 1, 2, 3 ou 4.");
                    entradaValida = false;
                }
            } while (!entradaValida);

            // Realiza a operação escolhida
            switch (opcao)
            {
                case 1:
                    resultado = numero1 + numero2;
                    Console.WriteLine($"Resultado da soma: {resultado}");
                    break;
                case 2:
                    resultado = numero1 - numero2;
                    Console.WriteLine($"Resultado da subtração: {resultado}");
                    break;
                case 3:
                    resultado = numero1 * numero2;
                    Console.WriteLine($"Resultado da multiplicação: {resultado}");
                    break;
                case 4:
                    // Tratamento de divisão por zero
                    if (numero2 != 0)
                    {
                        resultado = numero1 / numero2;
                        Console.WriteLine($"Resultado da divisão: {resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Erro! Não é possível dividir por zero.");
                    }
                    break;
            }
        }
    }
}
