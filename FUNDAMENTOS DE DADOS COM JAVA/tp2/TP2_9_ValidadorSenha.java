package br.edu.tp2;
import java.util.Scanner;

public class TP2_9_ValidadorSenha {
	public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String senhaCadastrada;

        // Loop para garantir que a senha cadastrada não seja vazia
        do {
            System.out.print("Cadastre sua senha (não pode ser vazia): ");
            senhaCadastrada = scanner.nextLine();
            if (senhaCadastrada.isEmpty()) {
                System.out.println("Senha inválida. Por favor, tente novamente.");
            }
        } while (senhaCadastrada.isEmpty());

        String senhaDigitada;

        do {
            System.out.print("Digite a senha para acessar: ");
            senhaDigitada = scanner.nextLine();

            if (!senhaDigitada.equals(senhaCadastrada)) {
                System.out.println("Senha incorreta. Tente novamente.");
            }
        } while (!senhaDigitada.equals(senhaCadastrada));

        System.out.println("Senha correta! Acesso concedido.");
        scanner.close();
    }
}
