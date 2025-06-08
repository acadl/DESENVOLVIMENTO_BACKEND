namespace TP3._11
{
    // Classe que representa um círculo
    public class Circulo
    {
        public double Raio { get; set; }

        // Método para calcular a área do círculo
        public double CalcularArea()
        {
            return Math.PI * (Raio * Raio);
        }
    }

    // Classe que representa uma esfera
    public class Esfera
    {
        public double Raio { get; set; }

        // Método para calcular o volume da esfera
        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * (Raio * Raio * Raio);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Criando um círculo e exibindo a área
            Circulo circulo = new Circulo { Raio = 5.0 };
            double area = circulo.CalcularArea();
            Console.WriteLine($"Área do círculo com raio {circulo.Raio}: {area:F2}");

            // Criando uma esfera e exibindo o volume
            Esfera esfera = new Esfera { Raio = 5.0 };
            double volume = esfera.CalcularVolume();
            Console.WriteLine($"Volume da esfera com raio {esfera.Raio}: {volume:F2}");
        }
    }
}
