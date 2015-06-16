using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eindopdracht;
using Eindopdracht.NDFAAndDFA;

namespace Eindopdracht.ReguliereExpressie
{
    public class Expressie//: IComparable
    {
        Operator op;
        public const string EPSILON = "ԑ";
        String terminals;
        // De mogelijke operatoren voor een reguliere expressie (+, *, |, .) 
        // Daarnaast ook een operator definitie voor 1 keer repeteren (default)
        public enum Operator { PLUS, STAR, OR, DOT, ONE}    
        Expressie left;
        Expressie right;
        //Comparer<String> compareByLength = new Comparer<String> ()
        //    {
        //        public int compare(String s1, String s2)
        //        {
        //        if (s1.Length == s2.Length)
        //            {return s1.CompareTo(s2);}
        //        else
        //            {return s1.Length - s2.Length;}
        //        }
        //    };
        public Expressie()
        {
            op = Operator.ONE;
            terminals = "";
            left = null;
            right = null;
        }
    
        public Expressie(String p)
        {
            op = Operator.ONE;
            terminals = p;
            left = null;
            right = null;
        }
    
        public Expressie plus()
        {
            Expressie result = new Expressie();
            result.op = Operator.PLUS;
            result.left = this;
            return result;
        }

        public Expressie star()
        {
            Expressie result = new Expressie();
            result.op = Operator.STAR;
            result.left = this;
            return result;
        }

        public Expressie or(Expressie e2)
        {
            Expressie result = new Expressie();
            result.op = Operator.OR;
            result.left = this;
            result.right = e2;
            return result;
        }

        public Expressie dot(Expressie e2)
        {
            Expressie result = new Expressie();
            result.op = Operator.DOT;
            result.left = this;
            result.right = e2;
            return result;
        }

        public HashSet<String> GetLanguage(int maxSteps)
        {
            HashSet<String> emptyLanguage = new HashSet<String>();
            HashSet<String> languageResult = new HashSet<String>();        
            HashSet<String> languageLeft, languageRight;        
            if (maxSteps < 1) return emptyLanguage;        
            switch (this.op) {
                case Operator.ONE:
                     languageResult.Add(terminals);
                     break;
                case Operator.OR:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.GetLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    languageResult.UnionWith(languageRight);
                    break;
                case Operator.DOT:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.GetLanguage(maxSteps - 1);
                    foreach (String s1 in languageLeft){
                        foreach(String s2 in languageRight){
                            languageResult.Add(s1 + s2);
                        }
                    }
                    break;
                // STAR(*) en PLUS(+) kunnen we bijna op dezelfde manier uitwerken:
                case Operator.STAR:
                case Operator.PLUS:
                    languageLeft = left == null ? emptyLanguage : left.GetLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    for (int i = 1; i < maxSteps; i++){  
                        HashSet<String> languageTemp = new HashSet<String>(languageResult);
                        foreach (String s1 in languageLeft){   
                            foreach (String s2 in languageTemp){  
                                languageResult.Add (s1+s2);
                            }
                        }
                    }
                    if (this.op  == Operator.STAR)
                        {languageResult.Add("");}
                    break;                
                default:
                    Console.WriteLine("getLanguage is nog niet gedefinieerd voor de operator: " + this.op);
                    break;
            }
            return languageResult;
        }
        
