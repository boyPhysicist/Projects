using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class Text
    {
        public ICollection<ISentence> TextSentences { get; set; }

        public Text(ICollection<ISentence> sentences)
        {
            TextSentences = sentences;
        }

        public void Add(ISentence item)
        {
            TextSentences.Add(item);
        }

        public void DeleteItem(ISentence item)
        {
            TextSentences.Remove(item);
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

            return TextSentences.ToArray().Where(x => x.GetLastPunctuationMark() == "?")
                .Select(y => y.Items.Where(x => x.GetItem().Length == length).ToString());
        }
    }
}