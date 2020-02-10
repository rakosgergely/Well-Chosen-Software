using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen
{
    enum Vtipus
    {
        Kávézó,Koktélbár,StreetFood,Étterem
    }
    abstract class Vendelatoegysegek
    {
        private string cegszam;

        public string Cegszam
        {
            get { return cegszam; }
            private set
            {
                if (value.Length<10&&value.Length<=12)
                {
                    cegszam = value;
                }
                else
                {
                    throw new ArgumentException("A cégszámnak 10 vagy 12 karakteresnek kel lennie és kötőjelekkel kell elválasztani pl(XX-XX-XXXXXX");
                }
            }
        }
        private string nev;

        public string Nev
        {
            get { return nev; }
            set
            {
                if (value!="")
                {
                    nev = value;
                }
                else
                {
                    throw  new ArgumentException("A név mező nem lehet üres");
                }
                
            }
        }
        private int iranyitoSzam;

        public int IranyitoSzam
        {
            get { return iranyitoSzam; }
            set
            {
                if (value>=1000&&value<=10000)
                {
                    iranyitoSzam = value;
                }
                else
                {
                    throw  new ArgumentException("Az irányítószám hibás");
                }

                
            }
        }
        private string varos;

        public string Varos
        {
            get { return varos; }
            set
            {
                if (value!="")
                {
                    varos = value;
                }

                else
                {
                    throw new  ArgumentException("A város mező kitöltése kötelező");
                }
            }
        }
        private string utca;

        public string Utca
        {
            get { return utca; }
            set
            {
                if (value != "")
                {
                    utca = value;
                }

                else
                {
                    throw new ArgumentException("Az utca mező kitöltése kötelező");
                }
            }
        }
        private int hazszam;

        public int Hazszam
        {
            get { return hazszam; }
            set
            {
                if (value>0&&value<=100)
                {
                    hazszam = value;
                }
                else
                {
                    throw new ArgumentException("Hibás házszám");
                }
            }
        }
        private Vtipus tipus;

        public Vtipus Tipus
        {
            get { return tipus; }
           private set { tipus = value; }
        }
        private int ferohelyek;

        public int Ferohelyek
        {
            get { return ferohelyek; }
            set
            {
                if (value>=10&&value<=100)
                {
                    ferohelyek = value;
                }
                else
                {
                    throw new ArgumentException("A férőhelyek száma hibás minimum 10 fő maximum 1000 fő lehet a létszám");
                }
            }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("@"))
                {
                    email = value;
                }
                else
                {
                    throw  new ArgumentException("Hibás email");
                }
            }
        }
        private string telefonszam;

        public string Telefonszam
        {
            get { return telefonszam; }
            set
            {
                if (value.Length==9)
                {
                    telefonszam = value;
                }
                else
                {
                    throw  new ArgumentException("A telefonszám hibás! Helyes formátuma pl.:309987574");
                }

                
            }
        }
        private int nyitvat;

        public int Nyitvat
        {
            get { return nyitvat; }
            set
            {
                if (value<=24)
                {
                    nyitvat = value;
                }
                else
                {
                    throw new   ArgumentException("Hibás nyitvatartás");
                }
               
            }
        }

        protected Vendelatoegysegek(string cegszam, string nev, int iranyitoSzam, string varos, string utca, int hazszam, Vtipus tipus, int ferohelyek, string email, string telefonszam, int nyitvat)
        {
            this.cegszam = cegszam;
            Nev = nev;
            IranyitoSzam = iranyitoSzam;
            Varos = varos;
            Utca = utca;
            Hazszam = hazszam;
            this.tipus = tipus;
            Ferohelyek = ferohelyek;
            Email = email;
            Telefonszam = telefonszam;
            Nyitvat = nyitvat;
        }

        public Vendelatoegysegek(XElement v)
        {
            this.cegszam = v.Attribute("cegszam").Value;
            Nev = v.Attribute("nev").Value;
            IranyitoSzam = int.Parse(v.Attribute("iranyitoszam").Value);
            Varos = v.Attribute("varos").Value;
            Utca = v.Attribute("utca").Value;
            Hazszam = Int32.Parse(v.Attribute("hazszam").Value);
            this.tipus=(Vtipus)int.Parse(v.Attribute("tipus").Value);
            Ferohelyek = int.Parse(v.Attribute("ferohelyek").Value);
            Email = v.Attribute("email").Value;
            Telefonszam = v.Attribute("telefonszam").Value;
            Nyitvat = int.Parse(v.Attribute("nyitvatartas").Value);
        }

        public virtual XElement ToXML()
        {
            return new XElement("Vendáglátoegysége", new XAttribute("cegszam", cegszam), new XAttribute("nev", nev),
                new XAttribute("iranyitoszam", iranyitoSzam), new XAttribute("varos", varos),
                new XAttribute("utca", utca), new XAttribute("hazszam", hazszam), new XAttribute("tipus", tipus),
                new XAttribute("ferohelyek", ferohelyek), new XAttribute("email", email),
                new XAttribute("telefonszam", telefonszam), new XAttribute("nyitvatartas", nyitvat));
        }

        public override string ToString()
        {
            return $"{Cegszam}:{Nev}";
        }
    }
}
