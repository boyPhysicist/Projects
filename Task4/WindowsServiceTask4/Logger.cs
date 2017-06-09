using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceTask4
{
    public class Logger
    {
        readonly FileSystemWatcher _watcher;
        readonly object _obj = new object();
        bool _enabled = true;
        public Logger()
        {
            _watcher = new FileSystemWatcher("C:\\Temp");
            _watcher.Deleted += Watcher_Deleted;
            _watcher.Created += Watcher_Created;
            _watcher.Changed += Watcher_Changed;
            _watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while (_enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
        }
        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (_obj)
            {
                using (StreamWriter writer = new StreamWriter("C:\\templog.txt", true))
                {
                    writer.WriteLine($"{DateTime.Now:dd/MM/yyyy hh:mm:ss} файл {filePath} был {fileEvent}");
                    writer.Flush();
                }
            }
        }
}
}
