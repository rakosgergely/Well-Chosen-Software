using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum Alkoholositalfajtak
    {
        wiskey,vodka,gin,tequila,pálinka,cougnac,brandy,bor,sör,pezsgő
    }
    class Alkoholositalok:Italok
    {
        private Alkoholositalfajtak alkf;

      
        public Alkoholositalfajtak Alkf
        {
            get { return alkf; }
            set { alkf = value; }
        }
        public Alkoholositalok(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, Italtipusok it, IzvilagTipus izt,Alkoholositalfajtak alkf) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, it, izt)
        {
            Alkf = alkf;
        }


        public Alkoholositalok(XElement alk) : base(alk.Element("Alkoholositalok"))
        {
            Alkf = (Alkoholositalfajtak)int.Parse(alk.Attribute("fajta").Value);
        }
        public override string ToString()
        {

            return base.ToString()+" " + $"{Alkf}";


        }
    }
}
