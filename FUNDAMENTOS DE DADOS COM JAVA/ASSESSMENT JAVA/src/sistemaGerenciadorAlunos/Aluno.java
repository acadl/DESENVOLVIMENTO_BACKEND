package sistemaGerenciadorAlunos;

import java.util.Scanner;

public class Aluno {
    // Atributos
    private String nome;
    private String matricula;
    private double nota1;
    private double nota2;
    private double nota3;

    // Construtor
    public Aluno(String nome, String matricula, double nota1, double nota2, double nota3) {
        this.nome = nome;
        this.matricula = matricula;
        this.nota1 = nota1;
        this.nota2 = nota2;
        this.nota3 = nota3;
    }

    // Método para calcular a média
    public double calcularMedia() {
        return (nota1 + nota2 + nota3) / 3;
    }

    // Método para verificar a aprovação
    public void verificarAprovacao() {
        double media = calcularMedia();
        System.out.printf("Média final: %.2f%n", media);
        if (media >= 7.0) {
            System.out.println("Situação: Aprovado!");
        } else {
            System.out.println("Situação: Reprovado.");
        }
    }
}

