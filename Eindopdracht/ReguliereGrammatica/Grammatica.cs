using Eindopdracht.NDFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eindopdracht
{
    public class Grammatica<T>
    {
        private Dictionary<string, HashSet<ProductieRegel<T>>> sortedRules = new Dictionary<string, HashSet<ProductieRegel<T>>>();
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

        public String toString()
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

        //public NDFA<T> TransformToNDFA()
        //{
        //    NDFA<T> ndfa = null;
            
        //    return ndfa;
        //}

        public bool equals(Grammatica<T> other)
        {
            return false;
        }
    }    
}