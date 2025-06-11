package br.edu.tp2;
import java.util.Scanner;

public class TP2_7_CalculadoraImpostoRenda {
	public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("=== CALCULADORA DE IMPOSTO DE RENDA ===");
        System.out.println();
        
        // Solicita o salário bruto anual
        System.out.print("Digite seu salário bruto anual (R$): ");
        double salarioBrutoAnual = scanner.nextDouble();
        
        // Validação do salário
        if (salarioBrutoAnual < 0) {
            System.out.println("Salário inválido! O valor não pode ser negativo.");
            scanner.close();
            return;
        }
        
        // Faixas de renda e alíquotas do IR (valores 2024/2025)
        double[] limiteFaixas = {22847.76, 33919.80, 45012.60, 55976.16};
        double[] aliquotas = {0.0, 7.5, 15.0, 22.5, 27.5};
        double[] deducoes = {0.0, 1713.58, 4257.57, 7633.51, 10432.32};
        
        // Cálculo do imposto de renda
        double impostoDevido = calcularImpostoRenda(salarioBrutoAnual, limiteFaixas, aliquotas, deducoes);
        double salarioLiquido = salarioBrutoAnual - impostoDevido;
        
        // Determina a faixa de tributação
        String faixaTributacao = determinarFaixa(salarioBrutoAnual, limiteFaixas);
        double aliquotaNominal = determinarAliquotaNominal(salarioBrutoAnual, limiteFaixas, aliquotas);
        double aliquotaEfetiva = (impostoDevido / salarioBrutoAnual) * 100;
        
        // Exibição dos resultados
        System.out.println();
        System.out.println("=== CÁLCULO DO IMPOSTO DE RENDA ===");
        System.out.printf("Salário bruto anual: R$ %.2f%n", salarioBrutoAnual);
        System.out.printf("Faixa de tributação: %s%n", faixaTributacao);
        System.out.printf("Alíquota nominal: %.1f%%%n", aliquotaNominal);
        System.out.printf("Alíquota efetiva: %.2f%%%n", aliquotaEfetiva);
        System.out.printf("Imposto devido: R$ %.2f%n", impostoDevido);
        System.out.printf("Salário líquido anual: R$ %.2f%n", salarioLiquido);
        
        // Informações mensais
        System.out.println();
        System.out.println("=== VALORES MENSAIS ===");
        System.out.printf("Salário bruto mensal: R$ %.2f%n", salarioBrutoAnual / 12);
        System.out.printf("Imposto mensal: R$ %.2f%n", impostoDevido / 12);
        System.out.printf("Salário líquido mensal: R$ %.2f%n", salarioLiquido / 12);
        
        // Detalhamento do cálculo
        System.out.println();
        System.out.println("=== DETALHAMENTO DO CÁLCULO ===");
        exibirDetalhamentoCalculo(salarioBrutoAnual, limiteFaixas, aliquotas);
        
        // Tabela de alíquotas
        System.out.println();
        System.out.println("=== TABELA DE ALÍQUOTAS IR 2024/2025 ===");
        System.out.println("Faixa de Renda Anual           | Alíquota | Dedução");
        System.out.println("-------------------------------|----------|----------");
        System.out.println("Até R$ 22.847,76              | Isento   | R$ 0,00");
        System.out.println("De R$ 22.847,77 a R$ 33.919,80| 7,5%     | R$ 1.713,58");
        System.out.println("De R$ 33.919,81 a R$ 45.012,60| 15,0%    | R$ 4.257,57");
        System.out.println("De R$ 45.012,61 a R$ 55.976,16| 22,5%    | R$ 7.633,51");
        System.out.println("Acima de R$ 55.976,16         | 27,5%    | R$ 10.432,32");
        
        // Simulação de cenários
        System.out.println();
        System.out.println("=== SIMULAÇÃO DE CENÁRIOS ===");
        if (impostoDevido > 0) {
            double economia13 = impostoDevido * 0.13; // Aproximação de economia com 13º salário
            System.out.printf("Economia aproximada com 13º salário: R$ %.2f%n", economia13);
        }
        
