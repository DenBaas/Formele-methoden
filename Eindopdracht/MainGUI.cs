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
                    if (ToDFA.Checked)
                    {
                        OutputBox.Text = expressie.ToNDFA().ToDFA().ToString();
                    }
                    if (ToNDFA.Checked)
                    {
                        OutputBox.Text = expressie.ToNDFA().ToString();
                    }
                    if (ToReguliereGrammatica.Checked)
                    {
                        OutputBox.Text = expressie.ToNDFA().ToReguliereGrammatica().ToString();
                    }
                }
                catch (Exception exception)
                {
                    OutputBox.Text += "da gaai nie! " + exception.ToString();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
                return;
            Expressie expressie = new Expressie(InputBox.Text);
            OutputBox.Text = "Minimalisatie:\n" +expressie.ToNDFA().ToDFA().Minimalize().ToString();
        }
    }
}
