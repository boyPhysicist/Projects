using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class WordBuilder : ISentenceItemBuilder
    {
        public ISentenceItem Create(string marks)
        {
            return new Word(marks);
        }
    }
}
