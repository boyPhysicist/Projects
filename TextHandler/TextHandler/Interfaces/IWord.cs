using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;

namespace TextHandler.Interfaces
{
    public interface IWord:ISentenceItem,IEnumerable<Symbol>
    {
        int GetWordLenght();
        
    }
}
