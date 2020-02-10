using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well_Choosen.Classes
{
    [Serializable]
    static class EtteremAb
    {
        static SqlConnection connection = new SqlConnection();
        static SqlCommand command = new SqlCommand();

         static EtteremAb()
        {
            connection=new SqlConnection();
            command= new SqlCommand();
            command.Connection = connection;//nem biztos
        }
        public static void vconnect(string constr)
        {
            try
            {
                connection.ConnectionString = constr;
                connection.Open();
                command.Connection = connection;


            }
            catch (Exception e)
            {

                throw new DBException("A kapcsoloódás nem sikerült", e);
            }
        }

        public static void Vbontas()
        {
            try
            {
                connection.Close();
                connection.Dispose();
            }
            catch (Exception e)
            {

                throw new DBException("A kacsolat bontása nem sikerült", e);
            }
        }

        public static List<Vendelatoegysegek> Vkiolvas()
        {
            try
            {
                command.CommandText =
                    "SELECT * FROM [Vendeglatoegysegek] INNER JOIN [Étterem] ON [Vendeglatoegysegek].[cegszam] = [Étterem].[cegszam]";
                SqlDataReader reader = command.ExecuteReader();
                List<Vendelatoegysegek> vlist = new List<Vendelatoegysegek>();
                
                    while (reader.Read())
                    {
                        vlist.Add(new Etterem(reader["cegszam"].ToString(), reader["nev"].ToString(),
                            (int)reader["iranyitoszam"], reader["varos"].ToString(), reader["utca"].ToString(),
                            (int)reader["hazszam"], (Vtipus)(int)reader["tipusa"], (int)reader["ferohelyekszama"],
                            reader["email"].ToString(), reader["telefonszam"].ToString(), (int)reader["nyitvatartas"],
                            (EtkezteteT)(int)reader["etkeztetestipusa"], (int)reader["elozene"]==1,
                            (Et)(int)reader["etteremtipusa"]));
                    }

                    reader.Close();
                
              
                command.CommandText =
                    "SELECT * FROM [Vendeglatoegysegek] INNER JOIN [Kavezo] ON [Vendeglatoegysegek].[cegszam]=[Kavezo].[cegszam]";


                reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vlist.Add(new Kavezo(reader["cegszam"].ToString(), reader["nev"].ToString(),
                            (int) reader["iranyitoszam"], reader["varos"].ToString(), reader["utca"].ToString(),
                            (int) reader["hazszam"], (Vtipus) (int) reader["tipusa"], (int) reader["ferohelyekszama"],
                            reader["email"].ToString(), reader["telefonszam"].ToString(), (int) reader["nyitvatartas"],
                            (int) reader["reggelivane"] == 1, (int) reader["kerthelységvane"] == 1));

                    }
                    reader.Close();
                
               
                command.CommandText =
                    "SELECT * FROM[Vendeglatoegysegek] INNER JOIN [Koktelbarok] ON [Vendeglatoegysegek].[cegszam]=[Koktelbarok].[cegszam]";
                reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vlist.Add(new Koktelbar((string)reader["cegszam"].ToString(), reader["nev"].ToString(),
                            (int)reader["iranyitoszam"], reader["varos"].ToString(), reader["utca"].ToString(), 
                                (int) reader["hazszam"], (Vtipus)(int) reader["tipusa"], (int)reader["ferohelyekszama"],
                            reader["email"].ToString(), reader["telefonszam"].ToString(), (int)reader["nyitvatartas"],
                            (int)reader["etelvane"] == 1, (int)reader["asztalokkalrendelkezike"] == 1));
                    }

                    reader.Close();
                
              
                command.CommandText =
                    "SELECT * FROM [Vendeglatoegysegek] INNER JOIN [StreetFood] ON [Vendeglatoegysegek].[cegszam]=[StreetFood].[cegszam]";
                reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vlist.Add(new StreetFood(reader["cegszam"].ToString(), reader["nev"].ToString(),
                            (int)reader["iranyitoszam"], reader["varos"].ToString(), reader["utca"].ToString(),
                            (int)reader["hazszam"], (Vtipus)(int)reader["tipusa"], (int)reader["ferohelyekszama"],
                            reader["email"].ToString(), reader["telefonszam"].ToString(), (int)reader["nyitvatartas"],
                            (int)reader["alacart"] == 1, (StStilus)(int)reader["stilusa"]));
                    }

                    reader.Close();
                
               
                return vlist;
            }
            catch (Exception e)
            {

                throw new DBException("A kiolvasás sikertelen !", e);
            }
        }

        public static void VBeszuras(Vendelatoegysegek uj)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = String.Format(
                    "INSERT INTO [Vendeglatoegysegek] VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                    uj.Cegszam, uj.Nev, uj.IranyitoSzam, uj.Varos, uj.Utca, (int)uj.Hazszam,(int) uj.Tipus,(int) uj.Ferohelyek,
                    uj.Email, uj.Telefonszam,(int) uj.Nyitvat);
                command.ExecuteNonQuery();
                
              //  if (command.ExecuteNonQuery() == 1)
               // {
                    if (uj is Etterem)
                    {
                        command.Parameters.Clear();
                        command.CommandText = String.Format("INSERT INTO [Étterem] VALUES ('{0}','{1}','{2}','{3}')",
                                uj.Cegszam, (int) (uj as Etterem).EtkeztetesT,Convert.ToInt16((uj as Etterem).Elozene ? 1 : 0),
                            (int)(uj as Etterem).Etteremt);
                        command.ExecuteNonQuery();
                    }
                    else if (uj is Kavezo)
                    {
                        command.Parameters.Clear();
                        command.CommandText = String.Format("INSERT INTO [Kavezo] VALUES('{0}','{1}','{2}')",
                           uj.Cegszam,Convert.ToInt16((uj as Kavezo).Regelivane ? 1 : 0),Convert.ToInt16((uj as Kavezo).Kerthelysegvane ? 1 : 0));
                        command.ExecuteNonQuery();
                    }
                    else if (uj is Koktelbar)
                    {
                        command.Parameters.Clear();
                        command.CommandText = String.Format("INSERT INTO [Koktelbarok] VALUES('{0}','{1}','{2}')",
                            uj.Cegszam, Convert.ToInt16((uj as Koktelbar).Etelvane ? 1 : 0),Convert.ToInt32((uj as Koktelbar).Asztallalrendelkezike ? 1 : 0));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.Parameters.Clear();
                        command.CommandText = String.Format("INSERT INTO [StreetFood] VALUES('{0}','{1}','{2}')",
                            uj.Cegszam,Convert.ToInt16((uj as StreetFood).Alacarte ? 1 : 0), (int) (uj as StreetFood).Sts);
                        command.ExecuteNonQuery();
                    }
               // }

               // command.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new DBException("A beszurás nem sikerült vagy a cégszám már létezik !", e);
            }
        }

        public static void VModosit(Vendelatoegysegek modosit)
        {
            try
            {
                command.CommandText = String.Format(
                    "UPDATE [Vendeglatoegysegek] SET [nev]='{0}',[iranyitoszam]='{1}',[varos]='{2}',[utca]='{3}',[hazszam]='{4}',[tipusa]='{5}',[ferohelyekszama]='{6}',[email]='{7}',[telefonszam]='{8}',[nyitvatartas]='{9}' WHERE [cegszam]='{10}'",
                    modosit.Nev, modosit.IranyitoSzam, modosit.Varos, modosit.Utca, modosit.Hazszam, modosit.Tipus,
                    modosit.Ferohelyek, modosit.Email, modosit.Email, modosit.Telefonszam, modosit.Nyitvat,
                    modosit.Cegszam);
                if (command.ExecuteNonQuery() == 1)
                {
                    if (modosit is Etterem)
                    {
                        command.CommandText = String.Format(
                            "UPDATE [Étterem] SET [etkeztetestipusa]='{0}',[elozene]='{1}',[etteremtipusa]='{2}' WHERE [cegszam]='{3}'",
                            (int) (modosit as Etterem).EtkeztetesT, (modosit as Etterem).Elozene ? 1 : 0,
                            (int) (modosit as Etterem).Etteremt, modosit.Cegszam);
                    }
                    else if (modosit is Kavezo)
                    {
                        command.CommandText = String.Format(
                            "UPDATE [Kavezo] SET [regelivane]='{0}',[kerthelységvane]='{1}' WHERE [cegszam]='{2}'",
                            (modosit as Kavezo).Regelivane ? 1 : 0, (modosit as Kavezo).Kerthelysegvane ? 1 : 0,
                            modosit.Cegszam);
                    }
                    else if (modosit is Koktelbar)
                    {
                        command.CommandText = String.Format(
                            "UPDATE [Koktelbarok] SET [etelvane]='{0}',[asztalokkalrendelkezike]='{1}' WHERE [cegszam]='{2}'",
                            (modosit as Koktelbar).Etelvane ? 1 : 0,
                            (modosit as Koktelbar).Asztallalrendelkezike ? 1 : 0, modosit.Cegszam);
                    }
                    else
                    {
                        command.CommandText =
                            String.Format(
                                "UPDATE [StreetFood] SET [alacart]='{0}',[stilusa]='{1}' WHERE [cegszam]='{2}'",
                                (modosit as StreetFood).Alacarte ? 1 : 0, (int) (modosit as StreetFood).Sts,
                                modosit.Cegszam);
                    }

                }

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new DBException("A modosítás sikertelen!", e);
            }
        }

        public static void Torol(Vendelatoegysegek torol)
        {
            try
            {
                if (torol is Etterem)
                {
                  command.CommandText=String.Format("DELETE FROM [Étterem] WHERE [cegszam]='{0}'",(torol as Etterem).Cegszam);  
                }
                else if (torol is Kavezo)
                {
                    command.CommandText = String.Format("DELETE FROM [Kavezo] WHERE [cegszam]='{0}'",(torol as Kavezo).Cegszam);
                }

                else if (torol is Koktelbar )
                {
                    command.CommandText = String.Format("DELETE FROM [Koktelbarok] WHERE [cegszam]='{0}'",(torol as Koktelbar).Cegszam);

                }
                else
                {
                    command.CommandText = String.Format("DELETE FROM [StreetFood] WHERE [cegszam]='{0}'",(torol as StreetFood).Cegszam);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
               
                throw new DBException("A törlés sikertelen!",e);
            }
        }
    

}
}

