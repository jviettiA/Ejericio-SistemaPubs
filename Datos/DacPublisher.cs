using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Datos.Servidor;


namespace Datos
{
    public static class DacPublisher
    {
        static SqlCommand comando;
        static SqlDataReader reader;

        public static List<Publisher> Listar()
        {
            string consultaSQL = "SELECT pub_id, pub_name, city, state, country FROM publishers";
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());
            reader = comando.ExecuteReader();

            List<Publisher> publishers = new List<Publisher>();
            while (reader.Read()) 
            {
                publishers.Add(new Publisher() 
                { 
                    PubId=reader["pub_id"].ToString(),
                    Pubname=reader["pub_name"].ToString(),
                    City=reader["city"].ToString(),
                    State=reader["state"].ToString(),
                    Country=reader["country"].ToString(),
                }
                );
            }

            AdminDB.ConectarBaseDatos().Close();

            reader.Close();

            return publishers;
        }

        public static List<Publisher> Listar(string city, string country)
        {
            //SELECT pub_id, pub_name, city, state, country FROM publishers
            //SELECT pub_id, pub_name, city, state, country FROM publishers WHERE city = @city AND country = @country
            //SELECT pub_id, pub_name, city, state, country FROM publishers WHERE pub_id = @id

            string consultaSQLWhere = "SELECT pub_id, pub_name, city, state, country FROM publishers WHERE city = @city AND country = @country";
            comando = new SqlCommand(consultaSQLWhere, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@city", System.Data.SqlDbType.VarChar, 20).Value = city;
            comando.Parameters.Add("@country", System.Data.SqlDbType.VarChar,20).Value = country;
            
            
            reader = comando.ExecuteReader();

            List<Publisher> publishers = new List<Publisher>();
            while (reader.Read())
            {
                publishers.Add(new Publisher()
                {
                    PubId = reader["pub_id"].ToString(),
                    Pubname = reader["pub_name"].ToString(),
                    City = reader["city"].ToString(),
                    State = reader["state"].ToString(),
                    Country = reader["country"].ToString(),
                }
                );
            }

            AdminDB.ConectarBaseDatos().Close();

            reader.Close();

            return publishers;
            

        }

        public static Publisher TraerUno(string id)
        {
            string consultaSQLWhere = "SELECT pub_id, pub_name, city, state, country FROM publishers WHERE pub_id = @id";
            comando = new SqlCommand(consultaSQLWhere, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 11).Value = id;



            reader = comando.ExecuteReader();

            Publisher publisher = new Publisher();
            while (reader.Read())
            {
                publisher = new Publisher()
                {
                    PubId = reader["pub_id"].ToString(),
                    Pubname = reader["pub_name"].ToString(),
                    City = reader["city"].ToString(),
                    State = reader["state"].ToString(),
                    Country = reader["country"].ToString(),
                };
                
            }

            AdminDB.ConectarBaseDatos().Close();

            reader.Close();

            return publisher;
        }

        public static int Insertar(Publisher publisher)
        {
            //TODO
            return 0;
        }

        public static int Actualizar(Publisher publisher)
        {
            //TODO
            return 0;
        }

        public static int Eliminar(string id)
        {
            //TODO
            return 0;
        }
    }
}
