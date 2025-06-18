package cadastroVeiculo;

public class CadastrarVeiculo {
    public static void main(String[] args) {
        // Criando dois veículos com dados fictícios
        Veiculo veiculo1 = new Veiculo("ABC-1234", "Toyota Corolla", 2018, 45000.0);
        Veiculo veiculo2 = new Veiculo("XYZ-5678", "Honda Civic", 2020, 32000.0);

        // Exibindo os detalhes iniciais
        System.out.println("=== Detalhes Iniciais dos Veículos ===");
        veiculo1.exibirDetalhes();
        veiculo2.exibirDetalhes();

        // Registrando viagens
        veiculo1.registrarViagem(150.5);
        veiculo2.registrarViagem(230.0);

        // Exibindo os detalhes após as viagens
        System.out.println("\n=== Detalhes Após as Viagens ===");
        veiculo1.exibirDetalhes();
        veiculo2.exibirDetalhes();
    }
}
