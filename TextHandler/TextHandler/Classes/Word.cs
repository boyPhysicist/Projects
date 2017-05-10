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
        private Symbol[] symbols { get; }

        public IEnumerator<Symbol> GetEnumerator()
        {
            return symbols.AsEnumerable().GetEnumerator();
        }

        public string GetTypeofItem()
        {
            return "Word";
        }

        public int GetWordLenght()
        {
            return symbols.Length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.symbols.GetEnumerator();
        }

        public Word(string chars)
        {
            if (chars != null)
            {
               symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
            else
            {
                symbols = null;
            }
        }
        public Word(IEnumerable<Symbol> symbols)
        {
            this.symbols = symbols.ToArray();
        }

        public string GetWord()
        {
           StringBuilder stringbuilder = new StringBuilder();
            foreach (var item in symbols)
            {
                stringbuilder.Append(item.Chars);
            }
            return stringbuilder.ToString();
        }

    }



}

