package validadorDeSenha;
import java.util.Scanner;

public class validarSenha {
	public static void main (String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.print("Digite seu nome");
		String nome = scanner.nextLine();
		
		String senha;
		boolean senhaValida = false;
		
		while (!senhaValida) {
			System.out.print("Digite sua senha:");
			senha = scanner.nextLine();
			
			String erro = validarSenha(senha);
			
			if(erro.isEmpty()) {
				System.out.println("Senha cadastrada com sucesso!");
				senhaValida = true;
				
			} else {
				System.out.println("Erro: " + erro);
				System.out.println("Tente novamente.\n");
			}
		}
		
		scanner.close();
	}
	
	public static String validarSenha(String senha) {
		if(senha.length()<8) {
			return "A senha deve ter no minimo 8 caracteres.";
		}
		
		if(!senha.matches(".*[A-Z].*")) {
			return "A senha deve conter pelo menos uma letra maiúscula.";
		}
		
		if(!senha.matches(".*\\d.*")) {
			return "A senha deve conter pelo menos um número.";
		}
		
		if(!senha.matches(".*[@#$%^&+=!].*")) {
			return "A senha deve conter pelo menos um caractere especial (@, #, $, %, etc.).";
		}
		
		return "";
	}
}
