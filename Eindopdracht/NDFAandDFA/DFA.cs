﻿using Eindopdracht.NDFA;
using Eindopdracht.NFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.DFA
{
    class DFA<T> : NDFA<T>
    {
        public DFA()
        {

        }

        public NDFA<T> Reverse()
        {
            //List<Toestand<T>> newToestanden = new List<Toestand<T>>();
            //foreach (Toestand<T> t in Toestanden)
            //{
            //    newToestanden.Add(new Toestand<T>(t.Name, t.Action, t.VorigeToestand, t.VolgendeToestand));
            //}
            //string newEnd = this.Eindtoestanden.ToList()[0];
            //SortedSet<string> newEnds = new SortedSet<string>();
            //newEnds.Add(StartSymbool);
            //NDFA<T> newNDFA = new NDFA<T>(newToestanden,this.Invoersymbolen,newEnd,newEnds);

            return null;
        }
    }

}
