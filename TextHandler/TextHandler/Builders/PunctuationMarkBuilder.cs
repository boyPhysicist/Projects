using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class PunctuationMarkBuilder : ISentenceItemBuilder
    {
        IDictionary<string, ISentenceItem> container;
        public ISentenceItem Create(string marks)
        {
            
        }

        public PunctuationMarkBuilder(SentenceDelimeter delimeter,WordSeparators separator)
        {
            
            foreach(var d in delimeter.Delimeter())
            {
                container.Add(d, new PunctuationMark(d));
            }
            foreach (var s in separator.Delimeter())
            {
                container.Add(s, new PunctuationMark(s));
            }
        }
    }
}
