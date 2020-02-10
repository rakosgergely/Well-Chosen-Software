using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well_Choosen.Classes
{
    [Serializable]
   static class FelhasznaloAb
    {
        private static SqlConnection connecttion=new SqlConnection();
        private static SqlCommand Command=new SqlCommand();

        static FelhasznaloAb()
        {
            connecttion=new SqlConnection();
            Command=new SqlCommand();
            Command.Connection = connecttion;
            
        }
        public static void Conn(string constr)
        {
            try
            {
                connecttion.ConnectionString= constr;
                connecttion.Open();
                Command.Connection = connecttion;
            }
            catch (Exception e)
            {
              
                throw new DBException("A felhasználói adatbázhos nem sikerült kapcsolódni",e);
            }
        }

        public static void DisC()
        {
            connecttion.Close();
            connecttion.Dispose();
        }

        public static List<Felhasz> Reader()
        {
            List<Felhasz> felhasznalok=new List<Felhasz>();
            Command.CommandText = "SELECT*FROM [Felhasznalo]";
            using (SqlDataReader reader=Command.ExecuteReader())
            {
                while (reader.Read())
                {
                    felhasznalok.Add(new Felhasz((int)reader["id"],reader["felhasznev"].ToString(),reader["jelszo"].ToString(),(statusz)(int)reader["statusz"]));
                }
                reader.Close();

            }

            return felhasznalok;
        }

        public static void Insert(Felhasz uj)
        {
            Command.Parameters.Clear();
            Command.CommandText= "INSERT INTO [Felhasznalo]([felhasznev], [jelszo], [statusz]) VALUES(@felhnev, @jelszo, @statusz)";
            Command.Parameters.Add(new SqlParameter("@felhnev", uj.Felhasznev));
            Command.Parameters.Add(new SqlParameter("@jelszo", uj.Jelszo));
            Command.Parameters.Add(new SqlParameter("@statusz",(int) uj.Fstatusza));
            
          //uj.Id = (int)Command.ExecuteScalar();
          Command.ExecuteNonQuery();
        }
        public static Felhasz SingIn(string felhasznev, string jelszo)
        {
            
            Command.Parameters.Clear();
            Command.CommandText = "SELECT * FROM [Felhasznalo] WHERE [felhasznev]=@felhasznev AND [jelszo]=@jelszo";
            Command.Parameters.Add(new SqlParameter("@felhasznev", felhasznev));
            Command.Parameters.Add(new SqlParameter("@jelszo", jelszo));
            
            using (SqlDataReader reader=Command.ExecuteReader()
            )
            {
                while (reader.Read())
                {
                    return new Felhasz(reader["felhasznev"].ToString(), reader["jelszo"].ToString(), (statusz)Convert.ToInt16(reader["statusz"]));
                }



                return null;
            }
            
              
        }
    }
}
