using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexion
{

    public class Conexion
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public Conexion()
        {
            //conexion = new SqlConnection("server=192.168.1.2,1433\\sql-server-express; database=CATALOGO_P3_DB; integrated security = false; user=SA; password=Cor12345!; "); //Franco
            //conexion = new SqlConnection("server=CristianEsc\\SQLEXPRESS01; database=CATALOGO_P3_DB; Trusted_Connection=true; "); //Cristian
            conexion = new SqlConnection("data source = .\\SQLEXPRESS; database= CATALOGO_P3_DB;integrated security = sspi;"); // Nahuel
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public int ultimoId()
        {
            setearConsulta("SELECT Id FROM ARTICULOS WHERE Id = (SELECT IDENT_CURRENT('ARTICULOS'))");
            ejecutarLectura();
            int id = 0;
            if (lector.Read())
            {
                id = (int)lector["Id"];
            }
            return id;
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();

        }

    }
}
