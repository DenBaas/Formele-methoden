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

        public bool Equals(DFA<T> other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.Eindtoestanden == other.Eindtoestanden && this.Invoersymbolen == other.Invoersymbolen && this.StartSymbolen == other.StartSymbolen && this.Toestanden == other.Toestanden)
            {
                return true;
            }
            else
                return false;
        }

        /*public bool equals(Object other)
        {
            if (other == null)
            {
                return false;
            }
            else if (other.GetType() == typeof(Transition<T>))
            {
                return this.fromState.Equals(((Transition<T>)other).fromState) && this.toState.Equals(((Transition<T>)other).toState) && this.symbol == (((Transition<T>)other).symbol);
            }
            else return false;
        }*/

        //Minimalize
        //ToReguliereGrammatica
        //Equals
        //And
        //Or
        //Not        
    }

}
