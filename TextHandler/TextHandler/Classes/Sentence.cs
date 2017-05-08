using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int GetSentenceLenght()
        {
            return Items.Count();
        }
    }
}
