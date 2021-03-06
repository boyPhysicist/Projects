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
        private readonly string[] _wordSeparators = {" ","-",",",":",";" };
        public IEnumerable<string> Delimeter()
        {
            return _wordSeparators.AsEnumerable();
        }
    }
}
