using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Classes;
using TextHandler.Interfaces;

namespace TextHandler.Builders
{
    public class PunctuationMarkBuilder : ISentenceItemBuilder
    {
        readonly IDictionary<string, PunctuationMark> _container = new Dictionary<string, PunctuationMark>();

        

        public ISentenceItem Create(string marks)
        {
            return _container.ContainsKey(marks) ? _container[marks] : null;
        }

        public PunctuationMarkBuilder(IDelimeter delimeter, IDelimeter separator)
        {
           
            
                foreach (var d in delimeter.Delimeter())
                {
                    _container.Add(d, new PunctuationMark(d));
                }
            
            foreach (var s in separator.Delimeter())
            {
                _container.Add(s, new PunctuationMark(s));
            }
        }
    }
}
