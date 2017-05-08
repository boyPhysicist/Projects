using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    class PunctuationMark : IPunctuationMark
    {
        public Symbol Mark { get { return this.mark; } }
        private Symbol mark;
        public string GetTypeofItem()
        {
            return "Punctuation Mark";
        }
        public PunctuationMark(string chars)
        {
            this.mark = new Symbol(chars);
        }
    }
}

