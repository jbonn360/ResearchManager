using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManager
{
    public struct PubMedOptions
    {
        public bool Abstract;
        public bool FreeFullText;
        public bool FullText;
        public DateTime PublicationFrom;
        public DateTime PublicationTo;
        public bool Humans;
        public bool OtherAnimals;

        public PubMedOptions(bool @abstract, bool freeFullText, bool fullText, DateTime publicationFrom,
            DateTime publicationTo, bool humans, bool otherAnimals)
        {
            Abstract = @abstract;
            FreeFullText = freeFullText;
            FullText = fullText;
            PublicationFrom = publicationFrom;
            PublicationTo = publicationTo;
            Humans = humans;
            OtherAnimals = otherAnimals;
        }

        public PubMedOptions(bool @abstract, bool freeFullText, bool fullText,  bool humans, 
            bool otherAnimals)
        {
            Abstract = @abstract;
            FreeFullText = freeFullText;
            FullText = fullText;
            PublicationFrom = DateTime.MinValue;
            PublicationTo = DateTime.MinValue;
            Humans = humans;
            OtherAnimals = otherAnimals;
        }

        public void SetFilterDateRage (DateTime from, DateTime to)
        {
            PublicationFrom = from;
            PublicationTo = to;
        }
    }
}
