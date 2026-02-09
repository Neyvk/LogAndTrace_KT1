using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp26
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();

        public void AddTask(string title)
        {
            Trace.WriteLine("[TRACE] Начало операции AddTask.");

            _tasks.Add(new TaskItem(title));

            Trace.TraceInformation($"[INFO] Задача \"{title}\" успешно добавлена.");

            Trace.TraceInformation($"[INFO] Количество задач после добавления: {_tasks.Count}");

            Trace.WriteLine("[TRACE] Конец операции AddTask.");
        }

        public void RemoveTask(string title)
        {
            Trace.WriteLine("[TRACE] Начало операции RemoveTask.");

            var task = _tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Trace.TraceError($"[ERROR] Задача \"{title}\" не найдена.");

                Trace.WriteLine("[TRACE] Конец операции RemoveTask.");
                return;
            }

            _tasks.Remove(task);

            Trace.TraceInformation($"[INFO] Задача \"{title}\" успешно удалена.");

            Trace.TraceInformation($"[INFO] Количество задач после удаления: {_tasks.Count}");

            Trace.WriteLine("[TRACE] Конец операции RemoveTask.");
        }

        public void ListTasks()
        {
            Trace.WriteLine("[TRACE] Начало операции ListTasks.");

            if (_tasks.Count == 0)
            {
                Trace.TraceInformation("[INFO] Список задач пуст.");

                Trace.WriteLine("[TRACE] Конец операции ListTasks.");
                return;
            }

            Trace.TraceInformation($"[INFO] Всего задач: {_tasks.Count}");

            Trace.WriteLine("[TRACE] Конец операции ListTasks.");
        }
    }
}
