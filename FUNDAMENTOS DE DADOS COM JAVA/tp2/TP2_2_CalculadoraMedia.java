package br.edu.tp2;
import java.util.Scanner;

public class TP2_2_CalculadoraMedia {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        // Entrada das 4 notas bimestrais
        System.out.print("Digite a primeira nota: ");
        double nota1 = scanner.nextDouble();

        System.out.print("Digite a segunda nota: ");
        double nota2 = scanner.nextDouble();

        System.out.print("Digite a terceira nota: ");
        double nota3 = scanner.nextDouble();

        System.out.print("Digite a quarta nota: ");
        double nota4 = scanner.nextDouble();

        // Cálculo da média aritmética
        double media = (nota1 + nota2 + nota3 + nota4) / 4.0;

        // Verificação das faixas de aprovação, recuperação ou reprovação
        String mensagem;
        if (media >= 7.0) {
            mensagem = String.format("Parabéns! Sua média foi %.1f. Você está APROVADO.", media);
        } else if (media >= 5.0) {
            mensagem = String.format("Atenção! Sua média foi %.1f. Você está em RECUPERAÇÃO.", media);
        } else {
            mensagem = String.format("Sua média foi %.1f. Infelizmente, você foi REPROVADO.", media);
        }

        // Exibição do resultado
        System.out.println(mensagem);

        scanner.close();
    }

}
