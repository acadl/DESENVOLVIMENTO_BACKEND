package sistemaFuncionarios;

public class Estagiario extends Funcionario {

    public Estagiario(String nome, double salarioBase) {
        super(nome, salarioBase);
    }

    @Override
    public double calcularSalarioFinal() {
        return salarioBase * 0.9; // 10% de desconto
    }
}

