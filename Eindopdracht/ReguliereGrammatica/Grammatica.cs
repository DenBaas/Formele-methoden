using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class Grammatica<T>
    {
        private HashSet<ProductieRegel<T>> productieRegels;
        private T startSymbool;
        public SortedSet<char> alfabet = new SortedSet<char>();

        public Grammatica(T startSymbool, HashSet<ProductieRegel<T>> productieRegels)
        {
            this.startSymbool = startSymbool;
            this.productieRegels = productieRegels;
            foreach (ProductieRegel<T> p in productieRegels)
            {
                alfabet.Add(p.x);
            }
        }

        public String toString()
        {
            String beschrijving = "";        
            foreach (ProductieRegel<T> p in productieRegels)
            {
                beschrijving += p + "\n";
            }        
            return beschrijving;      
        }
    }
}
