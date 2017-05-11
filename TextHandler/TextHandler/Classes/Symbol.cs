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
        private readonly string _chars;

        public string Chars
        {
            get { return _chars; }
            set { throw new NotImplementedException(); }
        }

        public bool IsConsonant()
        {
            const string pattern = @"[aAeEiIoOuU]";
            return !string.IsNullOrEmpty(_chars) && char.IsLetter(_chars[0]) && !(Regex.Matches($"{_chars[0]}", pattern).Count > 0);
        }
        public bool IsUpper()
        {
            return _chars != null && _chars.Length >= 1 && char.IsLetter(_chars[0]) && char.IsUpper(_chars[0]);
        }

        public bool IsLower()
        {

            return _chars != null && _chars.Length >= 1 && char.IsLetter(_chars[0]) && char.IsLower(_chars[0]);
        }
        public bool IsLetter()
        {
            return _chars != null && _chars.Length == 1 && char.IsLetter(_chars[0]);
        }

        public Symbol(string symbols)
        {
            _chars = symbols;
        }
        public Symbol(char symbol)
        {
            _chars = $"{symbol}";
        }

    }
}
