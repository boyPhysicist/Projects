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
            foreach (var item in text.GetSentences().OrderBy(x => x.GetSentenceLenght()))
            {
                Console.WriteLine(item.GetSentence());
            }

            //text.GetSentences().OrderBy(x => x.GetSentenceLenght());
            //Console.WriteLine(textBuilder.CreatText().GetText());
            Console.ReadLine();
        }
    }
}
