using Eindopdracht.ReguliereExpressie;
using Eindopdracht.NDFAAndDFA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
            
            //var a =  getExampleSlide8Lesson2();

            //a.printTransitions();
            //Console.WriteLine(a.isDFA());
            var b = voorbeeldGrammatica();
            var c = voorbeeldExpressie();
            var d = voorbeelDFA();
            var e = voorbeeldNDFA();
            //Console.WriteLine("expressie");
            //Console.WriteLine(c.ToString());
            //Console.WriteLine("expressie -> ndfa");
            //Console.WriteLine(c.ToNDFA().ToString());
            //Console.WriteLine("get language");
            //Console.WriteLine(c.GetLanguage(3).ToString());

            //Console.WriteLine("grammatica");
            //Console.WriteLine(b.ToString());
            //Console.WriteLine("grammatica -> NDFA");
            //Console.WriteLine(b.TransformToNDFA().ToString());

            //Console.WriteLine("DFA");
            //Console.WriteLine(d.ToString());
            //Console.WriteLine("REVERSE DFA");
            //Console.WriteLine(d.Reverse().ToString());
            
            //Console.WriteLine("Ontkenning");
            //Console.WriteLine(d.Ontkenning().ToString());

            //Console.WriteLine("NDFA");
            //Console.WriteLine(e.ToString());
            //Console.WriteLine("NDFA -> DFA");
            //Console.WriteLine(e.ToDFA().ToString());
            //Console.WriteLine("NDFA -> Reguliere Grammatica");
            //Console.WriteLine(e.ToReguliereGrammatica().ToString());

            Console.WriteLine("Minimaliseren DFA");
            Console.WriteLine(minimaliserenDFA().ToString());
            Console.ReadLine();
        }

        static public NDFA<char> voorbeeldNDFA()
        {
            NDFA<char> ndfa = new NDFA<char>();
            ndfa.Invoersymbolen = new HashSet<char>("ab".ToCharArray());
            //waar je begint, volgende toestand, met letter
            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("1", 'a'));
            Toestand<char> t2 = new Toestand<char>("1", new Tuple<string, char>("0", 'b'));
            Toestand<char> t3 = new Toestand<char>("0", new Tuple<string, char>("0", 'b'));
            Toestand<char> t4 = new Toestand<char>("0", new Tuple<string, char>("2", 'a'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("1", 'b'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("0", 'b'));
            //Toestand<char> t7 = new Toestand<char>("2", new Tuple<string, char>("1", 'c'));
            ndfa.Toestanden.Add(t1);
            ndfa.Toestanden.Add(t2);
            ndfa.Toestanden.Add(t3);
            ndfa.Toestanden.Add(t4);
            ndfa.Toestanden.Add(t5);
            ndfa.Toestanden.Add(t6);
            //ndfa.Toestanden.Add(t7);
            ndfa.StartSymbolen.Add("0");
            ndfa.Eindtoestanden.Add("1");
            return ndfa;
        }

        static public DFA<char> minimaliserenDFA()
        {
            //les 6 dia 14
            DFA<char> dfa = new DFA<char>();
            dfa.Invoersymbolen = new HashSet<char>("ab".ToCharArray());
            Toestand<char> t1 = new Toestand<char>("0", new Tuple<string, char>("0", 'a'));
            Toestand<char> t2 = new Toestand<char>("0", new Tuple<string, char>("1", 'b'));
            Toestand<char> t3 = new Toestand<char>("1", new Tuple<string, char>("2", 'a'));
            Toestand<char> t4 = new Toestand<char>("1", new Tuple<string, char>("1", 'b'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("0", 'a'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("3", 'b'));
            Toestand<char> t7 = new Toestand<char>("3", new Tuple<string, char>("4", 'a'));
            Toestand<char> t8 = new Toestand<char>("3", new Tuple<string, char>("2", 'b'));
            Toestand<char> t9 = new Toestand<char>("4", new Tuple<string, char>("5", 'a'));
            Toestand<char> t10 = new Toestand<char>("4", new Tuple<string, char>("3", 'b'));
            Toestand<char> t11 = new Toestand<char>("5", new Tuple<string, char>("0", 'a'));
            Toestand<char> t12 = new Toestand<char>("5", new Tuple<string, char>("3", 'b'));
            dfa.Toestanden.Add(t1);
            dfa.Toestanden.Add(t2);
            dfa.Toestanden.Add(t3);
            dfa.Toestanden.Add(t4);
            dfa.Toestanden.Add(t5);
            dfa.Toestanden.Add(t6);
            dfa.Toestanden.Add(t7);
            dfa.Toestanden.Add(t8);
            dfa.Toestanden.Add(t9);
            dfa.Toestanden.Add(t10);
            dfa.Toestanden.Add(t11);
            dfa.Toestanden.Add(t12);
            dfa.StartSymbolen.Add("0");
            dfa.Eindtoestanden.Add("4");
            return dfa.Minimalize();
        }

        static public DFA<char> voorbeelDFA()
        {
            DFA<char> dfa = new DFA<char>();
            dfa.Invoersymbolen = new HashSet<char>("ab".ToCharArray());
            Toestand<char> t1 = new Toestand<char>("0",new Tuple<string,char>("0",'a'));
            Toestand<char> t2 = new Toestand<char>("0", new Tuple<string, char>("1", 'b'));
            Toestand<char> t3 = new Toestand<char>("1", new Tuple<string, char>("2", 'a'));
            Toestand<char> t4 = new Toestand<char>("1", new Tuple<string, char>("1", 'b'));
            Toestand<char> t5 = new Toestand<char>("2", new Tuple<string, char>("0", 'a'));
            Toestand<char> t6 = new Toestand<char>("2", new Tuple<string, char>("3", 'b'));
            Toestand<char> t7 = new Toestand<char>("3", new Tuple<string, char>("4", 'a'));
            Toestand<char> t8 = new Toestand<char>("3", new Tuple<string, char>("2", 'b'));
            Toestand<char> t9 = new Toestand<char>("4", new Tuple<string, char>("5", 'a'));
            Toestand<char> t10 = new Toestand<char>("4", new Tuple<string, char>("3", 'b'));
            Toestand<char> t11 = new Toestand<char>("5", new Tuple<string, char>("0", 'a'));
            Toestand<char> t12 = new Toestand<char>("5", new Tuple<string, char>("3", 'b'));
            dfa.Toestanden.Add(t1);
            dfa.Toestanden.Add(t2);
            dfa.Toestanden.Add(t3);
            dfa.Toestanden.Add(t4);
            dfa.Toestanden.Add(t5);
            dfa.Toestanden.Add(t6);
            dfa.Toestanden.Add(t7);
            dfa.Toestanden.Add(t8);
            dfa.Toestanden.Add(t9);
            dfa.Toestanden.Add(t10);
            dfa.Toestanden.Add(t11);
            dfa.Toestanden.Add(t12);
            dfa.StartSymbolen.Add("0");
            dfa.Eindtoestanden.Add("1");
            return dfa;
        }

        static public Expressie voorbeeldExpressie()
        {
            return new Expressie("(ab(ab)*)*");
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
            ProductieRegel<char> p7 = new ProductieRegel<char>("C", 'b', "A");
            HashSet<ProductieRegel<char>> productieregels = new HashSet<ProductieRegel<char>>();
            productieregels.Add(p2);
            productieregels.Add(p1);
            productieregels.Add(p5);
            productieregels.Add(p3);
            productieregels.Add(p4);
            productieregels.Add(p6);
            productieregels.Add(p7);
            gr = new Grammatica<char>("A", productieregels);
            return gr;
        }

        static public Automata<String> getExampleSlide8Lesson2()
        {
            char[] alphabet = { 'a', 'b' };
            Automata<String> m = new Automata<String>(alphabet);

            m.addTransition(new Transition<String>("0", 'a', "1"));
            m.addTransition(new Transition<String>("0", 'b', "4"));

            m.addTransition(new Transition<String>("1", 'a', "4"));
            m.addTransition(new Transition<String>("1", 'b', "2"));

            m.addTransition(new Transition<String>("2", 'a', "3"));
            m.addTransition(new Transition<String>("2", 'b', "4"));

            m.addTransition(new Transition<String>("3", 'a', "1"));
            m.addTransition(new Transition<String>("3", 'b', "2"));

            // the error state, loops for a and b:
            m.addTransition(new Transition<String>("4", 'a'));
            m.addTransition(new Transition<String>("4", 'b'));

            // only on start state in a dfa:
            m.defineAsStartState("0");

            // two final states:
            m.defineAsFinalState("2");
            m.defineAsFinalState("3");

            return m;
        }
    }
}
