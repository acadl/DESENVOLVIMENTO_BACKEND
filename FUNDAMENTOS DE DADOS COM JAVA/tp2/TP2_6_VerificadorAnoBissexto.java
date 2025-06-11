package br.edu.tp2;
import java.util.Scanner;

public class TP2_6_VerificadorAnoBissexto {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        
	        System.out.println("=== VERIFICADOR DE ANO BISSEXTO ===");
	        System.out.println();
	        
	        // Solicita o ano ao usuário
	        System.out.print("Digite um ano: ");
	        int ano = scanner.nextInt();
	        
	        // Validação básica do ano
	        if (ano < 1) {
	            System.out.println("Ano inválido! Digite um ano válido (maior que 0).");
	            scanner.close();
	            return;
	        }
	        
	        // Variável para armazenar o resultado
	        boolean ehBissexto = false;
	        String explicacao = "";
	        
	        // Lógica para verificar se o ano é bissexto
	        // Regras dos anos bissextos:
	        // 1. Se divisível por 400 → É bissexto
	        // 2. Se divisível por 100 → NÃO é bissexto
	        // 3. Se divisível por 4 → É bissexto
	        // 4. Caso contrário → NÃO é bissexto
	        
	        if (ano % 400 == 0) {
	            ehBissexto = true;
	            explicacao = "É divisível por 400";
	        } else if (ano % 100 == 0) {
	            ehBissexto = false;
	            explicacao = "É divisível por 100, mas não por 400";
	        } else if (ano % 4 == 0) {
	            ehBissexto = true;
	            explicacao = "É divisível por 4, mas não por 100";
	        } else {
	            ehBissexto = false;
	            explicacao = "Não é divisível por 4";
	        }
	        
	        // Exibição do resultado
	        System.out.println();
	        System.out.println("=== RESULTADO ===");
	        System.out.printf("O ano %d ", ano);
	        
	        if (ehBissexto) {
	            System.out.println("É BISSEXTO! 🎉");
	        } else {
	            System.out.println("NÃO é bissexto.");
	        }
	        
	        System.out.printf("Motivo: %s%n", explicacao);
	        
	        // Informações adicionais sobre anos bissextos
	        System.out.println();
	        System.out.println("=== INFORMAÇÕES SOBRE ANOS BISSEXTOS ===");
	        
	        if (ehBissexto) {
	            System.out.println("• Este ano tem 366 dias (29 de fevereiro existe)");
	            System.out.println("• Fevereiro tem 29 dias neste ano");
	            
	            // Calcula próximo e anterior ano bissexto
	            int proximoBissexto = encontrarProximoAnoBissexto(ano);
	            int anteriorBissexto = encontrarAnteriorAnoBissexto(ano);
	            
	            if (proximoBissexto != ano) {
	                System.out.printf("• Próximo ano bissexto: %d%n", proximoBissexto);
	            }
	            if (anteriorBissexto != ano && anteriorBissexto > 0) {
	                System.out.printf("• Ano bissexto anterior: %d%n", anteriorBissexto);
	            }
	        } else {
	            System.out.println("• Este ano tem 365 dias");
	            System.out.println("• Fevereiro tem 28 dias neste ano");
	            
	            // Encontra anos bissextos próximos
	            int proximoBissexto = encontrarProximoAnoBissexto(ano);
	            int anteriorBissexto = encontrarAnteriorAnoBissexto(ano);
	            
	            System.out.printf("• Próximo ano bissexto: %d%n", proximoBissexto);
	            if (anteriorBissexto > 0) {
	                System.out.printf("• Ano bissexto anterior: %d%n", anteriorBissexto);
	            }
	        }
	        
	        // Exibe as regras dos anos bissextos
	        System.out.println();
	        System.out.println("=== REGRAS DOS ANOS BISSEXTOS ===");
	        System.out.println("1. Se o ano é divisível por 400 → É bissexto");
	        System.out.println("2. Se o ano é divisível por 100 → NÃO é bissexto");
	        System.out.println("3. Se o ano é divisível por 4 → É bissexto");
	        System.out.println("4. Caso contrário → NÃO é bissexto");
	        
	        // Exemplos práticos
	        System.out.println();
	        System.out.println("=== EXEMPLOS ===");
	        System.out.println("• 2000: Bissexto (divisível por 400)");
	        System.out.println("• 1900: NÃO bissexto (divisível por 100, mas não por 400)");
	        System.out.println("• 2024: Bissexto (divisível por 4, mas não por 100)");
	        System.out.println("• 2023: NÃO bissexto (não divisível por 4)");
	        
	        scanner.close();
	    }
	    
	    // Método para encontrar o próximo ano bissexto
	    public static int encontrarProximoAnoBissexto(int ano) {
	        for (int i = ano + 1; i <= ano + 8; i++) {
	            if (isAnoBissexto(i)) {
	                return i;
	            }
	        }
	        return ano + 4; // Fallback, nunca deve acontecer
	    }
	    
	    // Método para encontrar o ano bissexto anterior
	    public static int encontrarAnteriorAnoBissexto(int ano) {
	        for (int i = ano - 1; i >= ano - 8 && i > 0; i--) {
	            if (isAnoBissexto(i)) {
	                return i;
	            }
	        }
	        return 0; // Não encontrado
	    }
	    
	    // Método auxiliar para verificar se um ano é bissexto
	    public static boolean isAnoBissexto(int ano) {
	        return (ano % 400 == 0) || (ano % 4 == 0 && ano % 100 != 0);
	    }

}
