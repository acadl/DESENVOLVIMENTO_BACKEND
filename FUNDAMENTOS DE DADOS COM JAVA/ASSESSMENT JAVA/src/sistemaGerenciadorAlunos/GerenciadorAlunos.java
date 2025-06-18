package sistemaGerenciadorAlunos;

import java.util.Scanner;

public class GerenciadorAlunos {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Coletando dados do aluno
        System.out.print("Digite o nome do aluno: ");
        String nome = scanner.nextLine();

        System.out.print("Digite a matrícula do aluno: ");
        String matricula = scanner.nextLine();

        System.out.print("Digite a primeira nota: ");
        double nota1 = scanner.nextDouble();

        System.out.print("Digite a segunda nota: ");
        double nota2 = scanner.nextDouble();

        System.out.print("Digite a terceira nota: ");
        double nota3 = scanner.nextDouble();

        // Criando o objeto Aluno
        Aluno aluno = new Aluno(nome, matricula, nota1, nota2, nota3);

        // Exibindo o resultado final
        System.out.println("\n=== Resultado Final ===");
        aluno.verificarAprovacao();

        scanner.close();
    }
}

