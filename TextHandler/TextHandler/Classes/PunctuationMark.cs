using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class PunctuationMark : IPunctuationMark
    {
        public Symbol Mark { get { return mark; } }
        private Symbol mark;
        public string GetTypeofItem()
        {
            return "Punctuation Mark";
        }

        public string GetItem()
        {
            return mark.Chars;
        }

        public int GetLength()
        {
            return mark.Chars.Length;
        }

        public bool IsConsonant()
        {
            return false;
        }

        public PunctuationMark(string chars)
        {
            mark = new Symbol(chars);
        }
    }
}

