﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.ReguliereExpressie
{
    public class Expressie: IComparable
    {
        Operator op;
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

        public HashSet <String>  GetLanguage(int maxSteps)
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
    }
}