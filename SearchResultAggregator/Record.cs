using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchResultAggregator
{
    public struct Record
    {
        public string Title;
        public string Link;

        public Record(string title, string link)
        {
            Title = title;
            Link = link;
        }
    }
}
