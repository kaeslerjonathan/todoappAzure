﻿using System.Threading.Tasks;

namespace ToDoApp
{
    public class Program
    {
        static string filePath = "todo_list.csv";
        public static IList<string> tasks = new List<string>();
        static IList<string> history = new List<string>();

        static void Main()
        {
            LoadTasks();

            while (true)
            {
                Console.WriteLine("\nToDo-Liste: ");
                Console.WriteLine("1. Aufgabe hinzufügen");
                Console.WriteLine("2. Aufgabe entfernen");
                Console.WriteLine("3. Aufgaben anzeigen");
                Console.WriteLine("4. Aufgaben speichern");
                Console.WriteLine("5. Verlauf anzeigen");
                Console.WriteLine("6. Beenden");
                Console.Write("Auswahl: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ShowTasks();
                        break;
                    case "4":
                        SaveTasks();
                        Console.WriteLine("Aufgaben gespeichert!");
                        break;
                    case "5":
                        ShowHistory();
                        break;
                    case "6":
                        SaveTasks();
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl!");
                        break;
                }
            }
        }

        static void ShowHistory()
        {
            if(history.Count == 0)
            {
                Console.WriteLine("Es wurden noch keine Aktionen getätigt");
                return;
            }

            Console.WriteLine("Verlauf:");
            for(int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"{i+1}: {history[i]}");
            }
        }

        static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                tasks = new List<string>(File.ReadAllLines(filePath));
            }
        }

        static void SaveTasks()
        {
            File.WriteAllLines(filePath, tasks);
        }

        public static void AddTaskToTaskList(string task)
        {
            tasks.Add(task);
            history.Add($"Aufgabe {task} hinzugefügt");
        }

        static void AddTask()
        {
            Console.Write("Neue Aufgabe: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                AddTaskToTaskList(task);
                Console.WriteLine("Aufgabe hinzugefügt!");
            }
        }

        static void RemoveTask()
        {
            ShowTasks();
            Console.Write("Nummer der zu löschenden Aufgabe: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                history.Add($"Aufgabe {tasks[index-1]} entfernt");
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Aufgabe entfernt!");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        }

        static void ShowTasks()
        {
            Console.WriteLine("\nAktuelle Aufgaben:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Keine Aufgaben vorhanden.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }
    }
}