using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using conexion;
using System.Data.SqlTypes;


namespace gestor
{
    public class gestionMarca
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            Conexion acceso = new Conexion();
            try
            {
                acceso.setearConsulta("select Id, Descripcion from Marcas");
                acceso.ejecutarLectura();
                while (acceso.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)acceso.Lector["Id"];
                    aux.Descripcion = (string)acceso.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void AgregarMarca(string descripcion) {
            Conexion conexion = new Conexion();
            conexion.setearConsulta("  INSERT INTO MARCAS (Descripcion) VALUES (@descripcion)");
            conexion.setearParametro("descripcion", descripcion);
            conexion.ejecutarLectura();

            conexion.cerrarConexion();



        }

        public decimal ProximoID()
        {
            int id = 0;
            Conexion conexion = new Conexion();
            conexion.setearConsulta("  SELECT MAX(Id) +1 AS ProximoId FROM MARCAS");
            conexion.ejecutarLectura();
            conexion.Lector.Read();
            id = (int)conexion.Lector["ProximoId"];
            return id;
        }

        public List<String> ListaMarcas()
        {
        List<string> marcas = new List<string>();
            Marca aux = new Marca();
            Conexion datos = new Conexion();
            datos.setearConsulta("select Descripcion from MARCAS");
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {

                aux.Descripcion = (string)datos.Lector["Descripcion"];

               marcas.Add(aux.Descripcion.ToUpper());
            }


            return marcas;
        }

        public void ModificarMarca(int id, string des)
        {
            Conexion datos = new Conexion();
            datos.setearConsulta("update MARCAS set Descripcion = @descripcion where id = @id");
            datos.setearParametro("descripcion", des);
            datos.setearParametro("id", id);
            datos.ejecutarLectura();
            datos.cerrarConexion();
        }

        public void EliminarMarca(int id)
        {
            Conexion datos = new Conexion();

            try
            {

                datos.setearConsulta("delete from MARCAS where ID = @id ");
                datos.setearParametro("id", id);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            finally
            {

                datos.cerrarConexion();

            }

        }
    }
}
