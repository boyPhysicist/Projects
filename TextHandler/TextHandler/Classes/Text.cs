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
        public ICollection<ISentence> TextSentences { get; }
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
    }
}
