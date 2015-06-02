using Eindopdracht.NFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFA
{
    class NDFA<T> : NFA<T>
    {
        public List<Toestand<T>> Toestanden = new List<Toestand<T>>();

        public NDFA(List<Toestand<T>> toestanden, SortedSet<T> invoerSymbolen, string startSymbool, SortedSet<string> eindtoestanden)
        {

        }
    }   
}
