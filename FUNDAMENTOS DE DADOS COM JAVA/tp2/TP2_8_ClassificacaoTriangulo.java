package br.edu.tp2;
import java.util.Scanner;

public class TP2_8_ClassificacaoTriangulo {
	public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Leitura dos três lados
        System.out.print("Digite o valor do primeiro lado: ");
        double lado1 = scanner.nextDouble();

        System.out.print("Digite o valor do segundo lado: ");
        double lado2 = scanner.nextDouble();

        System.out.print("Digite o valor do terceiro lado: ");
        double lado3 = scanner.nextDouble();

        // Verificação se os lados podem formar um triângulo válido
        if (formaTriangulo(lado1, lado2, lado3)) {

            // Classificação do triângulo
            if (lado1 == lado2 && lado2 == lado3) {
                System.out.println("Triângulo equilátero.");
            } else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3) {
                System.out.println("Triângulo isósceles.");
            } else {
                System.out.println("Triângulo escaleno.");
            }

        } else {
            System.out.println("Os valores fornecidos não formam um triângulo válido.");
        }

        scanner.close();
    }

    // Método auxiliar para verificar se os lados podem formar um triângulo
    public static boolean formaTriangulo(double a, double b, double c) {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

}
