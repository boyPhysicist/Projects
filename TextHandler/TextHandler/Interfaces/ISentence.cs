using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Interfaces
{
    public interface ISentence
    {
        IEnumerable<ISentenceItem> Item { get; }
        void GetSentenceLenght();

    }
}
