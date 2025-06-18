package contaBancariaEncapsulada;

public class ContaBancaria {
    private String titular;
    private double saldo;  // Encapsulamento: saldo é privado

    // Construtor
    public ContaBancaria(String titular) {
        this.titular = titular;
        this.saldo = 0.0;  // Saldo inicial zero
    }

    // Método para depositar
    public void depositar(double valor) {
        if (valor > 0) {
            saldo += valor;
            System.out.printf("Depósito de R$ %.2f realizado com sucesso.%n", valor);
        } else {
            System.out.println("Valor de depósito inválido.");
        }
    }

    // Método para sacar
    public void sacar(double valor) {
        if (valor > 0 && valor <= saldo) {
            saldo -= valor;
            System.out.printf("Saque de R$ %.2f realizado com sucesso.%n", valor);
        } else {
            System.out.println("Saque não permitido. Saldo insuficiente ou valor inválido.");
        }
    }

    // Método para exibir o saldo
    public void exibirSaldo() {
        System.out.printf("Titular: %s | Saldo atual: R$ %.2f%n", titular, saldo);
    }
}

