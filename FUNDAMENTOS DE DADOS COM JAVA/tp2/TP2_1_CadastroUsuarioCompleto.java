package br.edu.tp2;
import java.util.Scanner;

public class TP2_1_CadastroUsuarioCompleto {
	 public static void main(String[] args) {
	        // 1. Criação do Scanner para ler do teclado
	        Scanner entrada = new Scanner(System.in);
	        // 2. Solicita e lê dados do usuário
	        System.out.print("Digite seu nome completo: ");
	        String nomeUsuario = entrada.nextLine().trim();
	        System.out.print("Digite sua idade: ");
	        int idade = entrada.nextInt();
	        entrada.nextLine(); // limpa a quebra de linha deixada pelo nextInt()
	        System.out.print("Digite o nome da sua mãe: ");
	        String nomeMae = entrada.nextLine().trim();
	        System.out.print("Digite o nome do seu pai: ");
	        String nomePai = entrada.nextLine().trim();
	        // 3. Exibição organizada das informações
	        System.out.println("\n--- Dados Cadastrados ---");
	        System.out.println("Nome: " + nomeUsuario);
	        System.out.println("Idade: " + idade);
	        System.out.println("Nome da Mãe: " + nomeMae);
	        System.out.println("Nome do Pai: " + nomePai);
	        // 4. Comparação dos tamanhos dos nomes
	        int tamanhoUsuario = nomeUsuario.length();
	        int tamanhoMae = nomeMae.length();
	        int tamanhoPai = nomePai.length();
	        // 5. Resultado da comparação
	        System.out.println("\n--- Comparação de Tamanho de Nomes ---");
	        if (tamanhoUsuario > tamanhoMae && tamanhoUsuario > tamanhoPai) {
	            System.out.println("Seu nome é o mais longo entre os três.");
	        } else if (tamanhoMae > tamanhoUsuario && tamanhoMae > tamanhoPai) {
	            System.out.println("O nome da sua mãe é o mais longo entre os três.");
	        } else if (tamanhoPai > tamanhoUsuario && tamanhoPai > tamanhoMae) {
	            System.out.println("O nome do seu pai é o mais longo entre os três.");
	        } else {
	            System.out.println("Há um empate no comprimento dos nomes.");
	        }
	        // 6. Fecha o Scanner (boas práticas)
	        entrada.close();
	    }

}
