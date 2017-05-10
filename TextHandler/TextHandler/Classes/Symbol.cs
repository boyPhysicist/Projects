using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextHandler.Classes
{
    public class Symbol
    {
        private string chars;
        public string Chars { get { return chars; } }

        public bool IsConsonant()
        {
            const string pattern = @"[aAeEiIoOuU]";
            return !string.IsNullOrEmpty(chars) && char.IsLetter(chars[0]) && !(Regex.Matches(String.Format("{0}", chars[0]), pattern).Count > 0);
        }
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

        public Symbol(string symbols)
        {
            chars = symbols;
        }
        public Symbol(char symbol)
        {
            chars = String.Format("{0}", symbol);
        }

    }
}
