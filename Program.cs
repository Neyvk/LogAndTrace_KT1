using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp26
{
    class Program
    {
        static void Main()
        {
            Directory.CreateDirectory("logs");

            Trace.Listeners.Clear();

            var consoleListener = new ConsoleTraceListener();

            var fileListener = new TextWriterTraceListener("logs/app.log");

            Trace.Listeners.Add(consoleListener);
            Trace.Listeners.Add(fileListener);

            Trace.AutoFlush = true;

            Trace.TraceInformation("[INFO] Программа TaskManager запущена.");
            Console.WriteLine("[TRACE]TaskManager запущен. Команды: add, remove, list, exit");

            var manager = new TaskManager();

            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "add":
                        Console.Write("Введите название задачи: ");
                        manager.AddTask(Console.ReadLine());
                        break;

                    case "remove":
                        Console.Write("Введите название задачи для удаления: ");
                        manager.RemoveTask(Console.ReadLine());
                        break;

                    case "list":
                        manager.ListTasks();
                        break;

                    case "exit":
                        Trace.WriteLine("[INFO] Завершение работы программы.");
                        Console.WriteLine("Завершение работы программы.");
                        return;

                    default:
                        Trace.WriteLine($"[WARN] Неизвестная команда: {command}");
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
    }
}
