using System;
using System.ComponentModel.Design;
using System.Collections.Generic; //me permite usar o list

public class Program
{
    static void Main(String[] args)
    {

        int menu = 0;

        do
        {
            Console.WriteLine("O que deseja fazer? ");
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Buscar Aluno");
            Console.WriteLine("4 - Remover Aluno");
            Console.WriteLine("5 - Mostrar média geral");
            Console.WriteLine("6 - Sair");

            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:

                    CadastrarAluno();
                    break;
                case 2:
                    ListarAluno();
                    break;
                case 3:
                    BuscarAluno();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }
        while (menu != 6);
    }


    static List<Aluno> listaDeAlunos = new List<Aluno>();

    //cria o objeto aluno
    public class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public float Nota { get; set; }


        //isso aqui é o construtor
        public Aluno(string nome, int idade, float nota)
        {
            Nome = nome;
            Idade = idade;
            Nota = nota;
        }
    }

    static void CadastrarAluno()
    {
        Console.WriteLine("Digite o nome do aluno:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite a idade do aluno:");
        int idade = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite a nota do aluno:");
        float nota = float.Parse(Console.ReadLine());

        Aluno novoAluno = new Aluno(nome, idade, nota);
        listaDeAlunos.Add(novoAluno);
    }

    static void ListarAluno()
    {
        Console.WriteLine("--------- Alunos cadastrados ---------");

        for (int i = 0; i < listaDeAlunos.Count; i++)
        {
            Console.WriteLine($"Nome: {listaDeAlunos[i].Nome}");
            Console.WriteLine($"Idade: {listaDeAlunos[i].Idade}");
            Console.WriteLine($"Nota: {listaDeAlunos[i].Nota}");
            Console.WriteLine();
        }
    }

    static void BuscarAluno()
    {

    }
}