using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Builders;
using TextHandler.Classes;
using TextHandler.Interfaces;
using TextHandler.Parser;

namespace TextHandler
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            TextBuilder textBuilder = new TextBuilder("text.txt");
            Text text = textBuilder.CreatText();
            

            text.DeleteWordGivenLengthConsonatString(3);
            foreach (var i in text.GetWordGivenLengthInterrogotiveSentences(2))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            foreach (var item in text.SortBySentencesLength())
            {
                Console.WriteLine(item.GetSentence());
            }
            Console.ReadLine();
        }
    }
}
