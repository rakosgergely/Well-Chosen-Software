using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    class Foetelek:Etelek
    {
        private bool szezonalise;

        public bool Szezonalise
        {
            get { return szezonalise; }
            set { szezonalise =value; }
        }
        public Foetelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, Izvilag izvilagt, bool szezonalise) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, izvilagt)
        {
            Szezonalise = szezonalise;
        }

        public Foetelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, List<string> allergenek, Izvilag izvilagt, bool szezonalise) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, allergenek, izvilagt)
        {
            Szezonalise = szezonalise;
        }

        public Foetelek(XElement fo) : base(fo.Element("Foetelek"))
        {
            Szezonalise=Boolean.Parse(fo.Attribute("szezonálise").Value);
        }

        public override XElement ToXmlT()
        {
            return  new XElement("Foetelek",new  XAttribute("szezonálise",szezonalise),base.ToXmlT());
        }

        public override string ToString()
        {
            return "Főétel"+":"+ base.ToString();
        }
    }
}
