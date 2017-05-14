using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Interfaces
{
    public interface ISentence
    {
        ICollection<ISentenceItem> Items { get; }
        int GetSentenceLenght();
        string GetSentence();
        string GetLastPunctuationMark();
    }
}
