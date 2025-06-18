package simuladorEmprestimoBancario;
import java.util.Scanner;

public class SimularEmprestimo {
	
		public static void main(String[] args) {
			Scanner scanner = new Scanner(System.in);
			// Entrada de dados
			System.out.print("Digite o nome do cliente: ");
			String nome = scanner.nextLine();        
			System.out.print("Digite o valor do empréstimo (em R$): ");
			double valorEmprestimo = scanner.nextDouble();
			int parcelas;
			do {
				System.out.print("Digite o número de parcelas (mínimo 6, máximo 48): ");
				parcelas = scanner.nextInt();
				if (parcelas < 6 || parcelas > 48) {
					System.out.println("Número de parcelas inválido. Tente novamente.");
					}
				} while (parcelas < 6 || parcelas > 48);
			double taxaJurosMensal = 0.03;
			// 3% ao mês
			// Cálculo do valor total com juros (fórmula de juros simples)
			double valorTotal = valorEmprestimo * Math.pow(1 + taxaJurosMensal, parcelas);
			// Cálculo da parcela mensal        
			double valorParcela = valorTotal / parcelas;        
			// Exibição dos resultados        
			System.out.println("\nSimulação de Empréstimo:");        
			System.out.println("Cliente: " + nome);        
			System.out.printf("Valor Total a Pagar: R$ %.2f%n", valorTotal);        
			System.out.printf("Valor de Cada Parcela (%dx): R$ %.2f%n", parcelas, valorParcela);        
			scanner.close();    
			}
	}

