using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class ProductieRegel<T>
    {
        public string linkerkant;
        public T x;
        public string rechterkant;

        public ProductieRegel(string start, T x, string eind)
        {
            this.linkerkant = start;
            this.x = x;
            this.rechterkant = eind;
        }

        public String toString()
        {
            return "" + linkerkant + " --> " + x + rechterkant;
        }
    }
}
