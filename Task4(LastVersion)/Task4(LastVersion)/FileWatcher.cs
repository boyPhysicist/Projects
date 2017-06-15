using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_LastVersion_
{
    public class FileWatcher
    {
        private readonly Writer _writer;
        private readonly FileSystemWatcher _fileWatcher;
        private Task _task;

        public FileWatcher()
        {
            _writer = new Writer();
            _fileWatcher = new FileSystemWatcher();


            _fileWatcher.Path = ConfigurationManager.AppSettings["Path"];
            _fileWatcher.Filter = "*.csv";
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;
            _fileWatcher.EnableRaisingEvents = true;

        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            _task = new Task(() => CallParse(source, e));
            _task.Start();
        }

        private void CallParse(object source, FileSystemEventArgs e)
        {
            var path = e.FullPath;
            _writer.SaveRecords(path);
        }
        public void Dispose()
        {
            _fileWatcher.Dispose();
        }
    }
}
