using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Datos
{
    public static class DacAuthor
    {
        public static List<Author> Listar() 
        {
        
            //TODO implementar el codigo de acceso de datos Listar -->SELECT
            //Modelo conectado

            return null;
        }

        public static List<Author> Listar(string city)
        {
            //TODO Falta implementar el código de acceso a datos Listar(city)-->SELECT WHERE city
            //Modelo conectado
            return null;


        }

        public static Author TraerUno(string auId)
        {

            //TODO Falta implementar el código de acceso a datos TraerUno(auId)-->SELECT WHERE auId
            //Modelo conectado
            return null;
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
