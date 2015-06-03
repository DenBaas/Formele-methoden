using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            var a =  getExampleSlide8Lesson2();
            var b = voorbeeldGrammatica();
            Console.WriteLine(b.toString());
            Console.WriteLine("test");
        }

        static public Grammatica<char> voorbeeldGrammatica()
        {
            Grammatica<char> gr = null;
            ProductieRegel<char> p1 = new ProductieRegel<char>("A", 'a', "B");
            ProductieRegel<char> p2 = new ProductieRegel<char>("A", 'b', "A");
            ProductieRegel<char> p3 = new ProductieRegel<char>("B", 'a', "B");
            ProductieRegel<char> p4 = new ProductieRegel<char>("B", 'b', "A");
            ProductieRegel<char> p5 = new ProductieRegel<char>("A", '$', "C");
            ProductieRegel<char> p6 = new ProductieRegel<char>("C", 'a', "B");
            HashSet<ProductieRegel<char>> productieregels = new HashSet<ProductieRegel<char>>();
            productieregels.Add(p2);
            productieregels.Add(p1);
            productieregels.Add(p5);
            productieregels.Add(p3);
            productieregels.Add(p4);
            productieregels.Add(p6);
            gr = new Grammatica<char>("A", productieregels);
            return gr;
        }

        static public Automata<String> getExampleSlide8Lesson2()
        {
            char[] alphabet = { 'a', 'b' };
            Automata<String> m = new Automata<String>(alphabet);

            m.addTransition(new Transition<String>("q0", 'a', "q1"));
            m.addTransition(new Transition<String>("q0", 'b', "q4"));

            m.addTransition(new Transition<String>("q1", 'a', "q4"));
            m.addTransition(new Transition<String>("q1", 'b', "q2"));

            m.addTransition(new Transition<String>("q2", 'a', "q3"));
            m.addTransition(new Transition<String>("q2", 'b', "q4"));

            m.addTransition(new Transition<String>("q3", 'a', "q1"));
            m.addTransition(new Transition<String>("q3", 'b', "q2"));

            // the error state, loops for a and b:
            m.addTransition(new Transition<String>("q4", 'a'));
            m.addTransition(new Transition<String>("q4", 'b'));

            // only on start state in a dfa:
            m.defineAsStartState("q0");

            // two final states:
            m.defineAsFinalState("q2");
            m.defineAsFinalState("q3");

            return m;
        }


        static public Automata<String> getExampleSlide14Lesson2()
        {
            char[] alphabet = { 'a', 'b' };
            Automata<String> m = new Automata<String>(alphabet);

            m.addTransition(new Transition<String>("A", 'a', "C"));
            m.addTransition(new Transition<String>("A", 'b', "B"));
            m.addTransition(new Transition<String>("A", 'b', "C"));

            m.addTransition(new Transition<String>("B", 'b', "C"));
            m.addTransition(new Transition<String>("B", "C"));

            m.addTransition(new Transition<String>("C", 'a', "D"));
            m.addTransition(new Transition<String>("C", 'a', "E"));
            m.addTransition(new Transition<String>("C", 'b', "D"));

            m.addTransition(new Transition<String>("D", 'a', "B"));
            m.addTransition(new Transition<String>("D", 'a', "C"));

            m.addTransition(new Transition<String>("E", 'a'));
            m.addTransition(new Transition<String>("E", "D"));

            // only on start state in a dfa:
            m.defineAsStartState("A");

            // two final states:
            m.defineAsFinalState("C");
            m.defineAsFinalState("E");

            return m;
        }
    }
}
