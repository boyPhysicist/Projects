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
            throw new NotImplementedException();
        }

        public string GetTypeofItem()
        {
            return "Word";
        }

        public int GetWordLenght()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Word(string chars)
        {
            if (chars != null)
            {
                this.symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
        }


    }



}
}
