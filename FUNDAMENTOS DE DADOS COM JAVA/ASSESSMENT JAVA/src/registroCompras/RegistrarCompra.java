package registroCompras;
import java.io.FileWriter;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.Scanner;

public class RegistrarCompra {
	 public static void main(String[] args) {
	        Scanner scanner = new Scanner(System.in);
	        String nomeArquivo = "compras.txt";

	        try {
	            FileWriter escritor = new FileWriter(nomeArquivo);

	            // Cadastro de 3 compras
	            for (int i = 1; i <= 3; i++) {
	                System.out.println("Cadastro da compra " + i + ":");

	                System.out.print("Produto: ");
	                String produto = scanner.nextLine();

	                System.out.print("Quantidade: ");
	                int quantidade = Integer.parseInt(scanner.nextLine());

	                System.out.print("Preço unitário: ");
	                double precoUnitario = Double.parseDouble(scanner.nextLine());

	                // Escrevendo no arquivo
	                escritor.write(produto + ";" + quantidade + ";" + precoUnitario + "\n");
	            }

	            escritor.close();
	            System.out.println("\nAs compras foram salvas no arquivo '" + nomeArquivo + "'.\n");

	        } catch (IOException e) {
	            System.out.println("Erro ao gravar o arquivo: " + e.getMessage());
	        }

	        // Agora, lendo e exibindo o conteúdo do arquivo
	        System.out.println("=== Compras Registradas ===");

	        try {
	            BufferedReader leitor = new BufferedReader(new FileReader(nomeArquivo));
	            String linha;

	            while ((linha = leitor.readLine()) != null) {
	                String[] dados = linha.split(";");
	                String produto = dados[0];
	                int quantidade = Integer.parseInt(dados[1]);
	                double precoUnitario = Double.parseDouble(dados[2]);
	                double total = quantidade * precoUnitario;

	                System.out.printf("Produto: %s | Quantidade: %d | Preço Unitário: R$ %.2f | Total: R$ %.2f%n",
	                        produto, quantidade, precoUnitario, total);
	            }

	            leitor.close();
	        } catch (IOException e) {
	            System.out.println("Erro ao ler o arquivo: " + e.getMessage());
	        }

	        scanner.close();
	    }
}
