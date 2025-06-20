namespace AT_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Gera número aleatório entre 1 e 50
            Random random = new Random();
            int numeroSecreto = random.Next(1, 51); // Next(1, 51) gera de 1 a 50
            
            int tentativas = 5;
            bool acertou = false;
            
            Console.WriteLine("=== JOGO DE ADIVINHAÇÃO ===");
            Console.WriteLine("Tente adivinhar o número entre 1 e 50!");
            Console.WriteLine($"Você tem {tentativas} tentativas.\n");
            
            // Loop principal do jogo
            for (int i = 1; i <= tentativas; i++)
            {
                Console.Write($"Tentativa {i}/{tentativas}: Digite um número: ");
                
                try
                {
                    // Lê e converte a entrada do usuário
                    string entrada = Console.ReadLine();
                    int palpite = Convert.ToInt32(entrada);
                    
                    // Verifica se o número está no intervalo válido
                    if (palpite < 1 || palpite > 50)
                    {
                        Console.WriteLine("ERRO: O número deve estar entre 1 e 50!");
                        Console.WriteLine(); // Linha em branco para organização
                        continue; // Não conta como tentativa válida
                    }
                    
                    // Verifica se acertou
                    if (palpite == numeroSecreto)
                    {
                        Console.WriteLine($"PARABÉNS! Você acertou o número {numeroSecreto}!");
                        Console.WriteLine($"Você conseguiu em {i} tentativa(s)!");
                        acertou = true;
                        break;
                    }
                    else if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é MAIOR que o seu palpite!");
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é MENOR que o seu palpite!");
                    }
                    
                    // Mostra quantas tentativas restam
                    if (i < tentativas)
                    {
                        Console.WriteLine($"Tentativas restantes: {tentativas - i}");
                    }
                    
                    Console.WriteLine(); // Linha em branco para organização
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: Por favor, digite apenas números inteiros!");
                    Console.WriteLine(); // Linha em branco para organização
                    // Não decrementa o contador de tentativas para entrada inválida
                    i--; // Volta uma tentativa para não penalizar o usuário
                }
                catch (OverflowException)
                {
                    Console.WriteLine("ERRO: Número muito grande! Digite um número entre 1 e 50.");
                    Console.WriteLine(); // Linha em branco para organização
                    i--; // Volta uma tentativa para não penalizar o usuário
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO inesperado: {ex.Message}");
                    Console.WriteLine(); // Linha em branco para organização
                    i--; // Volta uma tentativa para não penalizar o usuário
                }
            }
            
            // Resultado final
            if (!acertou)
            {
                Console.WriteLine("Suas tentativas acabaram!");
                Console.WriteLine($"O número secreto era: {numeroSecreto}");
            }
            
            Console.WriteLine("\nObrigado por jogar! Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
