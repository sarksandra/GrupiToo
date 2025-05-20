using System;
using System.Collections.Generic;
using TextGame;
using TextGame.Mihkel;

public class Story1
{
    private List<TodoItem> tasks = new List<TodoItem>
    {
        new TodoItem { MainTitle="Marianna elu"},
        new TodoItem { Title="Algus", Description = "1. Marianna läheb bussiga", IsCompleted = false },
        new TodoItem { Title="Algus", Description = "2. Marianna läheb jala", IsCompleted = false },
        new TodoItem { Title="Kas minna koju või jääda sinna", Description = "1. Marianna jääb sõra juurde ööseks", IsCompleted = false },
        new TodoItem { Title="Kas minna koju või jääda sinna", Description = "2. Marianna läheb jala koju", IsCompleted = false },
        new TodoItem { Title="Uus päev", Description = "1. Marianna läheb trenni", IsCompleted = false },
        new TodoItem { Title="Uus päev", Description = "2. Marianna läheb sõbrannag kinno", IsCompleted = false },
        new TodoItem { Title="Trenni minemine", Description = "1. Marianna läheb emaga koos", IsCompleted = false },
        new TodoItem { Title="Trenni minemine", Description = "2. Marianna otsusts üksi minna", IsCompleted = false },
        new TodoItem { Title="Peale kino", Description = "1. Marianna läheb jäätist sööma", IsCompleted = false },
        new TodoItem { Title="Peale kino", Description = "2. Marianna läheb üksi koju", IsCompleted = false },
        new TodoItem { Title="Läheb jäätist sööma", Description = "1. Marianna hakkab karjuma", IsCompleted = false },
        new TodoItem { Title="Läheb jäätist sööma", Description = "2. Marianna on vaikselt", IsCompleted = false },
        new TodoItem { Title="Marianna valik", Description = "1. Marianna jäi sõbraga", IsCompleted = false },
        new TodoItem { Title="Marianna valik", Description = "2. Marianna läks üksi ära", IsCompleted = false },
        new TodoItem { Title="Kinost koju minek", Description = "1. Marianna võtab kass endaga kaasa", IsCompleted = false },
        new TodoItem { Title="Kinost koju minek", Description = "2. Marianna läheb üksi koju", IsCompleted = false },
        new TodoItem { MainTitle="CedarCreek"},
        new TodoItem { Title="Craete Name"},
        new TodoItem { Title="Fight(1) time"},
        new TodoItem { Title="Fight(10) time"},
        new TodoItem { Title="Use Heavy attack(1) time"},
        new TodoItem { Title="Use Heavy attack(6) time"},
        new TodoItem { Title="Use Light attack(1) time"},
        new TodoItem { Title="Use Light attack(6) time"},
        new TodoItem { Title="Beat Enemy"},
        new TodoItem { Title="Your health 50%"},
        new TodoItem { Title="Buy item"}
    };

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MarkTaskComplete();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Exiting application...");
                    return true;
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
        Console.WriteLine("1. Mark Task as Complete");
        Console.WriteLine("2. View All Tasks");
        Console.WriteLine("3. Exit");
        Console.Write("Enter your choice (1-3): ");
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
        for (int i = 1; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "[Done]" : "[ ]";
            if(i == 1)
            {
                Console.WriteLine($"{1}. {status} Marianna elu");
            }
            if (i == 17)
            {
                Console.WriteLine($"{18}. {status} CedarCreek");             
            }
            Console.WriteLine($"{i + 1}.{tasks[i].Title} {status} {tasks[i].Description}");
        }
    }
}
