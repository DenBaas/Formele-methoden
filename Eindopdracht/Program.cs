using Eindopdracht.ReguliereExpressie;
using Eindopdracht.NDFAAndDFA;
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

            a.printTransitions();
            Console.WriteLine(a.isDFA());
            var b = voorbeeldGrammatica();
            var c = voorbeeldExpressie();
            var d = voorbeelDFA();
            var e = voorbeeldNDFA();
            Console.WriteLine("expressie");
            Console.WriteLine(c.toString());
            Console.WriteLine("grammatica");
            Console.WriteLine(b.toString());
            Console.WriteLine("DFA");
            Console.WriteLine(d.ToString());
            Console.WriteLine("REVERSE DFA");
            Console.WriteLine(d.Reverse().ToString());
            Console.WriteLine("NDFA");
            Console.WriteLine(e.ToString());
            Console.WriteLine("NDFA -> DFA");
            Console.WriteLine(e.ToDFA().ToString());
            Console.ReadLine();
        }

        static public NDFA<char> voorbeeldNDFA()
        {
            NDFA<char> ndfa = new NDFA<char>();
            ndfa.Invoersymbolen = new HashSet<char>("ab".ToCharArray());
            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("1", 'a'), "0");
            Toestand<char> t2 = new Toestand<char>("1", new Tuple<string, char>("0", 'b'), "1");
            Toestand<char> t3 = new Toestand<char>("0", new Tuple<string, char>("0", 'b'), "0");
            Toestand<char> t4 = new Toestand<char>("0", new Tuple<string, char>("0", 'a'), "0");
            ndfa.Toestanden.Add(t1);
            ndfa.Toestanden.Add(t2);
            ndfa.Toestanden.Add(t3);
            ndfa.Toestanden.Add(t4);
            ndfa.StartSymbolen.Add("0");
            ndfa.Eindtoestanden.Add("1");
            return ndfa;
        }

        static public DFA<char> voorbeelDFA()
        {
            DFA<char> dfa = new DFA<char>();
            dfa.Invoersymbolen = new HashSet<char>("ab".ToCharArray());
            Toestand<char> t1 = new Toestand<char>("0",new Tuple<string,char>("1",'a'),"0");
            Toestand<char> t2 = new Toestand<char>("1", new Tuple<string, char>("0", 'b'), "1");
            Toestand<char> t3 = new Toestand<char>("0", new Tuple<string, char>("0", 'b'), "0");
            dfa.Toestanden.Add(t1);
            dfa.Toestanden.Add(t2);
            dfa.Toestanden.Add(t3);
            dfa.StartSymbolen.Add("0");
            dfa.Eindtoestanden.Add("1");
            return dfa;
        }

        static public Expressie voorbeeldExpressie()
        {
            return new Expressie("a.b(ab)*");
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
