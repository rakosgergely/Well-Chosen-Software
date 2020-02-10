using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum eloetelTipus
    {
        Leves,Saláta
    }
    class Eloetelek:Etelek
    {
        public eloetelTipus elot;

        public eloetelTipus Elot
        {
            get { return elot; }
            set { elot = value; }
        }
        public Eloetelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, Izvilag izvilagt, eloetelTipus elot) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, izvilagt)
        {
            this.elot = elot;
        }

        public Eloetelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, List<string> allergenek, Izvilag izvilagt, eloetelTipus elot) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, allergenek, izvilagt)
        {
            this.elot = elot;
        }

        public Eloetelek(XElement elo) : base(elo.Element("Eloetelek"))
        {
            this.elot = (eloetelTipus)int.Parse(elo.Attribute("tipus").Value);

        }

        public override XElement ToXmlT()
        {
            return new XElement("Eloetelek", new XAttribute("tipus", elot), base.ToXmlT());
        }

        public override string ToString()
        {
            return "Előétel"+":"+ base.ToString();
        }
    }
}
