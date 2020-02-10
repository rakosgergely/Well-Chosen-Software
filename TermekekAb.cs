using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well_Choosen.Classes
{
    [Serializable]
    static class TermekekAb
    {
        private static SqlConnection connection= new SqlConnection();
        private static SqlCommand command= new SqlCommand();

        static TermekekAb()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            command.Connection = connection;
            
        }
        public static void Tconnect(string consts)
        {
            try
            {
                connection.ConnectionString = consts;
                connection.Open();
            }
            catch (Exception e)
            {
               throw new DBException("A kapcsolat létesítése sikertelen!",e);
            }
        }

        public static void TDisconn()
        {
            try
            {

                connection.Close();
                connection.Dispose();
            }
            catch (Exception e)
            {
               throw new DBException("A kapcsolat bontása sikertelen!",e);
            }
        }

        public static List<Termekek> TReader()
        {
            try
            {
                command.CommandText =
                    "SELECT * FROM [Termekek] INNER JOIN [Ettelek] ON [Termekek].[termekkod]=[Ettelek].[termekkod] INNER JOIN [Eloetelek] ON [Ettelek].[termekkod]=[Eloetelek].[termekkod]";
                List<Termekek> termekek=new List<Termekek>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    termekek.Add(new Eloetelek((int)reader["termekkod"],reader["nev"].ToString(),(int)reader["ar"],(int)reader["mennyiseg"],(MennyisegT)(int)reader["mennyisegtipus"],(int)reader["készleten"],(EtelT)(int)reader["tipusa"],(int)reader["hidegmelege"]==1,(int)reader["frissenkeszult"]==1,(int)reader["vegeterianus"]==1,(int)reader["vegan"]==1,(int)reader["glutenm"]==1,(int)reader["laktozm"]==1,(Izvilag)(int)reader["etelizvilag"],(eloetelTipus)(int)reader["tipus"]));
                }
                reader.Close();
                command.CommandText = "SELECT * FROM [Termekek] INNER JOIN [Ettelek] ON [Termekek].[termekkod]=[Ettelek].[termekkod] INNER JOIN [Foetelek] ON [Ettelek].[termekkod]=[Foetelek].[termekkod]";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    termekek.Add(new Foetelek((int)reader["termekkod"], reader["nev"].ToString(), (int)reader["ar"], (int)reader["mennyiseg"], (MennyisegT)(int)reader["mennyisegtipus"], (int)reader["készleten"], (EtelT)(int)reader["tipusa"], (int)reader["hidegmelege"] == 1, (int)reader["frissenkeszult"] == 1, (int)reader["vegeterianus"] == 1, (int)reader["vegan"] == 1, (int)reader["glutenm"] == 1, (int)reader["laktozm"] == 1, (Izvilag)(int)reader["etelizvilag"],(int)reader["szezonalise"]==1));
                }
                reader.Close();
                command.CommandText = "SELECT * FROM [Termekek] INNER JOIN [Ettelek] ON [Termekek].[termekkod]=[Ettelek].[termekkod] INNER JOIN [Desszertek] ON [Ettelek].[termekkod]=[Desszertek].[termekkod]";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    termekek.Add(new Foetelek((int)reader["termekkod"], reader["nev"].ToString(), (int)reader["ar"], (int)reader["mennyiseg"], (MennyisegT)(int)reader["mennyisegtipus"], (int)reader["készleten"], (EtelT)(int)reader["tipusa"], (int)reader["hidegmelege"] == 1, (int)reader["frissenkeszult"] == 1, (int)reader["vegeterianus"] == 1, (int)reader["vegan"] == 1, (int)reader["glutenm"] == 1, (int)reader["laktozm"] == 1, (Izvilag)(int)reader["etelizvilag"], (int)reader["cukormentese"] == 1));
                }
                reader.Close();

                command.CommandText =
                    "SELECT * FROM [Termekek] INNER JOIN [Italok] ON [Termekek].[termekkod]=[Italok].[termekkod] INNER JOIN [Alkoholositalok] ON [Italok].[termekkod]=[Alkoholositalok].[termekkod]";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    termekek.Add(new Alkoholositalok((int)reader["termekkod"], reader["nev"].ToString(), (int)reader["ar"], (int)reader["mennyiseg"], (MennyisegT)(int)reader["mennyisegtipus"], (int)reader["készleten"],(Italtipusok)(int)reader["tipus"],(IzvilagTipus)(int)reader["italizvilag"],(Alkoholositalfajtak)(int)reader["fajta"]));
                }
                reader.Close();
                command.CommandText =
                    "SELECT * FROM [Termekek] INNER JOIN [Italok] ON [Termekek].[termekkod]=[Italok].[termekkod] INNER JOIN [Alkoholmentesitalok] ON [Italok].[termekkod]=[Alkoholmentesitalok].[termekkod]";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    termekek.Add(new Alkohom((int)reader["termekkod"], reader["nev"].ToString(), (int)reader["ar"], (int)reader["mennyiseg"], (MennyisegT)(int)reader["mennyisegtipus"], (int)reader["készleten"], (Italtipusok)(int)reader["tipus"], (IzvilagTipus)(int)reader["italizvilag"], (Alkoholmfajta)(int)reader["fajta"]));
                }
                reader.Close();

                return termekek;
            }
            catch (Exception e)
            {
               throw new DBException("Az olvasás sikertelen",e);
            }
        }

        public static void TInsert(Termekek uj)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO [Termekek] VALUES(@1,@2,@3,@4,@5,@6)";
                command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                command.Parameters.AddWithValue("@2", uj.Nev);
                command.Parameters.AddWithValue("@3", (int) uj.Ar);
                command.Parameters.AddWithValue("@4", (int) uj.Mennyiseg);
                command.Parameters.AddWithValue("@5", (int) uj.Mt);
                command.Parameters.AddWithValue("@6", (int) uj.Keszleten);
               command.ExecuteNonQuery();
               
                    if (uj is Etelek)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "INSERT INTO [Ettelek] VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9) ";
                        command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                        command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Etelek).Et));
                        command.Parameters.AddWithValue("@3", Convert.ToInt16((uj as Etelek).Hidege));
                        command.Parameters.AddWithValue("@4", Convert.ToInt16((uj as Etelek).Frissenkeszulte));
                        command.Parameters.AddWithValue("@5", Convert.ToInt16((uj as Etelek).Vegetrianuse));
                        command.Parameters.AddWithValue("@6", Convert.ToInt16((uj as Etelek).Vegane));
                        command.Parameters.AddWithValue("@7", Convert.ToInt16((uj as Etelek).Glutenme));
                        command.Parameters.AddWithValue("@8", Convert.ToInt16((uj as Etelek).Laktozme));
                        command.Parameters.AddWithValue("@9", Convert.ToInt16((uj as Etelek).IzvilagT));
                        command.ExecuteNonQuery();
                        if (uj is Eloetelek)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO [Eloetelek] VALUES(@1,@2)";
                            command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                            command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Eloetelek).Elot));
                            command.ExecuteNonQuery();

                        }
                        else if (uj is Foetelek)
                        {
                             command.Parameters.Clear();
                            command.CommandText = "INSERT INTO [Foetelek] VALUES(@1,@2)";
                            command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                            command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Foetelek).Szezonalise));
                            command.ExecuteNonQuery();
                        }
                        else
                        {

                             command.Parameters.Clear();
                            command.CommandText = "INSERT INTO [Desszertek] VALUES(@1,@2)";
                            command.Parameters.AddWithValue("@1",(int) uj.Termekkod);
                            command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Desszert).Cukormentese));
                           command.ExecuteNonQuery();
                        }

                    }
                    else if (uj is Italok)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "INSERT INTO [Italok] VALUES(@1,@2,@3)";
                        command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                        command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Italok).It));
                        command.Parameters.AddWithValue("@3", Convert.ToInt16((uj as Italok).Izt));
                       command.ExecuteNonQuery();
                        
                        if (uj is Alkoholositalok)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO [Alkoholositalok] VALUES(@1,@2)";
                            command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                            command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Alkoholositalok).Alkf));

                         command.ExecuteNonQuery();
                        }
                        else
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO [Alkoholmentesitalok] VALUES(@1,@2)";
                            command.Parameters.AddWithValue("@1", (int)uj.Termekkod);
                            command.Parameters.AddWithValue("@2", Convert.ToInt16((uj as Alkohom).AlkoholmfajtaT));
                          command.ExecuteNonQuery();
                        }
                    }

               





            }
            catch (Exception e)
            {
                throw new DBException("A beszurás sikertelen", e);

            }
        }

        public static void TModosit(Termekek modosit)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText =
                    "UPDATE [Termekek] SET [nev]=@1,[ar]=@2,[mennyiseg]=@3,[mennyisegtipus]=@4,[készleten]=@5 WHERE [termekkod]=@6";
                command.Parameters.AddWithValue("@1", modosit.Nev);
                command.Parameters.AddWithValue("@2", (int) modosit.Ar);
                command.Parameters.AddWithValue("@3", (int) modosit.Mennyiseg);
                command.Parameters.AddWithValue("@4", (int) modosit.Mt);
                command.Parameters.AddWithValue("@5", (int) modosit.Keszleten);
                command.Parameters.AddWithValue("@6", (int) modosit.Termekkod);
                command.ExecuteNonQuery();

                if (modosit is Etelek)
                {
                     command.Parameters.Clear();
                    command.CommandText =
                        "UPDATE [Ettelek] SET [tipusa]=@1,[hidegmelege]=@2,[frissenkeszult]=@3,[vegetarianus]=@4,[vegan]=@5,[glutenm]=@6,[laktozm]=@7,[etelizvilag]=@8 WHERE [termekkod]=@9";
                    command.Parameters.AddWithValue("@1", Convert.ToInt16((modosit as Etelek).Et));
                    command.Parameters.AddWithValue("@2", Convert.ToInt16((modosit as Etelek).Hidege));
                    command.Parameters.AddWithValue("@3", Convert.ToInt16((modosit as Etelek).Frissenkeszulte));
                    command.Parameters.AddWithValue("@4", Convert.ToInt16((modosit as Etelek).Vegetrianuse));
                    command.Parameters.AddWithValue("@5", Convert.ToInt16((modosit as Etelek).Vegane));
                    command.Parameters.AddWithValue("@6", Convert.ToInt16((modosit as Etelek).Glutenme));
                    command.Parameters.AddWithValue("@7", Convert.ToInt16((modosit as Etelek).Laktozme));
                    command.Parameters.AddWithValue("@8", (int) (modosit as Etelek).IzvilagT);
                    command.Parameters.AddWithValue("@9", (int) modosit.Termekkod);
                    // command.ExecuteNonQuery();
                    if (modosit is Eloetelek)
                    {
                         command.Parameters.Clear();
                        command.CommandText = "UPDATE [Eloetelek] SET [tipus]=@1 WHERE [termekkod]=@2";
                        command.Parameters.AddWithValue("@1", (int)(modosit as Eloetelek).Elot);
                        command.Parameters.AddWithValue("@2", (int) modosit.Termekkod);
                         command.ExecuteNonQuery();
                    }
                    else if (modosit is Foetelek)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "UPDATE [Foetelek] SET [szezonálise]=@1 WHERE [termekkod]=@2";
                        command.Parameters.AddWithValue("@1", Convert.ToInt16((modosit as Foetelek).Szezonalise));
                        command.Parameters.AddWithValue("@2", (int) modosit.Termekkod);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.Parameters.Clear();
                        command.CommandText = "UPDATE [Desszertek] SET [cukormentese]=@1 WHERE [termekkod]=@2";
                        command.Parameters.AddWithValue("@1", Convert.ToInt16((modosit as Desszert).Cukormentese));
                        command.Parameters.AddWithValue("@2", (int) modosit.Termekkod);
                        command.ExecuteNonQuery();
                    }

                    command.ExecuteNonQuery();
                }

               
            


            else if (modosit is Italok)
                {
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE [Italok] SET [tipus]=@1,[italizvilag]=@2 WHERE [termekkod]=@3";
                    command.Parameters.AddWithValue("@1", Convert.ToInt16((modosit as Italok).It));
                    command.Parameters.AddWithValue("@2", Convert.ToInt16((modosit as Italok).Izt));
                    command.Parameters.AddWithValue("@3",(int) modosit.Termekkod);
                  // command.ExecuteNonQuery();
                    if (modosit is Alkoholositalok)
                    {
                       command.Parameters.Clear();
                        command.CommandText = "UPDATE [Alkoholositalok] SET [fajta]=@1 WHERE [termekkod]=@2";
                        command.Parameters.AddWithValue("@1", Convert.ToInt32((modosit as Alkoholositalok).Alkf));
                        command.Parameters.AddWithValue("@2",(int) modosit.Termekkod);
                      command.ExecuteNonQuery();

                    }
                    else
                    {
                       command.Parameters.Clear();
                        command.CommandText = "UPDATE [Alkoholmentesitalok] SET [fajta]=@1 WHERE [termekkod]=@2";
                        command.Parameters.AddWithValue("@1", Convert.ToInt32((modosit as Alkohom).AlkoholmfajtaT));
                        command.Parameters.AddWithValue("@2",(int) modosit.Termekkod);
                        command.ExecuteNonQuery();
                    }

                    command.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
               throw new DBException("A modosítás sikertelen!",e);
            }
        }

        public static void TDelete(Termekek torol)
        {
            try
            {

                if (torol is Eloetelek)
                {
                   
                    command.CommandText = String.Format("DELETE FROM [Eloetelek] WHERE [termekkod]='{0}'",torol.Termekkod);
                  
                }
                else if (torol is Foetelek)
                {
                    command.CommandText = String.Format("DELETE FROM [Foetelek] WHERE [termekkod]='{0}'", torol.Termekkod);
                }
                else if (torol is Desszert)
                {
                    command.CommandText = String.Format("DELETE FROM [Desszeretek] WHERE [termekkod]='{0}'", torol.Termekkod);
                }

                else if (torol is Alkoholositalok)
                {
                    command.CommandText = String.Format("DELETE FROM [Alkoholositalok] WHERE [termekkod]='{0}'", torol.Termekkod); ;
                }
                else
                {
                    command.CommandText = String.Format("DELETE FROM [Alkoholmentesitalok] WHERE [termekkod]='{0}'", torol.Termekkod);
                }

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
              throw new DBException("A törlés sikertelen volt",e);
            }
        }
        

    }
}
