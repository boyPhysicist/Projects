using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    class SentenceItemBuilder : ISentenceItemBuilder
    {
        private PunctuationMarkBuilder punctuationMarkBuilder;
        private WordBuilder wordBuilder;
        public ISentenceItem Create(string marks)
        {
            throw new NotImplementedException();
        }

        public SentenceItemBuilder(PunctuationMarkBuilder pMB, WordBuilder wB)
        {
            punctuationMarkBuilder = pMB;
            wordBuilder = wB;
        }
    }
}