        // Dicas de planejamento
        if (salarioBrutoAnual > 22847.76) {
            System.out.println();
            System.out.println("=== DICAS DE PLANEJAMENTO TRIBUTÁRIO ===");
            System.out.println("• Considere contribuições para previdência privada");
            System.out.println("• Despesas médicas são dedutíveis");
            System.out.println("• Educação (até o limite legal) é dedutível");
            System.out.println("• Dependentes reduzem a base de cálculo");
        }
        
        scanner.close();
    }
    
    // Método para calcular o imposto de renda
    public static double calcularImpostoRenda(double salario, double[] limites, double[] aliquotas, double[] deducoes) {
        double imposto = 0;
        
        if (salario <= limites[0]) {
            // Isento
            imposto = 0;
        } else if (salario <= limites[1]) {
            // 7,5%
            imposto = (salario * aliquotas[1] / 100) - deducoes[1];
        } else if (salario <= limites[2]) {
            // 15%
            imposto = (salario * aliquotas[2] / 100) - deducoes[2];
        } else if (salario <= limites[3]) {
            // 22,5%
            imposto = (salario * aliquotas[3] / 100) - deducoes[3];
        } else {
            // 27,5%
            imposto = (salario * aliquotas[4] / 100) - deducoes[4];
        }
        
        return Math.max(0, imposto); // Garante que o imposto não seja negativo
    }
    
    // Método para determinar a faixa de tributação
    public static String determinarFaixa(double salario, double[] limites) {
        if (salario <= limites[0]) {
            return "Isento";
        } else if (salario <= limites[1]) {
            return "2ª faixa (7,5%)";
        } else if (salario <= limites[2]) {
            return "3ª faixa (15,0%)";
        } else if (salario <= limites[3]) {
            return "4ª faixa (22,5%)";
        } else {
            return "5ª faixa (27,5%)";
        }
    }
    
    // Método para determinar a alíquota nominal
    public static double determinarAliquotaNominal(double salario, double[] limites, double[] aliquotas) {
        if (salario <= limites[0]) {
            return 0.0;
        } else if (salario <= limites[1]) {
            return aliquotas[1];
        } else if (salario <= limites[2]) {
            return aliquotas[2];
        } else if (salario <= limites[3]) {
            return aliquotas[3];
        } else {
            return aliquotas[4];
        }
    }
    
    // Método para exibir detalhamento do cálculo
    public static void exibirDetalhamentoCalculo(double salario, double[] limites, double[] aliquotas) {
        System.out.println("Cálculo por faixas:");
        
        double impostoTotal = 0;
        
        if (salario <= limites[0]) {
            System.out.printf("• Faixa 1 (até R$ %.2f): R$ %.2f × 0%% = R$ 0,00%n", limites[0], salario);
        } else {
            // Primeira faixa (isenta)
            System.out.printf("• Faixa 1 (até R$ %.2f): R$ %.2f × 0%% = R$ 0,00%n", limites[0], limites[0]);
            
            double restante = salario - limites[0];
            
            for (int i = 1; i < limites.length && restante > 0; i++) {
                double valorFaixa = Math.min(restante, limites[i] - limites[i-1]);
                double impostoFaixa = valorFaixa * aliquotas[i] / 100;
                impostoTotal += impostoFaixa;
                
                System.out.printf("• Faixa %d (R$ %.2f a R$ %.2f): R$ %.2f × %.1f%% = R$ %.2f%n", 
                                i+1, limites[i-1], limites[i], valorFaixa, aliquotas[i], impostoFaixa);
                
                restante -= valorFaixa;
            }
            
            // Última faixa se necessário
            if (restante > 0) {
                double impostoFaixa = restante * aliquotas[aliquotas.length-1] / 100;
                impostoTotal += impostoFaixa;
                System.out.printf("• Faixa %d (acima de R$ %.2f): R$ %.2f × %.1f%% = R$ %.2f%n", 
                                aliquotas.length, limites[limites.length-1], restante, 
                                aliquotas[aliquotas.length-1], impostoFaixa);
            }
        }
        
        if (impostoTotal > 0) {
            System.out.printf("Total calculado por faixas: R$ %.2f%n", impostoTotal);
        }
    }

}
