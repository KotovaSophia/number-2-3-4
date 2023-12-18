using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
           
            Process.Start("notepad.exe");

           
            Thread.Sleep(5000);
        }

        // Получаем список всех процессов
        Process[] processes = Process.GetProcesses();

        // Сортируем процессы по приоритету
        processes = processes.OrderBy(process => process.BasePriority).ToArray();

        // Выводим PID, имена и приоритет процессов
        Console.WriteLine("Список процессов отсортированных по приоритету:");
        foreach (Process process in processes)
        {
            Console.WriteLine($"PID: {process.Id}, Имя: {process.ProcessName}, Приоритет: {process.BasePriority}");
        }

        // Выводим первые 3 процесса
        Console.WriteLine("\nПервые 3 процесса:");
        for (int i = 0; i < Math.Min(3, processes.Length); i++)
        {
            Process process = processes[i];
            Console.WriteLine($"PID: {process.Id}, Имя: {process.ProcessName}, Приоритет: {process.BasePriority}");
        }
    }
}
