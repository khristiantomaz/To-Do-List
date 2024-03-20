using System;
using Entities;
class Program
{
    static List<ToDoItem> toDoList = new List<ToDoItem>();

    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo à sua lista de tarefas!");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Adicionar nova tarefa");
            Console.WriteLine("2. Ver tarefas pendentes");
            Console.WriteLine("3. Marcar uma tarefa como concluída");
            Console.WriteLine("4. Sair");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewTask();
                    break;
                case "2":
                    ShowPendingTasks();
                    break;
                case "3":
                    MarkTaskAsCompleted();
                    break;
                case "4":
                    Console.WriteLine("Até logo!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                    break;
            }
        }
    }

    static void AddNewTask()
    {
        Console.Write("Digite a descrição da nova tarefa: ");
        string description = Console.ReadLine();
        ToDoItem newTask = new ToDoItem(description);
        toDoList.Add(newTask);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    static void ShowPendingTasks()
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa pendente no momento.");
            return;
        }

        Console.WriteLine("Tarefas pendentes:");
        for (int i = 0; i < toDoList.Count; i++)
        {
            if (!toDoList[i].IsCompleted)
            {
                Console.WriteLine($"{i + 1}. {toDoList[i].Description}");
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        if (toDoList.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa para marcar como concluída.");
            return;
        }

        ShowPendingTasks();

        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= toDoList.Count)
        {
            toDoList[index - 1].MarkAsCompleted();
            Console.WriteLine("Tarefa marcada como concluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.");
        }
    }
}
