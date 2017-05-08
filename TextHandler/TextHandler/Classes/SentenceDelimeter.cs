using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class SentenceDelimeter : IDelimeter
    {
        private string[] sentenceDelimeters = new string[] {".","!","?","..." };
        public IEnumerable<string> Delimeter()
        {
            throw new NotImplementedException();
        }
    }
}
