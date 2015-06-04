using Eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class NDFA<T>
    {
        public HashSet<T> Invoersymbolen = new HashSet<T>();
        public HashSet<Toestand<T>> Toestanden = new HashSet<Toestand<T>>();
        public HashSet<string> StartSymbolen = new HashSet<string>();
        public HashSet<string> Eindtoestanden = new HashSet<string>();

        public NDFA()
        {

        }

        public override string ToString()
        {
            string result = "";
            foreach (Toestand<T> t in Toestanden)
            {
                result += t.ToString() + "\n";
            }
            return result;
        }

        public DFA<T> ToDFA()
        {
            DFA<T> newDFA = new DFA<T>();
            HashSet<Toestand<T>> table = new HashSet<Toestand<T>>();
            //per toestand kijk je per invoersymbool waar je heen kan
            //het resultaat daarvan is de naam van de nieuwe toestand

            //op het eind zet je alle toestanden waar een eindtoestand in zit bij de eindtoestanden
            
            return newDFA;
        }
    }   
}
