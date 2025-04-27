namespace Exercise_1._04___the_c_workshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escreva um valor para 'A': ");
            var a = int.Parse(Console.ReadLine()); // Recebe string e convert para int

            Console.WriteLine("Agora digite um valor para 'B': ");
            var b = int.Parse(Console.ReadLine());

            Console.WriteLine($"");
            Console.WriteLine($"");

            Console.WriteLine($"O valor para a é {a} e para b é {b}");

            Console.WriteLine($"Soma: {a + b}");

            Console.WriteLine($"Multiplicação: {a * b}");

            Console.WriteLine($"Subtração: {a - b}");

            Console.WriteLine($"Divisão: {a / b}");

        }
    }
}
