package sistemaFuncionarios;

public class Funcionario {
    protected String nome;
    protected double salarioBase;

    public Funcionario(String nome, double salarioBase) {
        this.nome = nome;
        this.salarioBase = salarioBase;
    }

    public double calcularSalarioFinal() {
        return salarioBase; // Por padrão, apenas retorna o salário base
    }

    public void exibirSalarioFinal() {
        System.out.printf("Funcionário: %s | Salário Final: R$ %.2f%n", nome, calcularSalarioFinal());
    }
}
