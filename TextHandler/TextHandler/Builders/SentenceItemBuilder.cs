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
        private PunctuationMarkBuilder _punctuationMarkBuilder;
        private WordBuilder _wordBuilder;
        public ISentenceItem Create(string marks)
        {
            throw new NotImplementedException();
        }

        public SentenceItemBuilder(PunctuationMarkBuilder pMb, WordBuilder wB)
        {
            _punctuationMarkBuilder = pMb;
            _wordBuilder = wB;
        }
    }
}
