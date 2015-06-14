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
            Dictionary<Tuple<string, T>, SortedSet<string>> table = CreateTable();
            foreach (KeyValuePair<Tuple<string, T>, SortedSet<string>> k in table)
            {
                Toestand<T> newt = new Toestand<T>(k.Key.Item1, new Tuple<string, T>("", k.Key.Item2));
                foreach (string p in k.Value)
                {
                    string naam = "";
                    SortedSet<char> d = new SortedSet<char>((newt.VolgendeToestand.Item1 + p).ToCharArray());
                    foreach (char y in d)
                        naam += y;
                    newt.VolgendeToestand = new Tuple<string, T>(naam, newt.VolgendeToestand.Item2);
                }
                newDFA.Toestanden.Add(newt);
            }
            //overbodige toestanden weghalen
            for(int v = newDFA.Toestanden.Count-1; v >= 0; v--)
            {
                var x = StartSymbolen.FirstOrDefault(p => p == newDFA.Toestanden.ElementAt(v).Name);
                if (x == null)
                {
                    var t = newDFA.Toestanden.FirstOrDefault(f => f.VolgendeToestand.Item1 == newDFA.Toestanden.ElementAt(v).Name && f.Name != newDFA.Toestanden.ElementAt(v).Name);
                    if (t == default(Toestand<T>))
                        newDFA.Toestanden.Remove(newDFA.Toestanden.ElementAt(v));
                }
            }
            //eindtoestanden bepalen
            foreach (var g in newDFA.Toestanden)
            {
                foreach (char c in g.Name.ToCharArray())
                {
                    if (Eindtoestanden.Contains(new string(c,1)))
                        newDFA.Eindtoestanden.Add(g.Name);
                }
            }
            //begintoestanden bepalen
            newDFA.StartSymbolen = StartSymbolen;
            newDFA.Invoersymbolen = Invoersymbolen;
            return newDFA;
        }

        /*
         * returns: per naam van de toestand met actie een set met namen van toestanden waar je heen kan
         */
        public Dictionary<Tuple<string, T>, SortedSet<string>> CreateTable()
        {
            Dictionary<Tuple<string, T>, SortedSet<string>> toestandenEnWaarJeHeenKan = new Dictionary<Tuple<string, T>, SortedSet<string>>();
            //maak een lege tabel met toestanden in de rijen in acties in de rijen
            foreach (var s in Toestanden.Where(r => StartSymbolen.Contains(r.Name)))
            {
                foreach (T t in Invoersymbolen)
                    if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string,T>(s.Name, t)))
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(s.Name, t), new SortedSet<string>());
            }
            //vul de tabel EN START VANUIT DE BEGINTOESTANDEN
            foreach (Toestand<T> t in Toestanden.Where(r=> StartSymbolen.Contains(r.Name)))
            {
                var a = new Tuple<string, T>(t.Name, t.VolgendeToestand.Item2);
                toestandenEnWaarJeHeenKan[a].Add(t.VolgendeToestand.Item1);
            }
            //vul de tabel aan met nieuwe waardes!
            for (int i = 0; i < toestandenEnWaarJeHeenKan.Count; i++)
            {
                Tuple<string, T> input = toestandenEnWaarJeHeenKan.Keys.ElementAt(i);
                foreach (char state in input.Item1.ToCharArray())
                {
                    var v = new HashSet<Toestand<T>>();
                    v.UnionWith(Toestanden.Where(v1 => v1.Name == state.ToString() && v1.VolgendeToestand.Item2.Equals(input.Item2)));
                    var v3 = v.Where(t1 => t1.VolgendeToestand.Item2.Equals(input.Item2));
                    foreach (Toestand<T> t2 in v3)
                        toestandenEnWaarJeHeenKan[input].Add(t2.VolgendeToestand.Item1);
                }
                //zonodig nieuwe toestandtoevoegen
                string newstate = "";
                foreach (var c in toestandenEnWaarJeHeenKan[input])
                    newstate += c;
                if (!toestandenEnWaarJeHeenKan.ContainsKey(new Tuple<string, T>(newstate, input.Item2)))
                    foreach(T t in Invoersymbolen)
                        toestandenEnWaarJeHeenKan.Add(new Tuple<string, T>(newstate ,t), new SortedSet<string>());
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
