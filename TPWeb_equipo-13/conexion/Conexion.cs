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
            conexion = new SqlConnection("server=192.168.1.2,1433\\sql-server-express; database=CATALOGO_P3_DB; integrated security = false; user=SA; password=Cor12345!; "); //Franco
            //conexion = new SqlConnection("server=.\\SQLEXPRESS01; database=CATALOGO_P3_DB; Trusted_Connection=true; ");
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

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();

        }

    }
}
