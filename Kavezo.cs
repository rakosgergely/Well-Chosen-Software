using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen
{
    class Kavezo:Vendelatoegysegek
    {
        private bool reggelivane;

        public bool Regelivane
        {
            get { return reggelivane; }
            set { reggelivane = value; }
        }
        private bool kerthelysegvane;

        public bool Kerthelysegvane
        {
            get { return kerthelysegvane; }
            set { kerthelysegvane = value; }
        }

        public Kavezo(string cegszam, string nev, int iranyitoSzam, string varos, string utca, int hazszam, Vtipus tipus, int ferohelyek, string email, string telefonszam, int nyitvat,bool reggelivane,bool kerthelysegvane) : base(cegszam, nev, iranyitoSzam, varos, utca, hazszam, tipus, ferohelyek, email, telefonszam, nyitvat)
        {
            Regelivane = reggelivane;
            Kerthelysegvane = kerthelysegvane;
        }

        public Kavezo(XElement k) : base(k.Element("Kavezo"))
        {
            Regelivane = Boolean.Parse(k.Attribute("reggelivane").Value);
            Kerthelysegvane=Boolean.Parse(k.Attribute("kerthelysegvane").Value);
        }

        public override XElement ToXML()
        {
            return new XElement("Kavezo",new XAttribute("reggelivane",reggelivane),new  XAttribute("kerthelysegvane",kerthelysegvane),base.ToXML());
        }

        public override string ToString()
        {
            return "Kávézo"+" "+ base.ToString();
        }
    }
}
