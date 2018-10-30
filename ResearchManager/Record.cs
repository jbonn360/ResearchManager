using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManager
{
    public struct Record
    {
        public string Title;
        public string Link;

        private Status status;

        public Status Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Record(string title, string link)
        {
            Title = title;
            Link = link;
            status = Status.Unmarked;
        }


    }

    public enum Status
    {
        Unmarked, Duplicate, DiscardedFullText, DiscardedTitleAbs
    }
}
