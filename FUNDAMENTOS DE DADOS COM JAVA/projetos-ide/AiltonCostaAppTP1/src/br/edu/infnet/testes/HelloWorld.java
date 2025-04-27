package br.edu.infnet.testes;
import java.util.Scanner;

public class HelloWorld {
	public static void main(String[] args) {
		Scanner leitura = new Scanner(System.in);
		
		
		//VENDAS DE PRODUTOS
		
		final float VALOR_DESCONTO = 0.8F; // definida como constante, não pode sofrer alteração
		
		System.out.print("Entre com a descrição do produto: ");
		String descricao = leitura.nextLine();

		System.out.print("Entre com a quantidade do produto: ");
		int quantidade = leitura.nextInt();

		System.out.print("Entre com o preço do produto: ");
		float preco = leitura.nextFloat();

		System.out.print("Indique se o produto tem desconto (true/false): ");
		boolean desconto = leitura.nextBoolean();

		
		
		//process
		float valorVenda = quantidade * preco;
		
		if (desconto) {
		valorVenda = valorVenda * VALOR_DESCONTO;
		}
		
		//output
		System.out.println("Produto: " + descricao + "; qtde: " + quantidade + "; R$" + preco + "; Desconto: " + desconto);
		System.out.println("Total da venda: " + valorVenda ); // quantidade X preco
		
		leitura.close();
	}

}