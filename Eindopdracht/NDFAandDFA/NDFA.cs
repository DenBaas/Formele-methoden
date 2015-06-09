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

        public void NDFAtoDFA()
        {
            List<string> symbolen = new List<string>();
            Dictionary<string, Tuple<string, T>> table = new Dictionary<string, Tuple<string, T>>();
            foreach(Toestand<T> t in Toestanden)
            {
                if(!symbolen.Contains(t.Name))
                {
                    symbolen.Add(t.Name);
                }
            }
            foreach (string s in symbolen)
            {
                Console.WriteLine("The variable in symbolen is: " + s);
            }
            foreach(Toestand<T> t in Toestanden)
            {
                if(symbolen.Contains(t.Name))
                {
                    table.Add(t.Name, t.VolgendeToestand);
                }
            }
            for (int i = 0; i < table.Count; i++)
            {
                
            }
        }
        
        public bool Equals(NDFA<T> other)
        {
            if(other == null)
            {
                return false;
            }
            else if(this.Invoersymbolen == other.Invoersymbolen && this.Toestanden == other.Toestanden && this.StartSymbolen == other.StartSymbolen && this.Eindtoestanden == other.Eindtoestanden)
            {
                return true;
            }
            else
                return false;
        }

        public NDFA()
        {

        }

        public override string ToString()
        {
            string result = "Start: ";
            foreach (string s1 in StartSymbolen)
                result += s1 + "\t";
            result += "\nEinde: ";
            foreach (string s2 in Eindtoestanden)
                result += s2 + "\t";
            result += "\n";
            foreach (Toestand<T> t in Toestanden)
            {
                result += t.ToString() + "\n";
            }
            return result;
        }

        public DFA<T> ToDFA()
        {
            DFA<T> newDFA = new DFA<T>();
            //sorteer alle toestanden op toestand
            Dictionary<string, HashSet<Toestand<T>>> sortedToestanden = new Dictionary<string, HashSet<Toestand<T>>>();
            foreach(Toestand<T> t in Toestanden)
            {
                if (!sortedToestanden.ContainsKey(t.Name))
                {
                    sortedToestanden.Add(t.Name, new HashSet<Toestand<T>>());
                }
                else
                    sortedToestanden[t.Name].Add(t);
            }
            //string = naam van de (nieuwe) toestand 
            //Dictionary bevat per invoersymbool een tuple met de bijbehorende toestanden waar het heen kan
            HashSet<Tuple<string, Dictionary<T, HashSet<string>>>> tabelVanAlles = new HashSet<Tuple<string, Dictionary<T, HashSet<string>>>>();
            Dictionary<T, HashSet<string>> d;
            foreach(string s in StartSymbolen)
            {
                d = new Dictionary<T, HashSet<string>>();
                foreach (T invoer in Invoersymbolen)
                    d.Add(invoer, new HashSet<string>());
                foreach (Toestand<T> t in Toestanden)
                {
                    if (t.Name == s)
                    {
                        d[t.VolgendeToestand.Item2].Add(t.VolgendeToestand.Item1);
                    }
                }
                tabelVanAlles.Add(new Tuple<string,Dictionary<T, HashSet<string>>>(s,d));
            }
            return newDFA;
        }

        public Grammatica<T> ToReguliereGrammatica()
        {
            Grammatica<T> gr = new Grammatica<T>(StartSymbolen.ElementAt(0), new HashSet<ProductieRegel<T>>());
            foreach (Toestand<T> t in Toestanden)
            {
                if (!gr.sortedRules.ContainsKey(t.Name))
                    gr.sortedRules.Add(t.Name, new HashSet<ProductieRegel<T>>());
                gr.sortedRules[t.Name].Add(new ProductieRegel<T>(t.Name, t.VolgendeToestand.Item2,t.VolgendeToestand.Item1));
            }
            return gr;
        }
    }   
}
