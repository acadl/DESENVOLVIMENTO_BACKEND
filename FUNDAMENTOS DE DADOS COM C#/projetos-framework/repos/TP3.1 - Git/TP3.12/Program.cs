namespace TP3._12
{
    // Classe Circulo com método de cálculo de área
    public class Circulo
    {
        public double Raio { get; set; }

        public double CalcularArea()
        {
            return Math.PI * (Raio * Raio);
        }
    }

    // Classe Esfera com método de cálculo de volume
    public class Esfera
    {
        public double Raio { get; set; }

        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * (Raio * Raio * Raio);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar e testar Circulo
            Circulo circulo = new Circulo();
            circulo.Raio = 3.0;
            double area = circulo.CalcularArea();
            Console.WriteLine($"Área do círculo com raio {circulo.Raio}: {area:F2}");

            // Criar e testar Esfera
            Esfera esfera = new Esfera();
            esfera.Raio = 5.0;
            double volume = esfera.CalcularVolume();
            Console.WriteLine($"Volume da esfera com raio {esfera.Raio}: {volume:F2}");
        }
    }
}
