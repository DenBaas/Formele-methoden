using Eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            string result = "Start: ";
            foreach (string s1 in StartSymbolen)
                result += s1 + "\t";
            result += "\nEinde: ";
            foreach (string s2 in Eindtoestanden)
                result += "'" +s2 + "'\t";
            result += "\n";
            foreach (Toestand<T> t in Toestanden)
            {
                result += t.ToString() + "\n";
            }
            return result;
        }

        public HashSet<string> GetToestanden()
        {
            HashSet<string> toestanden = new HashSet<string>();
            foreach (Toestand<T> t in Toestanden)
                toestanden.Add(t.Name);
            return toestanden;
        }

        public DFA<T> ToDFA()
        {
            DFA<T> newDFA = new DFA<T>();
            foreach (KeyValuePair<Tuple<string, T>, SortedSet<string>> k in CreateTable())
            {
                Toestand<T> newt = new Toestand<T>(k.Key.Item1, new Tuple<string, T>("", k.Key.Item2));
                foreach (string p in k.Value)
                    newt.VolgendeToestand = new Tuple<string, T>(newt.VolgendeToestand.Item1 + p, newt.VolgendeToestand.Item2);
                newDFA.Toestanden.Add(newt);
            }
            //overbodige toestanden weghalen
            for(int v = newDFA.Toestanden.Count-1; v >= 0; v--)//ar h in newDFA.Toestanden)
            {
                var x = StartSymbolen.FirstOrDefault(p => p == newDFA.Toestanden.ElementAt(v).Name);
                if (x == null)
                {
                    var t = newDFA.Toestanden.FirstOrDefault(f => f.VolgendeToestand.Item1 == newDFA.Toestanden.ElementAt(v).Name && f.Name != newDFA.Toestanden.ElementAt(v).Name);
                    if (t == default(Toestand<T>))
                    {
                        newDFA.Toestanden.Remove(newDFA.Toestanden.ElementAt(v));
                    }
                }
            }
            //eindtoestanden bepalen
            foreach (var g in newDFA.Toestanden)
            {
                foreach (char c in g.Name.ToCharArray())
                {
                    if (Eindtoestanden.Contains(new string(c,1)))
                    {
                        newDFA.Eindtoestanden.Add(g.Name);
                    }
                }
            }
            //begintoestanden bepalen
            newDFA.StartSymbolen = StartSymbolen;
            return newDFA;
        }

        public Dictionary<Tuple<string, T>, SortedSet<string>> CreateTable()
        {
            Dictionary<Tuple<string, T>, SortedSet<string>> toestandenEnWaarJeHeenKan = new Dictionary<Tuple<string, T>, SortedSet<string>>();
            //maak een lege tabel van waar je allemaal heen kan
            foreach (String s in GetToestanden())
            {
                foreach (T t in Invoersymbolen)
                    toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(s, t), new SortedSet<string>());
            }
            //vul de tabel
            foreach (Toestand<T> t in Toestanden)
            {
                var a = new Tuple<string, T>(t.Name, t.VolgendeToestand.Item2);
                toestandenEnWaarJeHeenKan[a].Add(t.VolgendeToestand.Item1);
            }
            //vul de tabel aan met nieuwe waardes!
            for (int i = 0; i < toestandenEnWaarJeHeenKan.Count; i++)
            {
                string newState = "";
                foreach (string s1 in toestandenEnWaarJeHeenKan.ElementAt(i).Value)
                    newState += s1;
                foreach (T t in Invoersymbolen)
                {
                    var r = new Tuple<string, T>(newState, t);
                    if (!toestandenEnWaarJeHeenKan.ContainsKey(r))
                    {
                        //toevoegen
                        toestandenEnWaarJeHeenKan.Add(r, new SortedSet<string>());
                        i = 0;
                    }
                    foreach (var v in toestandenEnWaarJeHeenKan.Where(o => toestandenEnWaarJeHeenKan.ElementAt(i).Value.Contains(o.Key.Item1) && o.Key.Item2.Equals(t)))
                    {
                        if (r.Item1 != "")
                            toestandenEnWaarJeHeenKan[r].UnionWith(v.Value);
                    }
                }
            }
            return toestandenEnWaarJeHeenKan;
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
