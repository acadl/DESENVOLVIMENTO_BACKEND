package contaBancariaEncapsulada;

public class BancoApp {
    public static void main(String[] args) {
        // Criando a conta
        ContaBancaria conta = new ContaBancaria("Carlos Silva");

        // Operações bancárias
        conta.exibirSaldo();
        conta.depositar(1000.0);
        conta.exibirSaldo();
        conta.sacar(300.0);
        conta.exibirSaldo();
        conta.sacar(800.0);  // Tentando sacar mais do que o saldo disponível
        conta.exibirSaldo();
    }
}

