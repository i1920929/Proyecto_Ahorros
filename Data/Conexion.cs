using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Data
{
    class Conexion
    {
        public class Conexion
        {

            string cadena = "Data Source= LAPTOP-LQKTEMKV\\MSSQLSERVER1;Initial Catalog=Ahorros; Integrated Security=True";
            string sp;
            SqlDataAdapter Dtpt;
            SqlCommand Comm;
            public SqlConnection conectarBD = new SqlConnection();

            public Conexion()
            {
                conectarBD.ConnectionString = cadena;
            }

            public string abrir()
            {
                try
                {
                    conectarBD.Open();
                    return "ok";
                }
                catch (Exception ex)
                {
                    return "Error al abrir conexion" + ex.Message;
                    throw;
                }
            }
            public void Cerrar()
            {
                conectarBD.Close();

            }
            public DataSet dtsEjecutarSp(string proc, params object[] Args)
            {
                DataSet dts = null;
                dts = this.dtsRetProcedimiento(proc, Args);

                return dts;
            }
            protected DataSet dtsRetProcedimiento(string proc, params object[] Args)
            {
                Cerrar();
                abrir();
                DataSet dts = new DataSet();
                Dtpt = new SqlDataAdapter(proc, conectarBD.ConnectionString);

                Dtpt.SelectCommand.CommandType = CommandType.StoredProcedure;


                if ((Args != null))
                {
                    Dtpt.SelectCommand.Parameters.AddWithValue("@cNumDocumento", Args[0]);
                }

                Comm = Dtpt.SelectCommand;
                Dtpt.Fill(dts, proc);
                Cerrar();
                return dts;
            }
            protected void CargarParametros(string Proc, SqlCommand Comando, DataSet ds, params object[] Args)
            {
                Int16 i;
                string p;

                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                Comando.CommandText = Proc;
                Comando.CommandType = CommandType.StoredProcedure;

                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    p = dt.Rows[i]["parameter_name"].ToString();
                    Comando.Parameters.Add(new SqlParameter(p, SqlDbType.VarChar, 8000)).Value = Args[i];
                }

            }
        }
    }
}
