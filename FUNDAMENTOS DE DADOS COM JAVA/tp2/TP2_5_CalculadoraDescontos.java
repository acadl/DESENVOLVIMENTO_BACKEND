package br.edu.tp2;
import java.util.Scanner;

public class TP2_5_CalculadoraDescontos {
	  public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        
	        System.out.println("=== CALCULADORA DE DESCONTOS PROGRESSIVOS ===");
	        System.out.println();
	        
	        // Solicita o valor da compra
	        System.out.print("Digite o valor da compra (R$): ");
	        double valorCompra = scanner.nextDouble();
	        
	        // Validação do valor
	        if (valorCompra < 0) {
	            System.out.println("Valor inválido! O valor da compra não pode ser negativo.");
	            scanner.close();
	            return;
	        }
	        
	        // Variáveis para armazenar os resultados
	        double percentualDesconto = 0;
	        double valorDesconto = 0;
	        double valorFinal = 0;
	        String faixaDesconto = "";
	        
	        // Estrutura condicional para determinar o desconto
	        if (valorCompra > 1000) {
	            percentualDesconto = 10.0;
	            faixaDesconto = "Acima de R$ 1.000,00";
	        } else if (valorCompra >= 500 && valorCompra <= 1000) {
	            percentualDesconto = 5.0;
	            faixaDesconto = "Entre R$ 500,00 e R$ 1.000,00";
	        } else {
	            percentualDesconto = 0.0;
	            faixaDesconto = "Abaixo de R$ 500,00";
	        }
	        
	        // Cálculo do desconto e valor final
	        valorDesconto = valorCompra * (percentualDesconto / 100);
	        valorFinal = valorCompra - valorDesconto;
	        
	        // Exibição dos resultados
	        System.out.println();
	        System.out.println("=== RESULTADO DO CÁLCULO ===");
	        System.out.printf("Valor original da compra: R$ %.2f%n", valorCompra);
	        System.out.printf("Faixa de desconto: %s%n", faixaDesconto);
	        System.out.printf("Percentual de desconto: %.1f%%%n", percentualDesconto);
	        System.out.printf("Valor do desconto: R$ %.2f%n", valorDesconto);
	        System.out.printf("Valor final da compra: R$ %.2f%n", valorFinal);
	        
	        // Informações adicionais sobre economia
	        if (valorDesconto > 0) {
	            System.out.println();
	            System.out.println("=== INFORMAÇÕES ADICIONAIS ===");
	            System.out.printf("Você economizou: R$ %.2f%n", valorDesconto);
	            System.out.printf("Economia percentual: %.1f%%%n", percentualDesconto);
	        } else {
	            System.out.println();
	            System.out.println("=== DICA ===");
	            System.out.printf("Para obter 5%% de desconto, você precisa comprar pelo menos R$ %.2f a mais.%n", 
	                            500.00 - valorCompra);
	        }
	        
	        // Exibe tabela de descontos
	        System.out.println();
	        System.out.println("=== TABELA DE DESCONTOS ===");
	        System.out.println("Valor da Compra          | Desconto");
	        System.out.println("-------------------------|----------");
	        System.out.println("Abaixo de R$ 500,00      | 0%");
	        System.out.println("R$ 500,00 a R$ 1.000,00  | 5%");
	        System.out.println("Acima de R$ 1.000,00     | 10%");
	        
	        scanner.close();
	    }

}
