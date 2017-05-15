using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class SentenceBuilder
    {
       
        
        private readonly SentenceItemBuilder _sentenceItemBuilder;

        public SentenceBuilder(SentenceItemBuilder sentenceItemBuilder)
        {
            _sentenceItemBuilder = sentenceItemBuilder;
        }

        public Sentence Create(string[] sentence)
        {
            ICollection<ISentenceItem> _sentence = new List<ISentenceItem>();
            ISentenceItem[] sentenceItems=new ISentenceItem[sentence.Length];
            Sentence globalSentence = new Sentence(_sentence);

            int i = 0;
            foreach (var item in sentence)
            {
                sentenceItems[i]=_sentenceItemBuilder.Create(item);
                i++;
            }

            for (int j = 0; j < sentenceItems.Length; j++)
            {
                _sentence.Add(sentenceItems[j]);
                if (j + 1 == sentenceItems.Length)
                {
                   break; 
                }
                else { 
                if (sentenceItems[j + 1].GetType() == typeof(Word)&&sentenceItems[j].GetItem()!="-")
                {
                    _sentence.Add(_sentenceItemBuilder.Create(" "));
                }
                }
            }
            
            return globalSentence;
        }
    }
}
