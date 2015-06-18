using Eindopdracht.NDFAAndDFA;
using Eindopdracht.ReguliereExpressie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    public partial class MainGUI : Form
    {
        private NDFA<char> outputNDFA = null;
        public MainGUI()
        {
            InitializeComponent();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
                return;
            if (radioButton1.Checked)
            {
                try
                {
                    Expressie expressie = new Expressie(InputBox.Text);
                    outputNDFA = expressie.ToNDFA();
                    if (ToDFA.Checked)
                    {
                        OutputBox.Text = outputNDFA.ToDFA().ToString();
                    }
                    if (ToNDFA.Checked)
                    {
                        OutputBox.Text = outputNDFA.ToString();
                    }
                    if (ToReguliereGrammatica.Checked)
                    {
                        OutputBox.Text = outputNDFA.ToReguliereGrammatica().ToString();
                    }
                    string output = "diagraph finite_state_machine {\n";
                    foreach (var t in outputNDFA.Eindtoestanden)
                    {
                        output += "node [shape = doublecircle]; " + t + " ;\n";
                    }
                    output += "node [shape = circle];\n";
                    foreach (var t in outputNDFA.Toestanden)
                    {
                        output += t.Name + " -> " + t.VolgendeToestand.Item1 + " [label=\"" + t.VolgendeToestand.Item2.ToString() + "\"];"+ "\n";
                    }
                    output += "label=\"" + InputBox.Text + "\";\n}";
                    //OutputBox.Text = output;
                    System.IO.File.WriteAllText(@"C:\Users\Bas\Documents\school\jaar 3\Periode 4\Formele methoden\Formele-methoden\output.dot", output);
                }
                catch (Exception exception)
                {
                    OutputBox.Text += "dat gaat niet \n" + exception.ToString();
                }
            }
            else if (radioButton2.Checked)
            {
                NDFA<char> ndfa = new NDFA<char>();
                for (int x = 0; x < InputBox.Lines.Count(); x++)
                {
                    string temp = InputBox.Lines[x];
                    if (temp.StartsWith("begin"))
                        ndfa.StartSymbolen.Add(temp.Last().ToString());
                    else if (temp.StartsWith("eind"))
                        ndfa.Eindtoestanden.Add(temp.Last().ToString());
                    else ndfa.Toestanden.Add(Toestand<char>.CreateToestand(temp));
                    foreach (var t in ndfa.Toestanden)
                    {
                        ndfa.Invoersymbolen.Add(t.VolgendeToestand.Item2);
                    }
                }
                if (ToDFA.Checked)
                {
                    OutputBox.Text = ndfa.ToDFA().ToString();
                }
                if (ToNDFA.Checked)
                {
                    OutputBox.Text = ndfa.ToString();
                }
                if (ToReguliereGrammatica.Checked)
                {
                    OutputBox.Text = ndfa.ToReguliereGrammatica().ToString();
                }
                outputNDFA = ndfa;
            }
           
        }
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ToDFA_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void ToDFA_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = !button1.Visible;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            InputBox.Text = OutputBox.Text = "";
            outputNDFA = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
                return;
            if (outputNDFA == null)
            {
                Expressie expressie = new Expressie(InputBox.Text);
                outputNDFA = expressie.ToNDFA();
            }
            OutputBox.Text = outputNDFA.ToDFA().Minimalize().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            InputBox.Text = "00a\n01b\n12a\n11b\n20a\n23b\n34a\n32b\n45a\n43b\n50a\n53b\nbegin 0\neind 4";
        }
    }
}
