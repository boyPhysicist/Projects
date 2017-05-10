﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class WordSeparators : IDelimeter
    {
        private string[] _wordSeparators = new string[] {" ","-",",",":",";" };
        public IEnumerable<string> Delimeter()
        {
            return _wordSeparators.AsEnumerable();
        }
    }
}
