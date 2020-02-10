using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen
{
    enum StStilus
    {
        Amerikai,Mexikói,Kínai,Szendvicsző
    }
    class StreetFood:Vendelatoegysegek
    {
        private bool alacarte;

        public bool Alacarte
        {
            get { return alacarte; }
            set { alacarte = value; }
        }
        private StStilus sts;

        public StStilus Sts
        {
            get { return sts; }
            set { sts = value; }
        }

        public StreetFood(string cegszam, string nev, int iranyitoSzam, string varos, string utca, int hazszam, Vtipus tipus, int ferohelyek, string email, string telefonszam, int nyitvat,bool alacarte,StStilus st) : base(cegszam, nev, iranyitoSzam, varos, utca, hazszam, tipus, ferohelyek, email, telefonszam, nyitvat)
        {
            Alacarte = alacarte;
            Sts = sts;
        }

        public StreetFood(XElement s) : base(s.Element("StreetFood"))
        {
            Alacarte=Boolean.Parse(s.Attribute("alacart").Value);
            Sts = (StStilus) int.Parse(s.Attribute("stilusa").Value);
        }

        public override XElement ToXML()
        {
            return new XElement("StreetFood",new XAttribute("alacart",alacarte),new XAttribute("stilusa",sts), base.ToXML());
        }

        public override string ToString()
        {
            return "StreetFood"+" "+ base.ToString();
        }
    }
}
