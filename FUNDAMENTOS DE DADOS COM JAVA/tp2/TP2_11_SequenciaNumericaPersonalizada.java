package br.edu.tp2;
import java.util.Scanner;

public class TP2_11_SequenciaNumericaPersonalizada {
	  public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);

	        System.out.print("Digite o valor inicial: ");
	        int valorInicial = scanner.nextInt();

	        System.out.print("Digite o incremento: ");
	        int incremento = scanner.nextInt();

	        // Validação simples para evitar incrementos <= 0
	        if (incremento <= 0) {
	            System.out.println("Incremento deve ser um número positivo maior que zero.");
	            scanner.close();
	            return;
	        }

	        System.out.print("Sequência: ");

	        int valorAtual = valorInicial;
	        boolean primeiro = true;

	        // Gera e exibe a sequência enquanto valorAtual <= 100
	        while (valorAtual <= 100) {
	            if (!primeiro) {
	                System.out.print(", ");
	            }
	            System.out.print(valorAtual);
	            primeiro = false;

	            valorAtual += incremento;
	        }

	        System.out.println(); // pula linha no final da sequência
	        scanner.close();
	    }
}
