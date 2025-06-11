package br.edu.tp2;
import java.util.Scanner;
import java.util.Calendar;


public class TP2_4_CalculadoraIdadeDias {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        
	        System.out.println("=== CALCULADORA DE IDADE EM DIAS ===");
	        System.out.println();
	        
	        // Solicita a data de nascimento
	        System.out.print("Digite o dia do seu nascimento (1-31): ");
	        int diaNasc = scanner.nextInt();
	        
	        System.out.print("Digite o mês do seu nascimento (1-12): ");
	        int mesNasc = scanner.nextInt();
	        
	        System.out.print("Digite o ano do seu nascimento: ");
	        int anoNasc = scanner.nextInt();
	        
	        // Validação básica da data
	        if (!isDataValida(diaNasc, mesNasc, anoNasc)) {
	            System.out.println("Data inválida! Verifique os valores inseridos.");
	            scanner.close();
	            return;
	        }
	        
	        // Obtém a data atual usando Calendar
	        Calendar cal = Calendar.getInstance();
	        int diaAtual = cal.get(Calendar.DAY_OF_MONTH);
	        int mesAtual = cal.get(Calendar.MONTH) + 1; // Calendar.MONTH é 0-based
	        int anoAtual = cal.get(Calendar.YEAR);
	        
	        // Verifica se a data de nascimento não é futura
	        if (anoNasc > anoAtual || 
	            (anoNasc == anoAtual && mesNasc > mesAtual) ||
	            (anoNasc == anoAtual && mesNasc == mesAtual && diaNasc > diaAtual)) {
	            System.out.println("A data de nascimento não pode ser no futuro!");
	            scanner.close();
	            return;
	        }
	        
	        // Calcula a idade em dias
	        long totalDias = calcularDiasVividos(diaNasc, mesNasc, anoNasc, diaAtual, mesAtual, anoAtual);
	        
	        // Exibe os resultados
	        System.out.println();
	        System.out.println("=== RESULTADO ===");
	        System.out.printf("Data de nascimento: %02d/%02d/%d%n", diaNasc, mesNasc, anoNasc);
	        System.out.printf("Data atual: %02d/%02d/%d%n", diaAtual, mesAtual, anoAtual);
	        System.out.printf("Sua idade é: %d dias%n", totalDias);
	        
	        // Informações adicionais
	        long anos = totalDias / 365;
	        long semanas = totalDias / 7;
	        long meses = totalDias / 30; // Aproximação
	        
	        System.out.println();
	        System.out.println("=== INFORMAÇÕES ADICIONAIS ===");
	        System.out.printf("Aproximadamente: %d anos%n", anos);
	        System.out.printf("Aproximadamente: %d meses%n", meses);
	        System.out.printf("Aproximadamente: %d semanas%n", semanas);
	        
	        scanner.close();
	    }
	    
	    // Método para calcular os dias vividos entre duas datas
	    public static long calcularDiasVividos(int diaNasc, int mesNasc, int anoNasc, 
	                                          int diaAtual, int mesAtual, int anoAtual) {
	        long totalDias = 0;
	        
	        // Se for o mesmo ano
	        if (anoNasc == anoAtual) {
	            return calcularDiasNoAno(diaNasc, mesNasc, diaAtual, mesAtual, anoAtual);
	        }
	        
	        // Dias restantes no ano de nascimento
	        totalDias += diasRestantesNoAno(diaNasc, mesNasc, anoNasc);
	        
	        // Dias dos anos completos entre nascimento e atual
	        for (int ano = anoNasc + 1; ano < anoAtual; ano++) {
	            totalDias += isAnoBissexto(ano) ? 366 : 365;
	        }
	        
	        // Dias decorridos no ano atual
	        totalDias += diasDecorridosNoAno(diaAtual, mesAtual, anoAtual);
	        
	        return totalDias;
	    }
	    
	    // Calcula dias no mesmo ano
	    public static long calcularDiasNoAno(int diaNasc, int mesNasc, int diaAtual, int mesAtual, int ano) {
	        long diasNascimento = calcularDiasAteData(diaNasc, mesNasc, ano);
	        long diasAtual = calcularDiasAteData(diaAtual, mesAtual, ano);
	        return diasAtual - diasNascimento;
	    }
	    
	    // Calcula dias restantes no ano de nascimento
	    public static long diasRestantesNoAno(int dia, int mes, int ano) {
	        long totalDiasAno = isAnoBissexto(ano) ? 366 : 365;
	        long diasAteNascimento = calcularDiasAteData(dia, mes, ano);
	        return totalDiasAno - diasAteNascimento;
	    }
	    
	    // Calcula dias decorridos no ano atual
	    public static long diasDecorridosNoAno(int dia, int mes, int ano) {
	        return calcularDiasAteData(dia, mes, ano);
	    }
	    
	    // Calcula quantos dias se passaram desde o início do ano até a data especificada
	    public static long calcularDiasAteData(int dia, int mes, int ano) {
	        int[] diasPorMes = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
	        
	        // Ajusta fevereiro para anos bissextos
	        if (isAnoBissexto(ano)) {
	            diasPorMes[1] = 29;
	        }
	        
	        long totalDias = 0;
	        
	        // Soma os dias dos meses anteriores
	        for (int i = 0; i < mes - 1; i++) {
	            totalDias += diasPorMes[i];
	        }
	        
	        // Soma os dias do mês atual
	        totalDias += dia;
	        
	        return totalDias;
	    }
	    
	    // Método para validar se a data é válida
	    public static boolean isDataValida(int dia, int mes, int ano) {
	        // Verifica ano válido
	        if (ano < 1900 || ano > 2100) {
	            return false;
	        }
	        
	        // Verifica mês válido
	        if (mes < 1 || mes > 12) {
	            return false;
	        }
	        
	        // Verifica dia válido
	        if (dia < 1 || dia > 31) {
	            return false;
	        }
	        
	        // Verifica dias específicos por mês
	        int[] diasPorMes = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
	        
	        // Ajusta fevereiro para anos bissextos
	        if (isAnoBissexto(ano)) {
	            diasPorMes[1] = 29;
	        }
	        
	        return dia <= diasPorMes[mes - 1];
	    }
	    
	    // Método para verificar se o ano é bissexto
	    public static boolean isAnoBissexto(int ano) {
	        return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);
	    }


}
