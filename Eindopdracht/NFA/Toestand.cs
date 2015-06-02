using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.NFA
{
    public class Toestand<T>
    {
        public string Name;
        public T Action;
        public string VolgendeToestand;
        public string VorigeToestand;

        public Toestand(string name, T action, string volgendeToestand, string vorigeToestand)
        {
            Name = name;
            Action = action;
            VolgendeToestand = volgendeToestand;
            VorigeToestand = vorigeToestand;
        }
    }
}
