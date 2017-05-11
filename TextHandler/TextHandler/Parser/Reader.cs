using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Builders;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Parser
{
    public class Reader
    {
        private readonly string _fileName;
        private string _line = string.Empty;
        
        public Reader(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<string> Read()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }
            return result;

        }

        
    }
}
