using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class ProductieRegel<T>
    {
        public T linkerkant;
        public char x;
        public T rechterkant;

        public ProductieRegel(T l, char x, T r)
        {
            this.linkerkant = l;
            this.x = x;
            this.rechterkant = r;
        }

        public String toString()
        {
            return "" + linkerkant + " --> " + x + rechterkant;
        }
    }
}
