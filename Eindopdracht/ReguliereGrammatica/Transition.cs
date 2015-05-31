using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class Transition<T>
    {
        public static char EPSILON = '$';
    
        private T fromState;
        private char symbol;
        private T toState;

       // this constructor can be used to define loops:
        public Transition(T fromOrTo, char s)
        {
            //this (fromOrTo, s, fromOrTo);
            this.fromState = fromOrTo;
            this.symbol = s;
        }

        public Transition(T from, T to)
        {
            //this(from, EPSILON, to);
            this.fromState = from;
            this.toState = to;
        }

        public Transition(T from, char s, T to)
        {
            this.fromState = from;
            this.symbol = s;
            this.toState = to;
        }
            
        // overriding equals
        //public bool equals ( Object other )
        //{
        //   if ( other == null )
        //      {
        //      return false;
        //      }
        //   else if ( other instanceof Transition )
        //      {
        //           return this.fromState.equals (((Transition )other ).fromState) && this.toState.equals (((Transition )other ).toState) && this.symbol == (((Transition )other ).symbol);
        //      }
        //   else return false;
        //}
    
        //public int compareTo(Transition<T> t) 
        //{
        //    int fromCmp = fromState.compareTo(t.fromState);
        //    int symbolCmp = new Character (symbol).compareTo(new Character (t.symbol));
        //    int toCmp = toState.compareTo(t.toState);
        
        //    return (fromCmp != 0 ? fromCmp : (symbolCmp != 0 ? symbolCmp : toCmp));
        //}

        public T getFromState()
        {
            return fromState;
        }

        public T getToState()
        {
            return toState;
        }
    
        public char getSymbol()
        {
            return symbol;
        }
    
        public String toString()
        {
           return "(" + this.getFromState() + ", " + this.getSymbol() + ")" + "-->" +  this.getToState();
        }
    }
}
