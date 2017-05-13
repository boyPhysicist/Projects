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
        private readonly ICollection<ISentenceItem> _sentence = new List<ISentenceItem>();
        private readonly SentenceItemBuilder _sentenceItemBuilder;

        public SentenceBuilder(SentenceItemBuilder sentenceItemBuilder)
        {
            _sentenceItemBuilder = sentenceItemBuilder;
        }

        public Sentence Create(string[] sentence)
        {
            Sentence globalSentence = new Sentence(_sentence);

            foreach (var item in sentence)
            {
                globalSentence.Add(_sentenceItemBuilder.Create(item));
            }

            return globalSentence;
        }
    }
}
