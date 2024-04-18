using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Вывод списка всех запущенных процессов
            Console.WriteLine("Список всех запущенных процессов:");
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process process in allProcesses)
            {
                Console.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}");
            }

            // Пользователь вводит ID процесса для завершения
            Console.WriteLine("\nВведите ID процесса для завершения:");
            int processId = int.Parse(Console.ReadLine());

            // Завершение процесса по его ID
            Process processToKill = Process.GetProcessById(processId);
            processToKill.Kill();
            Console.WriteLine($"Процесс с ID {processId} успешно завершен.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Неверный формат ввода ID процесса.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: Процесс с указанным ID не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}