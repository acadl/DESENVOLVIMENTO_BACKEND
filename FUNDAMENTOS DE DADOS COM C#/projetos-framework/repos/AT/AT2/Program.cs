namespace AT_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Solicita o nome completo ao usuário
            Console.Write("Digite seu nome completo: ");
            string nome = Console.ReadLine();

            // Converte a string de entrada em um array de caracteres
            char[] caracteres = nome.ToCharArray();

            // Array para armazenar o resultado
            char[] resultado = new char[caracteres.Length];

            // Laço para percorrer cada caractere
            for (int i = 0; i < caracteres.Length; i++)
            {
                char c = caracteres[i];

                // Verifica se é uma letra
                if (char.IsLetter(c))
                {
                    // Verifica se é letra maiúscula
                    if (char.IsUpper(c))
                    {
                        // Faz o deslocamento e garante que continue no intervalo 'A' a 'Z'
                        resultado[i] = (char)(((c - 'A' + 2) % 26) + 'A');
                    }
                    // Se for minúscula
                    else if (char.IsLower(c))
                    {
                        // Faz o deslocamento e garante que continue no intervalo 'a' a 'z'
                        resultado[i] = (char)(((c - 'a' + 2) % 26) + 'a');
                    }
                }
                else
                {
                    // Se for espaço ou outro caractere, mantém como está
                    resultado[i] = c;
                }
            }

            // Converte o array de volta para string e exibe o resultado
            string nomeCifrado = new string(resultado);
            Console.WriteLine("Nome cifrado: " + nomeCifrado);
        }
    }
}
