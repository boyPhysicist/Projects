using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Classes
{
    public class Symbol
    {
        private string chars;
        public string Chars { get { return chars; } }
        public bool IsUpper()
        {
            return chars != null && chars.Length >= 1 && char.IsLetter(chars[0]) && char.IsUpper(chars[0]);
        }

        public bool IsLower()
        {

            return chars != null && chars.Length >= 1 && char.IsLetter(chars[0]) && char.IsLower(chars[0]);
        }
        public bool IsLetter()
        {
            return chars != null && chars.Length == 1 && char.IsLetter(chars[0]);
        }

        public Symbol(string chars)
        {
            this.chars = chars;
        }
        public Symbol(char symbol)
        {
            this.chars = symbol.ToString();
        }

    }
}
