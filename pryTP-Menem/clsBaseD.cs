using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTP_Menem
{
    internal class clsBaseD
    {
        string rutaArchivo;
        string cadenaConexion;

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbDataReader rdr;

        public clsBaseD()
        {
            rutaArchivo = @"../../BD/Empleo.accdb";
            cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
        }

        public void CargarTreeView(System.Windows.Forms.TreeView tv)
        {

            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                try
                {

                    connection.Open();


                    string query = "SELECT CODIGO FROM [DATOS PERSONALES]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);


                    DataSet dataSet = new DataSet();


                    adapter.Fill(dataSet, "DATOS PERSONALES");


                    foreach (DataRow row in dataSet.Tables["DATOS PERSONALES"].Rows)
                    {

                        string codigo = row["CODIGO"].ToString();


                        TreeNode newNode = new TreeNode(codigo);


                        tv.Nodes.Add(newNode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        public void MostrarDatosPERSONALES(string empleado, RichTextBox rtb)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(cadenaConexion);
                con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [DATOS PERSONALES] WHERE CODIGO = @codigo";
                cmd.Parameters.AddWithValue("@codigo", empleado);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rtb.Text += $"Nombre: {rdr["NOMBRE"]}\n" +
                                $"Apellido: {rdr["APELLIDO"]}\n" +
                                $"Dirección: {rdr["DIRECCIÒN"]}\n" +
                                $"Ciudad: {rdr["CIUDAD"]}\n" +
                                $"Teléfono: {rdr["TELEFONO"]}\n" +
                                $"Fecha de Nacimiento: {rdr["FECHA_NACIMIENTO"]}\n\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        public void MostrarDatosACADEMICOS(string empleado, RichTextBox rtb)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(cadenaConexion);
                con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [DATOS ACADEMICOS] WHERE CODIGO = @codigo";
                cmd.Parameters.AddWithValue("@codigo", empleado);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rtb.Text += $"Curso que recibio : {rdr["CURSOS QUE RECIBIO"]}\n" +
                                $"Horas/Estudio: {rdr["HORAS/ESTUDIO"]}\n" +
                                $"Lugar de estudio: {rdr["LUGAR DE ESTUDIO"]}\n\n";
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        public void MostrarDatosLABORALES(string empleado, RichTextBox rtb)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(cadenaConexion);
                con.Open();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [DATOS LABORALES] WHERE CODIGO = @codigo";
                cmd.Parameters.AddWithValue("@codigo", empleado);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rtb.Text += $"Años/Experiencia: {rdr["AÑOS/EXPERIENCIA"]}\n" +
                                $"Ultimo lugar de trabajo: {rdr["ULTIMO LUGAR DE TRABAJO"]}\n" +
                                $"Cargo Desempenado: {rdr["CARGO DESEMPENADO"]}\n" +
                                $"Remuneracion: {rdr["REMUNERACION"]}\n\n" ;      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

    }
}
