using Eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class DFA<T> : NDFA<T>
    {
        public DFA()
        {

        }

        public NDFA<T> Reverse()
        {
            NDFA<T> reversed = new NDFA<T>();
            reversed.Invoersymbolen = Invoersymbolen;//hetzelfde
            reversed.StartSymbolen = Eindtoestanden;
            reversed.Eindtoestanden = StartSymbolen;
            reversed.Toestanden = Toestanden;
            foreach(Toestand<T> t in reversed.Toestanden)
                t.Reverse();
            return reversed ;
        }

        //Minimalize
        //ToReguliereGrammatica
        //Equals
        //And
        //Or
        //Not        
    }

}
