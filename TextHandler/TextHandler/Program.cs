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
            

            foreach (var item in text.TextSentences)
            {
                Console.WriteLine(item.GetSentence());
            }
            text.ChangeWords(1, 2, "hey hey");
            Console.WriteLine(text.TextSentences.ElementAt(1).GetSentence());
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            text.DeleteWordGivenLengthConsonatString(2);
            Console.WriteLine(text.GetText());
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            foreach (var i in text.GetWordGivenLengthInterrogotiveSentences(3))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");


            foreach (var item in text.SortBySentencesLength())
            {
                Console.WriteLine(item.GetSentence());
            }
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");

            Reader reader = new Reader("text.txt");
            foreach (var item in reader.Read())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

        }
    }
}
