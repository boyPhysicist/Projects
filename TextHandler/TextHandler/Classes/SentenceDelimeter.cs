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
        private readonly string[] _sentenceDelimeters = {".","!","?","...","!?","?!" };
        public IEnumerable<string> Delimeter()
        {
            return _sentenceDelimeters.AsEnumerable();
        }
    }
}
