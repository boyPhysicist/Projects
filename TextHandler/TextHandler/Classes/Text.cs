using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Classes
{
    public class Text
    {
        ICollection<ISentence> Sentenses { get; set; }
         public Text()
        {
            Sentenses = new List<ISentence>();
        }


    }
}
