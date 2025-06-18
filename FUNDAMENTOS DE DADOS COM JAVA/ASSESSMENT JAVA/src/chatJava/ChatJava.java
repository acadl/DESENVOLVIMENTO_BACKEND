package chatJava;
import java.util.Scanner;

public class ChatJava {
	public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] mensagens = new String[10];  // Array para armazenar até 10 mensagens (5 de cada usuário)

        // Solicitação dos nomes dos usuários
        System.out.print("Digite o nome do primeiro usuário: ");
        String usuario1 = scanner.nextLine();

        System.out.print("Digite o nome do segundo usuário: ");
        String usuario2 = scanner.nextLine();

        System.out.println("\n--- Início da Conversa ---");

        // Envio alternado das mensagens
        for (int i = 0; i < 10; i++) {
            String usuarioAtual = (i % 2 == 0) ? usuario1 : usuario2;
            System.out.print(usuarioAtual + ", digite sua mensagem: ");
            String mensagem = scanner.nextLine();

            mensagens[i] = usuarioAtual + ": " + mensagem;
        }

        // Exibição do histórico de mensagens
        System.out.println("\n===== Histórico de Mensagens =====");
        for (String m : mensagens) {
            System.out.println(m);
        }

        // Mensagem de despedida
        System.out.println("\nObrigado por utilizarem o sistema! Boa sorte para vocês! 🚀");

        scanner.close();
    }
}
