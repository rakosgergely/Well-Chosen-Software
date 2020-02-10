using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen
{
    enum EtkezteteT
    {
       Alacart,Önkiszolgáló
    }

    enum Et
    {
        Mediterrán,Amerikai,Magyaros,Keleties
    }
    class Etterem:Vendelatoegysegek
    {
        private EtkezteteT etkeztetesT;

      

        public EtkezteteT EtkeztetesT
        {
            get { return etkeztetesT; }
            set { etkeztetesT = value; }
        }
        private bool elozene;

        public bool Elozene
        {
            get { return elozene; }
            set { elozene = value; }
        }
        private Et etteremt;

        public Et Etteremt
        {
            get { return etteremt; }
            set { etteremt = value; }
        }

        public Etterem(string cegszam, string nev, int iranyitoSzam, string varos, string utca, int hazszam, Vtipus tipus, int ferohelyek, string email, string telefonszam, int nyitvat, EtkezteteT etkeztetesT, bool elozene, Et etteremt) : base(cegszam, nev, iranyitoSzam, varos, utca, hazszam, tipus, ferohelyek, email, telefonszam, nyitvat)
        {
            EtkeztetesT = etkeztetesT;
            Elozene = elozene;
            Etteremt = etteremt;
        }

        public Etterem(XElement e ) : base(e.Element("Étterem"))
        {
            EtkeztetesT = (EtkezteteT) int.Parse(e.Attribute("etkeztetestipusa").Value);
            Elozene = Boolean.Parse(e.Attribute("elozene").Value);
            Etteremt = (Et)Int16.Parse(e.Attribute("etteremtipusa").Value);
        }

        public override XElement ToXML()
        {
            return new XElement("Étterem",new  XAttribute("etkeztetestipusa",etkeztetesT),new XAttribute("elozene",elozene),new XAttribute("etteremtipusa",etteremt), base.ToXML());
        }

        public override string ToString()
        {
            return "Étterem"+" "+ base.ToString();
        }
    }
}
