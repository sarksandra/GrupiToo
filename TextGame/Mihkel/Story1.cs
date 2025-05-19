using System;
using System.Collections.Generic;
using TextGame.Mihkel;

public class Story1
{
    private List<TodoItem> tasks = new List<TodoItem>();

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    MarkTaskComplete();
                    break;
                case "3":
                    ViewTasks();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\n=== TO-DO LIST MANAGER ===");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Mark Task as Complete");
        Console.WriteLine("3. View All Tasks");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

    private void AddTask()
    {
        Console.Write("\nEnter task description: ");
        string description = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(description))
        {
            tasks.Add(new TodoItem(description));
            Console.WriteLine($"Task added: {description}");
        }
        else
        {
            Console.WriteLine("Task description cannot be empty!");
        }
    }

    private void MarkTaskComplete()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available!");
            return;
        }

        ViewTasks();
        Console.Write("\nEnter task number to mark complete: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine($"Task marked complete: {tasks[index - 1].Description}");
        }
        else
        {
            Console.WriteLine("Invalid task number!");
        }
    }

    private void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nYour to-do list is empty!");
            return;
        }

        Console.WriteLine("\n=== YOUR TASKS ===");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "[✓]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }
    }

    private void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to delete!");
            return;
        }

        ViewTasks();
        Console.Write("\nEnter task number to delete: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            string deletedTask = tasks[index - 1].Description;
            tasks.RemoveAt(index - 1);
            Console.WriteLine($"Deleted task: {deletedTask}");
        }
        else
        {
            Console.WriteLine("Invalid task number!");
        }
    }
}