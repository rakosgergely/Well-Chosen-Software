using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Well_Choosen.Classes
{
    enum MennyisegT
    {
        cl,
        dl,
        dkg,
        db
    }

    abstract class Termekek
    {
        public int termekkod;

        public int Termekkod
        {
            get { return termekkod; }
            set
            {
                if (value >= 1000 && value <= 10000)
                {
                    termekkod = value;
                }

                else
                {
                    throw new ArgumentException("Hibás termékkód");
                }
            }
        }

        private string nev;

        public string Nev
        {
            get { return nev; }
            set
            {
                if (value != "")
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("A  név mező kitöltése kötelező");
                }
            }
        }

        private int ar;

        public int Ar
        {
            get { return ar; }
            set
            {
                if (value > 0)
                {
                    ar = value;
                }
                else
                {
                    throw new ArgumentException("Az ár hibás");
                }
            }
        }

        private int mennyiseg;

        public int Mennyiseg
        {
            get { return mennyiseg; }
            set
            {
                if (value > 0)
                {
                    mennyiseg = value;
                }
                else
                {
                    throw new ArgumentException("A mennyiség hibás");
                }

            }
        }

        public MennyisegT mt;

        public MennyisegT Mt
        {
            get { return mt; }
            set { mt = value; }
        }

        private int keszleten;

        public int Keszleten
        {
            get { return keszleten; }
            set
            {
                if (value>0)
                {
                    keszleten = value;
                }
                else if (value==0)
                {
                    keszleten= mennyiseg;
                }
                else
                {
                    throw new ArgumentException("Kevés a készleten lévő mennyiség");
                }
            }
        }

        protected Termekek(int termekkod, string nev, int ar, int mennyiseg, MennyisegT mt, int keszleten)
        {
            this.termekkod = termekkod;
            Nev = nev;
            Ar = ar;
            Mennyiseg = mennyiseg;
            Mt = mt;
            Keszleten = keszleten;
        }

        public Termekek(XElement t)
        {
            this.termekkod = int.Parse(t.Attribute("termekkod").Value);
            Nev = t.Attribute("nev").Value;
            Ar = int.Parse(t.Attribute("ar").Value);
            Mennyiseg = int.Parse(t.Attribute("mennyiseg").Value);
            Mt = (MennyisegT) int.Parse(t.Attribute("mennyisegtipus").Value);
            Keszleten = int.Parse(t.Attribute("keszleten").Value);
        }

        public virtual XElement ToXmlT()
        {
            return new XElement("Termekek", new XAttribute("termekkod", termekkod), new XAttribute("nev", nev),
                new XAttribute("ar", ar), new XAttribute("mennyiseg", mennyiseg), new XAttribute("mennyisegtipus", mt),
                new XAttribute("keszleten", keszleten));
        }

        public override string ToString()
        {
            return $"{Nev} :Ár: {Ar}Ft  Mennyiség: {Mennyiseg}.{Mt} Készleten van: {Keszleten}.{Mt}";
            
        }

        public  int Raktaron()
        {
            return Convert.ToInt32(Keszleten - Mennyiseg+':'+Mt);
        } 
    }

}





