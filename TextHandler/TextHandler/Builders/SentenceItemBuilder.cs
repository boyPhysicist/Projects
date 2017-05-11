using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class SentenceItemBuilder : ISentenceItemBuilder
    {
        private readonly PunctuationMarkBuilder _punctuationMarkBuilder;
        private readonly WordBuilder _wordBuilder;
        public ISentenceItem Create(string marks)
        {
            var resultat = _punctuationMarkBuilder.Create(marks) ?? _wordBuilder.Create(marks);
            return resultat;
        }

        public SentenceItemBuilder(PunctuationMarkBuilder punctuationMarkBuilder, WordBuilder wordBuilder)
        {
            _punctuationMarkBuilder = punctuationMarkBuilder;
            _wordBuilder = wordBuilder;
        }
    }
}
