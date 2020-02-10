using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    class Desszert:Etelek
    {
        private bool cukormentese;

        public bool Cukormentese
        {
            get { return cukormentese; }
            set { cukormentese = value; }
        }
        public Desszert(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, Izvilag izvilagt, bool cukormentese) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, izvilagt)
        {
            Cukormentese = cukormentese;
        }

        public Desszert(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, List<string> allergenek, Izvilag izvilagt, bool cukormentese) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, et, hidege, frissenkeszulte, vegetarianuse, vegane, glutenme, laktozme, allergenek, izvilagt)
        {
            Cukormentese = cukormentese;
        }

        public Desszert(XElement d) : base(d.Element("Desszertek"))
        {
            Cukormentese=Boolean.Parse(d.Attribute("cukormentese").Value);
        }

        public override XElement ToXmlT()
        {
            return new XElement("Desszertek", new XAttribute("cukormentese", cukormentese), base.ToXmlT());
        }

        public override string ToString()
        {
            return "Desszert"+":"+ base.ToString();
        }
    }
}
