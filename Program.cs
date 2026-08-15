using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Net.Http.Headers; //me permite usar o list

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
                    RemoverAluno();
                    break;
                case 5:
                    Media();
                    break;
                case 6:
                    Console.Write("Programa encerrado.");
                    break;
            }
        }
        while (menu != 6);
    }


    static List<Aluno> listaDeAlunos = new List<Aluno>();

    //cria o objeto aluno, agora aluno é um tipo de dado, quase como um novo tipo de variavel
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

        /*
        for (int i = 0; i < listaDeAlunos.Count; i++)
        {
            Console.WriteLine($"Nome: {listaDeAlunos[i].Nome}");
            Console.WriteLine($"Idade: {listaDeAlunos[i].Idade}");
            Console.WriteLine($"Nota: {listaDeAlunos[i].Nota}");
            Console.WriteLine();
        }
        */

        //maneira diferente de fazer
        //siginifica que para cada Aluno que existir dentro de listaDeAlunos, chame esse objeto de estudante
        //aqui eu chamei o foreach, e criei uma nova "variavel" do tipo aluno chamada Aluno, ele vai nomear todos os objetos em lista de alunos que estiverem em Aluno de estudante, pra não ficar tão confuso
        foreach (Aluno estudante in listaDeAlunos)
        {
            Console.WriteLine($"Nome: {estudante.Nome}");
            Console.WriteLine($"Idade: {estudante.Idade}");
            Console.WriteLine($"Nota: {estudante.Nota}");
            Console.WriteLine();
        }
    }

    static void BuscarAluno()
    {
        Console.WriteLine("Digite o nome do aluno: ");
        string nomeAluno = Console.ReadLine();

        bool encontrado = false;

        /* fazendo com o for
        for (int i = 0; i < listaDeAlunos.Count; i++)
        {
            if (nomeAluno == listaDeAlunos[i].Nome)
            {
                Console.WriteLine($"Nome: {listaDeAlunos[i].Nome}");
                Console.WriteLine($"Idade: {listaDeAlunos[i].Idade}");
                Console.WriteLine($"Nota: {listaDeAlunos[i].Nota}");
                Console.WriteLine();

                encontrado = true;
            }
            if (encontrado == false)
            {
                Console.WriteLine("Aluno não encontrado.");
            }
        }
        */

        //usando o foreach fica realmente mais facil de ler
        foreach (Aluno estudante in listaDeAlunos)
        {
            if (nomeAluno == estudante.Nome)
            {
                Console.WriteLine();
                Console.WriteLine("---------- Dados do Estudante ----------");
                Console.WriteLine($"Nome: {estudante.Nome}");
                Console.WriteLine($"Idade: {estudante.Idade}");
                Console.WriteLine($"Nota: {estudante.Nota}");

                encontrado = true;
            }
        }
        if (encontrado == false)
        {
            Console.WriteLine("Aluno não encontrado.");
            Console.WriteLine();
        }
    }

    static void RemoverAluno()
    {
        Console.WriteLine("Digite o nome do aluno que deseja remover: ");
        string nomeAluno = Console.ReadLine();

        for (int i = 0; i < listaDeAlunos.Count; i++)
        {
            if (nomeAluno == listaDeAlunos[i].Nome)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome: {listaDeAlunos[i].Nome}");
                Console.WriteLine($"Idade: {listaDeAlunos[i].Idade}");
                Console.WriteLine($"Nota: {listaDeAlunos[i].Nota}");
                Console.WriteLine();
                Console.WriteLine("Tem certeza que gostaria de remover este aluno?");
                Console.WriteLine("1 - sim");
                Console.WriteLine("2 - não");
                int decisao = int.Parse(Console.ReadLine());

                if (decisao == 1)
                {
                    listaDeAlunos.Remove(listaDeAlunos[i]);
                }
                else Console.WriteLine("Operação cancelada");
                Console.WriteLine();
            }
        }
    }

    static void Media()
    {
        float somarNotas = 0;
        int quantDeAlunos = 0;
        for (int i = 0; i < listaDeAlunos.Count; i++)
        {
            somarNotas += listaDeAlunos[i].Nota;
            quantDeAlunos++;
        }
        float media = somarNotas / quantDeAlunos;

        Console.WriteLine($"A nota média da turma é de {media} pontos.");
    }
}