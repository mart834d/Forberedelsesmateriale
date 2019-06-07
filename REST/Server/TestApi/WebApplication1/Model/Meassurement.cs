using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Model
{
    public class Meassurement
    {
        public int Id { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal Temperatur { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public static class MeassurementFunctions //Static class så vi ikke skal lave objekter af klassen, og kan tilgås ved klasse navnet.
    {
        private static string conn = "Server=tcp:weizleet.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=weiz;Password=Passoff1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlConnection connection = new SqlConnection();
        public static SqlConnection GetConnection() // metode til at skabe til databasen. Bliver kaldt i program.cs
        {
            if (connection.State == ConnectionState.Closed) // tjekker om connection er lukket. Hvis den er, bruger vi vores connection string, og åbner op for connection
            {

                connection.ConnectionString = conn;
                connection.Open();
            }
            // ellers returnerer den bare connection
            return connection;
        }

        public static Meassurement Add(Meassurement m)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $@"insert into Meassurement 
                        (Pressure, Humidity, Temperatur, TimeStamp) VALUES 
                ({m.Pressure}, {m.Humidity},{m.Temperatur}, {m.TimeStamp})"; // '{m.navn}' hvis den har en string
                    cmd.ExecuteNonQuery(); // En execute der ikke returnerer noget
                }

            }
            catch (Exception e)
            {
            }

            return m;
        }

        public static Meassurement Get(int id)
        {
            Meassurement m = new Meassurement();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"select * from Meassurement where id = {id}";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            m.Id = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) // hvis den kan være null benyt if statement
                                m.Pressure = reader.GetDecimal(1);
                            if (!reader.IsDBNull(2)) // hvis den kan være null benyt if statement
                                m.Humidity = reader.GetDecimal(2);
                            if (!reader.IsDBNull(3)) // hvis den kan være null benyt if statement
                                m.Temperatur = reader.GetDecimal(3);
                            if (!reader.IsDBNull(4)) // hvis den kan være null benyt if statement
                                m.TimeStamp = reader.GetDateTime(4);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return m;
        }
        public static List<Meassurement> GetAll()
        {
            List<Meassurement> mList = new List<Meassurement>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Meassurement";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Meassurement m = new Meassurement();
                            m.Id = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) // hvis den kan være null benyt if statement
                                m.Pressure = reader.GetDecimal(1);
                            if (!reader.IsDBNull(2)) // hvis den kan være null benyt if statement
                                m.Humidity = reader.GetDecimal(2);
                            if (!reader.IsDBNull(3)) // hvis den kan være null benyt if statement
                                m.Temperatur = reader.GetDecimal(3);
                            if (!reader.IsDBNull(4)) // hvis den kan være null benyt if statement
                                m.TimeStamp = reader.GetDateTime(4);
                            

                            mList.Add(m);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            return mList;
        }
        public static Meassurement Delete(int id)
        {
            Meassurement m = Get(id);
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"delete * from Meassurement where id = {id}";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
            }

            return m;
        }
    }
}
