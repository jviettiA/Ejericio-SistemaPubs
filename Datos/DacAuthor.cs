using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Datos.Servidor;
using System.Data;


namespace Datos
{

    /// <summary>
    /// Clase para administrar opeaciones y consultas a la tabla de Authors
    /// </summary>
    public static class DacAuthor
    {

        static SqlCommand comando;
        static SqlDataReader reader;
        public static List<Author> Listar()
        {
            //declarar la consulta de SQL
            string consultaSQL = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors";
            //crear el comando sqlcommand
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());
            //crear el objeto Reader
            reader = comando.ExecuteReader();


            List<Author> authors = new List<Author>();
            while (reader.Read())
            {
                authors.Add(
                    new Author()
                    {
                        AuId = reader["au_id"].ToString(),
                        AuLname = reader["au_lname"].ToString(),
                        AuFname = reader["au_fname"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Zip = reader["zip"].ToString(),
                        Contract = (bool)reader["contract"],

                    }
                    );

            }

            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return authors;
        }


        public static List<Author> Listar(string city)
        {
            //declarar la consulta de SQL -->USA WHERE PARA EL FILTRO
            string consultaSQLWhere =
                "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors wHERE city = @city";
            comando = new SqlCommand(consultaSQLWhere, AdminDB.ConectarBaseDatos());

            
            comando.Parameters.Add("@city", System.Data.SqlDbType.VarChar, 20).Value = city;



            reader = comando.ExecuteReader();


            List<Author> authors = new List<Author>();
            while (reader.Read())
            {
                authors.Add(
                    new Author()
                    {
                        AuId = reader["au_id"].ToString(),
                        AuLname = reader["au_lname"].ToString(),
                        AuFname = reader["au_fname"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["address"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Zip = reader["zip"].ToString(),
                        Contract = (bool)reader["contract"],

                    }
                    );

            }

            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return authors;
        }

        public static DataTable ListarCity()
        {
            string SQLSelect = "SELECT DISTINCT city FROM authors";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Ciudades");

            return ds.Tables["Ciudades"];

        }



        public static Author TraerUno(string auId)
        {

            //TODO Falta implementar el código de acceso a datos TraerUno(auId)-->SELECT WHERE auId
            //Modelo conectado
            return null;
        }

        public static DataTable TraerUnoDT(string uaId)
        {
            string SQLSelect = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors WHERE au_id=@au_id";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            adapter.SelectCommand.Parameters.Add("@au_id", SqlDbType.VarChar, 11).Value = uaId;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Autor");

            return ds.Tables["Autor"];

        }


        public static int Insertar(Author author)
        {
            //TODO Falta implementar el código de acceso a datos Insertar(Author)-->INSERT
            //OPERACIONES DE MODIFICACION
            return 0;
        }

        public static int Modificar(Author author)
        {
            //TODO Falta implementar el código de acceso a datos Modificar(Author)-->UPDATE
            //OPERACIONES DE MODIFICACION
            return 0;
        }

        public static int Eliminar(string auId)
        {
            //TODO Falta implementar el código de acceso a datos Eliminar(auId)-->DELETE FROM
            //OPERACIONES DE MODIFICACION
            return 0;
        }



    }

}
