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
        private readonly Parser.Parser _parser = new Parser.Parser();
        readonly ICollection<ISentence> _sentences = new List<ISentence>();
        private readonly SentenceBuilder _sentence = new SentenceBuilder(new SentenceItemBuilder(new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators()), new WordBuilder()));
        public TextBuilder(string fileName)
        {
         _parser = new Parser.Parser(fileName);
        }
        public Text CreatText()
        {
            foreach (var item in _parser.Start())
            {
                _sentences.Add(_sentence.Create(item));
            }
            Text text = new Text(_sentences);
            return text;
        }
    }
}
