package br.edu.tp2;
import java.util.Random;
import java.util.Scanner;

public class TP2_10_JogoAdivinhacao {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        Random random = new Random();

	        // Número secreto entre 1 e 100
	        int numeroSecreto = random.nextInt(100) + 1;

	        int palpite;
	        int tentativas = 0;

	        System.out.println("Bem-vindo ao Jogo de Adivinhação!");
	        System.out.println("Tente adivinhar o número secreto entre 1 e 100.");

	        do {
	            System.out.print("Digite seu palpite: ");
	            // Validação simples para entrada numérica
	            while (!scanner.hasNextInt()) {
	                System.out.println("Entrada inválida! Por favor, digite um número inteiro.");
	                scanner.next(); // descarta a entrada inválida
	                System.out.print("Digite seu palpite: ");
	            }
	            palpite = scanner.nextInt();
	            tentativas++;

	            if (palpite > numeroSecreto) {
	                System.out.println("Seu palpite é maior que o número secreto. Tente um número menor.");
	            } else if (palpite < numeroSecreto) {
	                System.out.println("Seu palpite é menor que o número secreto. Tente um número maior.");
	            } else {
	                System.out.println("Parabéns! Você acertou o número secreto em " + tentativas + " tentativas.");
	            }

	        } while (palpite != numeroSecreto);

	        scanner.close();
	    }
}
