using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class Text
    {
        public IEnumerable<ISentence> TextSentences { get; set; }

        public Text(ICollection<ISentence> sentences)
        {
            TextSentences = sentences;
        }

      public string GetText()
        {
            string str = "";
            foreach (var item in TextSentences)
            {
                str = str + item.GetSentence() + " ";
            }
            return str;
        }

        public IEnumerable<ISentence> GetSentences()
        {
            return TextSentences.ToArray();
        }

        public IEnumerable<ISentence> SortBySentencesLength()
        {
            return GetSentences().OrderBy(x => x.GetSentenceLenght());
        }

        public IEnumerable<string> GetWordGivenLengthInterrogotiveSentences(int length)
        {
            return TextSentences
                .Where(x => x.GetLastPunctuationMark() == "?")
                .Select(x => x)
                .SelectMany(x => x.Items.Where(y => y.GetType() == typeof(Word) && y.GetLength() == length))
                .Select(x=>x.GetItem()
                .ToLower())
                .Distinct()
                .ToArray();
        }

        public void DeleteWordGivenLengthConsonatString(int length)
        {
            foreach (var sentence in TextSentences
                .Where(x => x.Items.ElementAt(0).IsConsonant()))
            {
                sentence.Remove(sentence.Items.Where(x => x.GetType() == typeof(Word) && x.GetLength() == length)
                    .ToArray());
            }
            
        }

        public void ChangeWords(int numberOfSentence, int lengthWords, string changingStr)
        {
            
        }
    }
}