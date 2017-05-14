using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Builders;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class Sentence : ISentence
    {
        public ICollection<ISentenceItem> Items { get; }

        public Sentence(ICollection<ISentenceItem> items)
        {
            Items = items;
        }

        public void Add(ISentenceItem item)
        {
            Items.Add(item);
        }

        public void Remove(ISentenceItem item)
        {
            Items.Remove(item);
        }
        public void Remove(ISentenceItem[] items)
        {
            foreach (var i in items)
            {
                Items.Remove(i);
            }
            
        }

        public void ChageItem(ISentenceItem item1, string items)
        {
            var a = Items.ToArray();
            var j = 0;
            ISentenceItemBuilder sentenceItemBuilder= new SentenceItemBuilder(new PunctuationMarkBuilder(new SentenceDelimeter(), new WordSeparators()),new WordBuilder() );
            char pattern = ' ';
            var words = items.Split(pattern); 
            Items.Clear();
            foreach (var i in a)
            {
                if (i == item1)
                {
                    
                        a[j] = sentenceItemBuilder.Create(items);
                        Items.Add(a[j]);
                        j += 1;
                   

                }
                else
                {
                    Items.Add(i);
                }
                    
                
                
                j += 1;
            }



        }

        public IEnumerable<ISentenceItem> GetSentenceEnumerable()
        {
            return Items.ToArray();
        }
            
  

        public int GetSentenceLenght()
        {
            int i = 0;
            foreach (var item in Items)
            {
                if (item.GetType() == typeof(Word))
                {
                    i += 1;
                }
            }
            return i;
        }

        public string GetSentence()
        {
            string str = "";
            foreach (var item in Items)
            {
                str = str + item.GetItem();
            }
            return str;
        }

        public string GetLastPunctuationMark()
        {
            var lastOrDefault = Items.LastOrDefault();
            return lastOrDefault.GetItem();
        }
    }
}