        public NDFA<object> ToNDFA()
        {
            NDFA<object> ndfa = new NDFA<object>();
            bool orOperation = false;
            Stack<Tuple<int, Toestand<object>>> bracketLocations = new Stack<Tuple<int, Toestand<object>>>();
            Stack<Toestand<object>> stuffInBrackets = new Stack<Toestand<object>>();
            int index = 0;
            foreach(char c in terminals){
                Toestand<object> t = ndfa.Toestanden.LastOrDefault(y => !y.VolgendeToestand.Item2.Equals(EPSILON));
                if (t == null)
                    t = new Toestand<object>("0", new Tuple<string, object>("0", EPSILON));
                switch (c)
                {
                    case '(':
                        bracketLocations.Push(new Tuple<int, Toestand<object>>(index, t));
                        break;
                    case ')':
                        var indexLastBracket = bracketLocations.Pop();
                        Toestand<object> p = new Toestand<object>(t.VolgendeToestand.Item1, new Tuple<string,object>(indexLastBracket.Item2.Name,EPSILON));
                        stuffInBrackets.Push(p);
                        break;
                    case '*':
                        if (stuffInBrackets.Count == 0)
                        {
                            //epsilon van vorige naar nieuwste
                            Toestand<object> ts = new Toestand<object>(t.Name, new Tuple<string, object>(t.VolgendeToestand.Item1, EPSILON));
                            //epsilon van nieuwste naar vorige
                            Toestand<object> t3 = new Toestand<object>(t.VolgendeToestand.Item1, new Tuple<string, object>(t.Name, EPSILON));
                            ndfa.Toestanden.Add(ts);
                            ndfa.Toestanden.Add(t3);
                        }
                        else
                        {
                            var t5 = stuffInBrackets.Pop();
                            ndfa.Toestanden.Add(t5);
                            ndfa.Toestanden.Add(new Toestand<object>(t5.VolgendeToestand.Item1, new Tuple<string, object>(t5.Name, EPSILON)));
                        }
                        break;
                    case '+':
                        if (stuffInBrackets.Count == 0)
                        {
                            //epsilon van nieuwste naar vorige
                            Toestand<object> t4 = new Toestand<object>(t.VolgendeToestand.Item1, new Tuple<string, object>(t.Name, EPSILON));
                            ndfa.Toestanden.Add(t4);
                        }
                        else
                        {
                            var t6 = stuffInBrackets.Pop();
                            ndfa.Toestanden.Add(t6);
                        }
                        break;
                    case '|':
                        orOperation = true;
                        break;
                    default:
                        if(orOperation)
                        {
                            ndfa.Toestanden.Add(new Toestand<object>(t.Name, new Tuple<string, object>(t.VolgendeToestand.Item1, c.ToString())));
                        }
                        else
                        {
                            if(ndfa.Toestanden.Count == 0)
                                ndfa.Toestanden.Add(new Toestand<object>("0", new Tuple<string, object>((ndfa.Toestanden.Count + 1).ToString(), c.ToString())));
                            else
                                ndfa.Toestanden.Add(new Toestand<object>(t.VolgendeToestand.Item1, new Tuple<string, object>((ndfa.Toestanden.Count + 1).ToString(), c.ToString())));
                        }
                            
                        orOperation = false;
                        break;
                }
                index++;
            }
            ndfa.StartSymbolen.Add(ndfa.Toestanden.First().Name);
            int eindtoestand = 0;
            foreach (var r in ndfa.Toestanden)
            {
                if (eindtoestand < int.Parse(r.VolgendeToestand.Item1))
                    eindtoestand = int.Parse(r.VolgendeToestand.Item1);
                if (!r.VolgendeToestand.Item2.Equals(EPSILON))
                    ndfa.Invoersymbolen.Add(r.VolgendeToestand.Item2);
            }
            ndfa.Eindtoestanden.Add(eindtoestand.ToString());
            return ndfa;
        }



        public bool Equals(Expressie other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.ToString() == other.ToString() && this.terminals == other.terminals && this.op == other.op && this.left == other.left && this.right == other.right)
            {
                return true;
            }
            else
                return false;
        }

        public string ToString()
        {
            string expressie = "";
            Expressie mostleft = left;
            if (mostleft != null)
            {
                while (mostleft != null)
                {
                    mostleft = left.left;
                }
                while (mostleft.right != null)
                {
                    expressie += mostleft.terminals;
                    mostleft = mostleft.right;
                }
            }
            else {
                expressie = terminals;
            }
            return expressie;
        }
    }
}
