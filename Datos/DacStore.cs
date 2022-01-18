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

        public static List<Store> Listar()
        {
            //TODO
            return null;
        }

        public static List<Store> Listar(string city, string country)
        {
            //TODO
            return null;

        }

        public static Store TraerUno(string id)
        {
            //TODO
            return null;
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
