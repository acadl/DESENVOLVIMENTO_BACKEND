package simulacaoLoteria;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.Random;

public class jogoLoteria {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        Set<Integer> numerosSorteados = new HashSet<>();
	        Random random = new Random();

	        // Gerando 6 números aleatórios entre 1 e 60, sem repetição
	        while (numerosSorteados.size() < 6) {
	            int numero = random.nextInt(60) + 1;
	            numerosSorteados.add(numero);
	        }

	        // Pedindo 6 números ao usuário
	        Set<Integer> numerosUsuario = new HashSet<>();
	        System.out.println("Digite 6 números entre 1 e 60 (sem repetir):");

	        while (numerosUsuario.size() < 6) {
	            System.out.print("Número " + (numerosUsuario.size() + 1) + ": ");
	            int numero = scanner.nextInt();

	            if (numero < 1 || numero > 60) {
	                System.out.println("Número inválido! Digite um número entre 1 e 60.");
	            } else if (numerosUsuario.contains(numero)) {
	                System.out.println("Número repetido! Digite outro número.");
	            } else {
	                numerosUsuario.add(numero);
	            }
	        }

	        // Verificando quantos acertos
	        Set<Integer> acertos = new HashSet<>(numerosUsuario);
	        acertos.retainAll(numerosSorteados);  // Mantém apenas os números que estão nos dois conjuntos

	        // Exibindo resultados
	        System.out.println("\nNúmeros sorteados: " + numerosSorteados);
	        System.out.println("Seus números: " + numerosUsuario);
	        System.out.println("Você acertou " + acertos.size() + " número(s): " + acertos);

	        scanner.close();
	    }
}
