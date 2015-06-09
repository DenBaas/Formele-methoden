using Eindopdracht;
using Eindopdracht.NDFAAndDFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eindopdracht
{
    public class Grammatica<T>
    {
        public Dictionary<string, HashSet<ProductieRegel<T>>> sortedRules = new Dictionary<string, HashSet<ProductieRegel<T>>>();
        private string startSymbool;
        public HashSet<T> alfabet = new HashSet<T>();

        public Grammatica(string startSymbool, HashSet<ProductieRegel<T>> productieRegels)
        {
            this.startSymbool = startSymbool;
            foreach(ProductieRegel<T> t in productieRegels){
                if(!sortedRules.ContainsKey(t.linkerkant))
                {
                    var a = new HashSet<ProductieRegel<T>>();
                    a.Add(t);
                    sortedRules.Add(t.linkerkant, a);
                }
                else
                    sortedRules[t.linkerkant].Add(t);
                alfabet.Add(t.x);
            }
        }

        public bool Equals(Grammatica<T> other)
        {
            if(other == null)
            {
                return false;
            }
            else if(this.ToString() == other.ToString() && this.startSymbool == other.startSymbool && this.sortedRules == other.sortedRules && this.alfabet == other.alfabet)
            {
                return true;
            }
            else
                return false;
        }

        public String ToString()
        {
            String beschrijving = "";
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> pair in sortedRules)
            {
                beschrijving += pair.Key + " --> ";
                foreach (ProductieRegel<T> t in pair.Value)
                    beschrijving += t.x + t.rechterkant + "|";
                beschrijving = beschrijving.Substring(0,beschrijving.Length-1) + "\n";
            }
            return beschrijving;      
        }

        public NDFA<T> TransformToNDFA()
        {
            NDFA<T> ndfa = new NDFA<T>();
            ndfa.Invoersymbolen = alfabet;
            foreach (KeyValuePair<string, HashSet<ProductieRegel<T>>> toestandEnOvergangen in sortedRules)
            {
                foreach (ProductieRegel<T> t in toestandEnOvergangen.Value)
                {                    
                    Toestand<T> toestand = new Toestand<T>(toestandEnOvergangen.Key,new Tuple<string,T>(t.rechterkant,t.x));
                    ndfa.Toestanden.Add(toestand);
                }
            }
            return ndfa;
        }

        public bool equals(Grammatica<T> other)
        {
            return false;
        }
    }    
}