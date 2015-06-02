using Eindopdracht.NFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    abstract class NFA<T>
    {
        
        public SortedSet<T> Invoersymbolen = new SortedSet<T>();
        public string StartSymbool;
        public SortedSet<string> Eindtoestanden = new SortedSet<string>();
    }
}
