using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen
{
    class Koktelbar:Vendelatoegysegek
    {
        private bool etelvane;

       

        public bool Etelvane
        {
            get { return etelvane; }
            set { etelvane = value; }
        }
        private bool asztallalrendelkezike;

        public bool Asztallalrendelkezike
        {
            get { return asztallalrendelkezike; }
            set { asztallalrendelkezike = value; }
        }

        public Koktelbar(string cegszam, string nev, int iranyitoSzam, string varos, string utca, int hazszam, Vtipus tipus, int ferohelyek, string email, string telefonszam, int nyitvat, bool etelvane, bool asztallalrendelkezike) : base(cegszam, nev, iranyitoSzam, varos, utca, hazszam, tipus, ferohelyek, email, telefonszam, nyitvat)
        {
            Etelvane = etelvane;
            Asztallalrendelkezike = asztallalrendelkezike;
        }

        public Koktelbar(XElement ko) : base(ko.Element("Koktelbar"))
        {
           Etelvane=Boolean.Parse(ko.Attribute("etelvane").Value);
            Asztallalrendelkezike=Boolean.Parse(ko.Attribute("asztalokkalrendelkezike").Value);
        }

        public override XElement ToXML()
        {
            return new XElement("Koktelbar",new XAttribute("etelvane",etelvane),new  XAttribute("asztalokkalrendelkezike",asztallalrendelkezike), base.ToXML());
        }

        public override string ToString()
        {
            return "Koktélbár"+" "+ base.ToString();
        }
    }
}
