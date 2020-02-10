using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum Izvilag
    {
        Keleti,Magyaros,Mediterrán,Frissítő,Könnyű,Nehéz,Savanykás,Édes,Karakteres,Intenzív,Lágy,Fűszeres
    }
    enum EtelT
    {
        Előétel,Főétel,Desszert
    }
   abstract class Etelek:Termekek
    {
        public EtelT et;

        public  EtelT Et
        {
            get { return et; }
            set { et = value; }
        }

        private bool hidege;

        public bool Hidege
        {
            get { return hidege; }
            set { hidege = value; }
        }
        private bool frissenkeszulte;

        public bool Frissenkeszulte
        {
            get { return frissenkeszulte; }
            set { frissenkeszulte = value; }
        }
        private bool vegetarianuse;

        public bool Vegetrianuse
        {
            get { return vegetarianuse; }
            set { vegetarianuse = value; }
        }
        private bool vegane;

        public bool Vegane
        {
            get { return vegane; }
            set { vegane = value; }
        }
        private bool glutenme;

        public bool Glutenme
        {
            get { return glutenme; }
            set { glutenme = value; }
        }
        private bool laktozme;

        public bool Laktozme
        {
            get { return laktozme; }
            set { laktozme = value; }
        }

        private List<string> allergenek;

        public List<string> Allergenek
        {
            get { return allergenek; }
            set { allergenek = value; }
        }
        private Izvilag izvilagt;

        public Izvilag IzvilagT
        {
            get { return izvilagt; }
            set { izvilagt = value; }
        }


        protected Etelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme,  Izvilag izvilagt) : base(termekkod, nev, ar, mennyiseg, mt, keszleten)
        {
            this.et = et;
            Hidege = hidege;
            Frissenkeszulte = frissenkeszulte;
            Vegetrianuse = vegetarianuse;
            Vegane = vegane;
            Glutenme = glutenme;
            Laktozme = laktozme;
           
            IzvilagT = izvilagt;
        }

        protected Etelek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten, EtelT et, bool hidege, bool frissenkeszulte, bool vegetarianuse, bool vegane, bool glutenme, bool laktozme, List<string> allergenek, Izvilag izvilagt) : base(termekkod, nev, ar, mennyiseg, mt, keszleten)
        {
            this.et = et;
            Hidege = hidege;
            Frissenkeszulte = frissenkeszulte;
            Vegetrianuse = vegetarianuse;
            Vegane = vegane;
            Glutenme = glutenme;
            Laktozme = laktozme;
            Allergenek = new List<string>();
            IzvilagT = izvilagt;
        }

        protected Etelek(XElement et) : base(et.Element("Etelek"))
        {
            this.et = (EtelT) int.Parse(et.Attribute("tipusa").Value);
            Hidege=Boolean.Parse(et.Attribute("hidege").Value);
            Frissenkeszulte=Boolean.Parse(et.Attribute("frissenkeszult").Value);
            Vegetrianuse=Boolean.Parse(et.Attribute("vegeterianus").Value);
            Vegane=Boolean.Parse(et.Attribute("vegan").Value);
            Glutenme=Boolean.Parse(et.Attribute("glutenm").Value);
            Laktozme=Boolean.Parse(et.Attribute("laktozm").Value);
            Allergenek = (from allergenek in et.Element("allergenek").Elements("allergenek")
                select allergenek.Attribute("allergen").Value).ToList();
            IzvilagT = (Izvilag) int.Parse(et.Attribute("etelizvilag").Value);
        }

        public override XElement ToXmlT()
        {
            return new XElement(new XElement("Etelek",new  XAttribute("tipusa",et),new XAttribute("hidege",hidege),new XAttribute("frissenkeszult",frissenkeszulte),new XAttribute("vegetarianus",vegetarianuse),new  XAttribute("vegan",vegane),new XAttribute("glutenm",glutenme),new XAttribute("laktozm",laktozme),new XElement("alergenek",allergenek), base.ToXmlT()));
        }

      /*  public override string ToString()
        {
            return $"Étel {(vegane)},{(vegetarianuse)},{(laktozme)},{(glutenme)}"+ base.ToString();
        }*/
    }
}
