package sistemaFuncionarios;

public class SistemaFuncionarios {
    public static void main(String[] args) {
        // Criando os funcionários
        Gerente gerente = new Gerente("Maria Gerente", 5000.0);
        Estagiario estagiario = new Estagiario("João Estagiário", 2000.0);

        // Exibindo os salários finais
        System.out.println("=== Salários Finais ===");
        gerente.exibirSalarioFinal();
        estagiario.exibirSalarioFinal();
    }
}

