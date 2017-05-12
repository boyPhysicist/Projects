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
        private string _line = string.Empty;
        public Parser(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<string> Start()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();
            while (!reader.EndOfStream)
            {
                var str = reader.ReadLine();
                result.AddRange(SplitText(str, reader.EndOfStream));
            }
            reader.Close();


            return result;
        }
        private IEnumerable<string> SplitText(string line, bool isLastLine)
        {
            //PunctuationMarkBuilder punctuationMarkBuilder= new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators());
            //var container = punctuationMarkBuilder.Container;
            //var mark = container[" "];
            // mark.Mark.Chars;
            line = string.Join(" ", _line, line);
            List<string> sentences = new List<string>();
            string remained = line;

            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');
                int ellipsisIndex = remained.IndexOf("...", StringComparison.Ordinal);
                int interrogatoryExclamationIndex = remained.IndexOf("?!", StringComparison.Ordinal);
                int hardExclamationIndex = remained.IndexOf("!?", StringComparison.Ordinal);

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0 && ellipsisIndex < 0 && interrogatoryExclamationIndex
                    < 0 && hardExclamationIndex < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }
                int endOfSentence = pointIndex < 0 ? remained.Length : pointIndex;
                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;
                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;
                if (ellipsisIndex > -1 && ellipsisIndex < endOfSentence)
                    endOfSentence = ellipsisIndex;
                if (interrogatoryExclamationIndex > -1 && interrogatoryExclamationIndex < endOfSentence)
                    endOfSentence = interrogatoryExclamationIndex;
                if (hardExclamationIndex > -1 && hardExclamationIndex < endOfSentence)
                    endOfSentence = hardExclamationIndex;
                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _line = remained;
            }
            return sentences;
        }

    }
}
