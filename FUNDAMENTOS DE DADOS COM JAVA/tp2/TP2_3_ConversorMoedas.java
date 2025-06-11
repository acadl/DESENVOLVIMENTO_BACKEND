package br.edu.tp2;
import java.util.Scanner;

public class TP2_3_ConversorMoedas {
	public static void main(String[] args) {
        // Taxas de câmbio pré-definidas (valores aproximados)
        final double TAXA_DOLAR = 5.25;    // 1 USD = 5.25 BRL
        final double TAXA_EURO = 5.70;     // 1 EUR = 5.70 BRL
        final double TAXA_LIBRA = 6.45;    // 1 GBP = 6.45 BRL
        
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("=== CONVERSOR DE MOEDAS ===");
        System.out.println();
        
        // Solicita o valor em reais
        System.out.print("Digite o valor em reais (R$): ");
        double valorReais = scanner.nextDouble();
        
        // Limpa o buffer do scanner
        scanner.nextLine();
        
        // Exibe as opções de moedas
        System.out.println();
        System.out.println("Escolha a moeda de destino:");
        System.out.println("1 - Dólar (USD)");
        System.out.println("2 - Euro (EUR)");
        System.out.println("3 - Libra (GBP)");
        System.out.print("Digite sua opção (1, 2 ou 3): ");
        
        int opcao = scanner.nextInt();
        
        double valorConvertido = 0;
        String moedaDestino = "";
        String simbolo = "";
        
        // Realiza a conversão baseada na opção escolhida
        switch (opcao) {
            case 1:
                valorConvertido = valorReais / TAXA_DOLAR;
                moedaDestino = "Dólares";
                simbolo = "USD";
                break;
            case 2:
                valorConvertido = valorReais / TAXA_EURO;
                moedaDestino = "Euros";
                simbolo = "EUR";
                break;
            case 3:
                valorConvertido = valorReais / TAXA_LIBRA;
                moedaDestino = "Libras";
                simbolo = "GBP";
                break;
            default:
                System.out.println("Opção inválida!");
                scanner.close();
                return;
        }
        
        // Exibe o resultado da conversão
        System.out.println();
        System.out.println("=== RESULTADO DA CONVERSÃO ===");
        System.out.printf("Valor original: R$ %.2f%n", valorReais);
        System.out.printf("Valor convertido: %.2f %s%n", valorConvertido, simbolo);
        System.out.printf("R$ %.2f equivalem a %.2f %s%n", valorReais, valorConvertido, moedaDestino);
        
        scanner.close();
    }

}
