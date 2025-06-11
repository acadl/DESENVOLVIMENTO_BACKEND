package br.edu.tp2;
import java.util.Scanner;

public class TP2_12_ContadorDePalavras {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);

	        System.out.print("Digite uma frase: ");
	        String frase = scanner.nextLine();

	        // Remove espaços extras no início, no fim e entre palavras
	        frase = frase.trim();

	        // Verifica se a frase está vazia
	        if (frase.isEmpty()) {
	            System.out.println("A frase está vazia. Número de palavras: 0");
	        } else {
	            // Divide a frase em palavras usando espaço como separador
	            String[] palavras = frase.split("\\s+"); // Expressão regular: um ou mais espaços

	            // Laço de repetição para mostrar as palavras individualmente (opcional)
	            System.out.println("Palavras encontradas:");
	            for (String palavra : palavras) {
	                System.out.println("- " + palavra);
	            }

	            System.out.println("Total de palavras: " + palavras.length);
	        }

	        scanner.close();
	    }
}
