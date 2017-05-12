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
        private IDictionary<string, PunctuationMark> _container;

        public IDictionary<string, PunctuationMark> Container
        {
            get
            {
                return _container;
            }

            set
            {
                _container = value;
            }
        }

        public ISentenceItem Create(string marks)
        {
            return Container.ContainsKey(marks) ? Container[marks] : null;
        }

        public PunctuationMarkBuilder(IDelimeter delimeter, IDelimeter separator)
        {
            if (delimeter != null)
                foreach (var d in delimeter.Delimeter())
                {
                    Container.Add(d, new PunctuationMark(d));
                }
            if (separator == null) return;
            foreach (var s in separator.Delimeter())
            {
                Container.Add(s, new PunctuationMark(s));
            }
        }
    }
}
