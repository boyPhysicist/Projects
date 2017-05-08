using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;

namespace TextHandler.Interfaces
{
    public interface IPunctuationMark : ISentenceItem
    {
        Symbol Mark { get; }
    }
}
