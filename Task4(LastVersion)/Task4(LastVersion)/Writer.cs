using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_LastVersion_
{
    public class Writer
    {
        private readonly DbDataUpdater _dbUpdater;
        private readonly CsvReader _reader;
        public Writer()
        {
            _dbUpdater = new DbDataUpdater();
            _reader = new CsvReader();
        }
        public void SaveRecords(string path)
        {
            var records = _reader.ReadCsv(path);

            foreach (var record in records)
            {
                _dbUpdater.Add(record);
            }
        }
    }
}
