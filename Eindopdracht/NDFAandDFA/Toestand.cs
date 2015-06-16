using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NDFAAndDFA
{
    public class Toestand<T>
    {
        public string Name;
        public Tuple<string, T> VolgendeToestand;//naam volgende toestand met actie
        public string VorigeToestand;

        public Toestand(string name, Tuple<string, T> volgendeToestand)
        {
            Name = name;
            VolgendeToestand = volgendeToestand;
            VorigeToestand = name;
        }

        public void Reverse()
        {
            string tempVorigeToestand = VorigeToestand;
            VorigeToestand = VolgendeToestand.Item1;
            VolgendeToestand = new Tuple<string,T>(tempVorigeToestand,VolgendeToestand.Item2);
            Name = VorigeToestand;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(VolgendeToestand.Item2.ToString()))
                return "Van toestand '" + Name + "' naar toestand: '" + VolgendeToestand.Item1 + "' met " + ReguliereExpressie.Expressie.EPSILON;
            return "Van toestand '" + Name + "' naar toestand: '" + VolgendeToestand.Item1 + "' met " + VolgendeToestand.Item2.ToString();
        }

        public bool Equals(Toestand<T> other)
        {
            if(this.Name == other.Name && this.VolgendeToestand == other.VolgendeToestand)
            {
                return true;
            }
            else
                return false;
        }
    }
}
