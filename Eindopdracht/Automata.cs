using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    public class Automata<T>
    {
        private HashSet<Transition<T>> transitions;

        private SortedSet<T> states;
        private SortedSet<T> startStates;
        private SortedSet<T> finalStates;
        private SortedSet<char> symbols;

        public Automata()
        {
            transitions = new HashSet<Transition<T>>();
            states = new SortedSet<T>();
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
            this.symbols = new SortedSet<char>();
        }

        public Automata(char[] s)
        {
            transitions = new HashSet<Transition<T>>();
            states = new SortedSet<T>();
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
            setAlphabet(s);
        }

        public Automata(SortedSet<char> symbols)
        {
            transitions = new HashSet<Transition<T>>();
            states = new SortedSet<T>();
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
            this.symbols = symbols;
        }

        public void setAlphabet(char[] s)
        {
            this.symbols = new SortedSet<char>(s);
        }

        public void addTransition(Transition<T> t)
        {
            transitions.Add(t);
            states.Add(t.getFromState());
            states.Add(t.getToState());
        }

        public void defineAsStartState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            states.Add(t);
            startStates.Add(t);
        }

        public void defineAsFinalState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            states.Add(t);
            finalStates.Add(t);
        }

        public void printTransitions()
        {
            foreach(Transition<T> t in transitions)
            {
                Console.WriteLine(t.toString());
            }
        }

        public bool isDFA()
        {
            bool isDFA = true;        
            foreach (T from in states)
            {
                foreach (char symbol in symbols)
                {
                    isDFA = isDFA && getToStates(from, symbol).Count() == 1;
                }
            }
            return isDFA;
        }

        public SortedSet<T> getToStates(T from, char symbol)
        {
            // not yet correct: No shit!
            SortedSet<T> reachable = new SortedSet<T>();
            
            

            return reachable;

        }

        public SortedSet<T> epsilonClosure(SortedSet<T> fromStates)
        {
           SortedSet<T> reachable = new SortedSet<T>();
           SortedSet<T> newFound = new SortedSet<T>();
       
            // not yet correct:
           return reachable;
        }
    }
}
