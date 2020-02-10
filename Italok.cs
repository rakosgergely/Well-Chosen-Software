using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum IzvilagTipus
    {
        Könnyű,Nehéz,Markáns,Testes,Karakteres,Friss,Űdítő,Savanyú,Keserű,Édes
    }
    enum Italtipusok
    {
        Alkoholos,Alkoholmentes
    }
  abstract  class Italok:Termekek
    {
        private Italtipusok  it;


        public Italtipusok  It
        {
            get { return it; }
           private set { it = value; }
        }
        private IzvilagTipus izt;

        public IzvilagTipus Izt
        {
            get { return izt; }
            set { izt = value; }
        }

        public Italok(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, Italtipusok it, IzvilagTipus izt) : base(termekkod, nev, ar, mennyiseg, mt, keszleten)
        {
            this.it = it;
           Izt = izt;
        }

        public Italok(XElement ita) : base(ita.Element("Italok"))
        {
            this.it = (Italtipusok) int.Parse(ita.Attribute("tipus").Value);
            Izt = (IzvilagTipus) int.Parse(ita.Attribute("izalizvilag").Value);
        }

        public override XElement ToXmlT()
        {
            return  new XElement("Italok",new XAttribute("tipus",it),new  XAttribute("italizvilag",izt), base.ToXmlT());
        }

        public override string ToString()
        {
            return base.ToString()+$"{It}";
        }
        
    }
}
