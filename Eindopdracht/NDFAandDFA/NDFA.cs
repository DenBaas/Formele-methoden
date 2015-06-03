using Eindopdracht.NFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFA
{
    class NDFA<T>
    {
        public SortedSet<T> Invoersymbolen = new SortedSet<T>();
        public SortedSet<Toestand<T>> Toestanden = new SortedSet<Toestand<T>>();
        public SortedSet<string> StartSymbool;
        public SortedSet<string> Eindtoestanden = new SortedSet<string>();

        public NDFA()
        {

        }
        public NDFA(List<Toestand<T>> toestanden, SortedSet<T> invoerSymbolen, SortedSet<string> startSymbool, SortedSet<string> eindtoestanden)
        {

        }
    }   
}
