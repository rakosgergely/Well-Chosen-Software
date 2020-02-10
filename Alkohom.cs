using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum Alkoholmfajta
    {
        szénsavasúdítő, szénsavmentesüdítő, szénsavasvíz, szénsavmentesvíz, gyümölcslé, kávé, tea, limonádé, turmixok
    }
    class Alkohom : Italok
    {
        private Alkoholmfajta alkoholmfajta;



        public Alkoholmfajta AlkoholmfajtaT
        {
            get { return alkoholmfajta; }
            set { alkoholmfajta = value; }
        }


        public Alkohom(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, Italtipusok it, IzvilagTipus izt, Alkoholmfajta alkoholmfajta) : base(termekkod, nev, ar, mennyiseg, mt, keszleten, it, izt)
        {
            AlkoholmfajtaT = alkoholmfajta;
        }
        public Alkohom(XElement alkm) : base(alkm.Element("Alkoholmentes"))
        {
            AlkoholmfajtaT = (Alkoholmfajta)int.Parse(alkm.Attribute("fajta").Value);

        }

        public override XElement ToXmlT()
        {
            return new XElement("Alkoholmentesitalok", new XAttribute("fajta", alkoholmfajta), base.ToXmlT());
        }
        public override string ToString()
        {
            return base.ToString() + $"{alkoholmfajta}";
        }

    }
}
   

