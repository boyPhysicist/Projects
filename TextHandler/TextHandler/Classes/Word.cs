using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    class Word : IWord
    {
        private Symbol[] Symbols { get; }

        public IEnumerator<Symbol> GetEnumerator()
        {
            return Symbols.AsEnumerable().GetEnumerator();
        }

        public string GetTypeofItem()
        {
            return "Word";
        }

        public int GetWordLenght()
        {
            return Symbols.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Symbols.GetEnumerator();
        }

        public Word(string chars)
        {
            Symbols = chars?.Select(x => new Symbol(x)).ToArray();
        }
        public Word(IEnumerable<Symbol> symbols)
        {
            Symbols = symbols.ToArray();
        }

        public string GetItem()
        {
           var stringbuilder = new StringBuilder();
            foreach (var item in Symbols)
            {
                stringbuilder.Append(item.Chars);
            }
            return stringbuilder.ToString();
        }

        
    }



}

