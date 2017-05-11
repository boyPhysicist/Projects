using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Builders;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Parser
{
    public class Parser
    {
        private readonly string _fileName;

        public Parser(string fileName)
        {
            _fileName = fileName;
        }
        public IEnumerable<ISentenceItem> SplitText()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            ICollection<ISentenceItem> result = new List<ISentenceItem>();
            PunctuationMarkBuilder punctuationMarkBuilder = new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators());
            WordBuilder wordBuilder = new WordBuilder();
            SentenceItemBuilder sentenceItemBuilder = new SentenceItemBuilder(punctuationMarkBuilder,wordBuilder);
            
            string temp = reader.ReadToEnd();
            int i = 0;
            foreach (var item in temp)
            {
                if (char.IsLetter(item))
                {
                    
                }
                
            }



            
             
            return result;
        }

    }
}
