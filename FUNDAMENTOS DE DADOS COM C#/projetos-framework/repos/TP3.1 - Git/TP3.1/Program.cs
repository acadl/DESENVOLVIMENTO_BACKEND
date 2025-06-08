namespace TP3._1
{
   
    // 1) Declaração da classe
    public class Carro
    {
        // 2) Dois campos (propriedades) com get/set automáticos
        public string Modelo { get; set; }
        public int Ano { get; set; }

        // 3) Método que utiliza os campos
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Este carro é um {Modelo} do ano {Ano}.");
        }
    }

    class Programa
    {
        static void Main()
        {
            // 4) Criação de um objeto da classe Carro
            Carro meuCarro = new Carro
            {
                Modelo = "Fusca",
                Ano = 1972
            };

            // Chamada ao método, que usa os campos recém-preenchidos
            meuCarro.ExibirInformacoes();
        }
    }
}

