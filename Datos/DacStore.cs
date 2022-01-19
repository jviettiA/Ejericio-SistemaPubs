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
    public static class DacStore
    {


        static SqlCommand comando;
        static SqlDataReader reader;

        public static List<Store> Listar()
        {
            //declarar la consulta de SQL
            string consultaSQL = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores";
            //crear el comando sqlcommand
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());
            //crear el objeto Reader
            reader = comando.ExecuteReader();

            //recorrer el reader
            //crear una lista del modelo autor
            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                stores.Add(
                    new Store()
                    {
                        StorId = reader["stor_id"].ToString(),
                        Storname = reader["stor_name"].ToString(),
                        Storaddress = reader["stor_address"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Zip = reader["zip"].ToString(),

                    }
                    );

            }
            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return stores;
        }

        public static List<Store> Listar(string state)
        {
            //declarar la consulta de SQL
            string consultaSQL = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores WHERE state = @state";
            //crear el comando sqlcommand
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());


            comando.Parameters.Add("@state", System.Data.SqlDbType.Char, 2).Value = state;

            //crear el objeto Reader
            reader = comando.ExecuteReader();

            //recorrer el reader
            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                stores.Add(
                    new Store()
                    {
                        StorId = reader["stor_id"].ToString(),
                        Storname = reader["stor_name"].ToString(),
                        Storaddress = reader["stor_address"].ToString(),
                        City = reader["city"].ToString(),
                        State = reader["state"].ToString(),
                        Zip = reader["zip"].ToString(),

                    }
                    );

            }
            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return stores;

        }

        public static DataTable ListarState()
        {
            //consulta SQL (select)
            string SQLSelect = "SELECT DISTINCT state FROM stores";

            //Adapater
            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "States");

            return ds.Tables["States"];

        }

        public static Store TraerUno(string id)
        {
            //TODO
            return null;
        }

        public static DataTable TraerUnoDT(string storId)
        {
            //AGREGAR consulta SQL (select)-->WHERE aplicar por ciudad
            string SQLSelect = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores WHERE stor_id = @storId";

            //Adapater
            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            adapter.SelectCommand.Parameters.Add("@storid", SqlDbType.Char, 4).Value = storId;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Store");

            return ds.Tables["Store"];

        }

        public static int Insertar(Store store)
        {
          
            string consultaSQL = "INSERT INTO [dbo].[stores]([stor_id],[stor_name],[stor_address],[city],[state],[zip])VALUES(@storid,@storname,@storaddress,@city,@state,@zip)";

            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@storid", System.Data.SqlDbType.Char, 4).Value = store.StorId;
            comando.Parameters.Add("@storname", System.Data.SqlDbType.VarChar, 40).Value = store.Storname;
            comando.Parameters.Add("@storaddress", System.Data.SqlDbType.VarChar, 40).Value = store.Storaddress;
            comando.Parameters.Add("@city", System.Data.SqlDbType.VarChar, 20).Value = store.City;
            comando.Parameters.Add("@state", System.Data.SqlDbType.Char, 2).Value = store.State;
            comando.Parameters.Add("@zip", System.Data.SqlDbType.Char, 5).Value = store.Zip;

            int filasAfectadas = comando.ExecuteNonQuery();
        
            AdminDB.ConectarBaseDatos().Close();
            return filasAfectadas;
        
        }

        public static int Actualizar(Store store)
        {
            
            string consultaSQL = "UPDATE [stores] SET [stor_name]=@stor_name ,[stor_address] = @stor_address ,[city]=@city ,[state]=@state ,[zip]=@zip WHERE stor_id=@stor_id";
            
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());
            
            comando.Parameters.Add("@stor_id", System.Data.SqlDbType.Char, 4).Value = store.StorId;
            comando.Parameters.Add("@stor_name", System.Data.SqlDbType.VarChar, 40).Value = store.Storname;
            comando.Parameters.Add("@stor_address", System.Data.SqlDbType.VarChar, 40).Value = store.Storaddress;
            comando.Parameters.Add("@city", System.Data.SqlDbType.VarChar, 20).Value = store.City;
            comando.Parameters.Add("@state", System.Data.SqlDbType.Char, 2).Value = store.State;
            comando.Parameters.Add("@zip", System.Data.SqlDbType.Char, 5).Value = store.Zip;

            int filasAfectadas = comando.ExecuteNonQuery(); 

            AdminDB.ConectarBaseDatos().Close();
            
            return filasAfectadas;
        }

        public static int Eliminar(string id)
        {
            string consultaSQL = "DELETE FROM [stores] WHERE stor_id=@stor_id";

            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@stor_id", System.Data.SqlDbType.Char, 4).Value = id;

            int filasAfectadas = comando.ExecuteNonQuery();

            AdminDB.ConectarBaseDatos().Close();



            return filasAfectadas;
        }

        public static DataSet ListarDS() 
        {

            string SQLSelect = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            DataSet ds = new DataSet();

            adapter.Fill(ds,"Stores");

            return ds;
        }

        public static DataTable ListarDT(string zip) 
        {

            string SQLSelect = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores WHERE zip = @zip";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            adapter.SelectCommand.Parameters.Add("@zip", SqlDbType.Char, 5).Value = zip;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Stores");

            return ds.Tables["Stores"];


        }

        public static DataTable ListarZip() 
        {

            string SQLSelect = "SELECT DISTINCT zip FROM stores";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Zip");

            return ds.Tables["Zip"];
        }

    }
}
