using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Builders;
using TextHandler.Classes;

namespace TextHandler.Parser
{
    public class Reader
    {
        private readonly string _fileName;
        private string _line = string.Empty;
        PunctuationMarkBuilder _punctuationMarkBuilder = new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators());
        public Reader(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<string> Read()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result. Add(reader.ReadLine());
            }



                return result;

        }



        private IEnumerable<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _line, line);
            var sentences = new List<string>();
            var remained = line;
            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');
                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }
                var endOfSentence = (pointIndex < 0 ? remained.Length : pointIndex);
                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;
                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;
                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _line = remained;
            }
            return sentences;
        }


    }
}
