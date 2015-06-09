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

        public DFA<T> Minimalize()
        {
            DFA<T> dfa = new DFA<T>();

            return dfa;
        }
        //ToReguliereGrammatica
        //Equals
        //And
        //Or
        //Not        
    }

}
