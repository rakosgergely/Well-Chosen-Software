using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum statusz
    {
        Admin,User
    }
   class Felhasz
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                if (id==0)
                {
                    id = value;
                }
                else
                {
                    id = value;
                }
            }
        }
        private string felhasznev;

        public string Felhasznev
        {
            get { return felhasznev; }
            set { felhasznev = value; }
        }
        private string jelszo;

        public string Jelszo
        {
            get { return jelszo; }
            set { jelszo = value; }
        }
        private statusz fstatusza;

        public statusz Fstatusza
        {
            get { return fstatusza; }
         private  set { fstatusza = value; }
        }

        public Felhasz( string felhasznev, string jelszo, statusz fstatusza)
        {
            
            Felhasznev= felhasznev;
            Jelszo = jelszo;
            this.fstatusza = fstatusza;
        }

        public Felhasz(int id, string felhasznev, string jelszo, statusz fstatusza):this(felhasznev,jelszo,fstatusza)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return Felhasznev;
        }

        public Felhasz(XElement f)
        {
            this.id = int.Parse(f.Attribute("id").Value);
            Felhasznev = f.Attribute("felhasznalonev").Value;
            Jelszo = f.Attribute("jelszo").Value;
            this.fstatusza =(statusz) int.Parse(f.Attribute("statusz").Value);
        }

        public virtual XElement ToXml()
        {
            return new XElement("Felhasznalok",new XAttribute("id",id),new XAttribute("felhaszanlonev",felhasznev),new XAttribute("jelszo",jelszo.GetHashCode()),new XAttribute("statusz",fstatusza));
        }
    }
}
