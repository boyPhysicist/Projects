using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class TextBuilder
    {
        private readonly Parser.Parser _parser;
        readonly ICollection<ISentence> _sentences = new List<ISentence>();
        private readonly SentenceBuilder _sentence = new SentenceBuilder(new SentenceItemBuilder(new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators()), new WordBuilder()));
        public TextBuilder(string fileName)
        {
         _parser = new Parser.Parser(fileName);
        }
        public Text CreatText()
        {
            var x = _parser.Start();
            foreach (var item in x)
            {
                _sentences.Add(_sentence.Create(item));
            }
            Text text = new Text(_sentences);
            return text;
        }
    }
}
