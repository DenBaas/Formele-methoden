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

        public DFA<T> Ontkenning()
        {
            DFA<T> dfa = new DFA<T>();
            dfa.Invoersymbolen = Invoersymbolen;
            HashSet<string> eind = new HashSet<string>();
            foreach(Toestand<T> t in Toestanden){
                if(!Eindtoestanden.Contains(t.Name)){
                    eind.Add(t.Name);
                }
            }
            dfa.Eindtoestanden = eind;
            dfa.Toestanden = Toestanden;
            dfa.StartSymbolen = StartSymbolen;
            return dfa;
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
        public DFA<T> Minimalize()
        {
            //toDFA (reverse (toDFA (reverse (dfa)))
            //Console.WriteLine("normaal");
            //Console.WriteLine(ToString() + "\n");
            var a = Reverse();
            //Console.WriteLine("reverse1");
            //Console.WriteLine(a.ToString() + "\n" );
            var b = a.ToDFA();
            //Console.WriteLine("dfa1");
            //Console.WriteLine(b.ToString() + "\n");
            var c = b.Reverse();
            //Console.WriteLine("reverse2");
            //Console.WriteLine(c.ToString() + "\n");
            //Console.WriteLine("dfa2");
            var d = c.ToDFA();
            return d;
        }
        //ToReguliereGrammatica
        //Equals
        //And
        //Or
        //Not        
    }

}
