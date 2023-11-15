using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTP_Menem
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        clsBaseD objBD = new clsBaseD();
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            objBD.CargarTreeView(tvEmpleados);
            
        }

        private void tvEmpleados_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

           if (cmbTipo.Text == "Datos Academicos")
           {
                string codEmpleado = e.Node.Text;
                rtbInfo.Text = "";
                objBD.MostrarDatosACADEMICOS    (codEmpleado, rtbInfo);
           }
            else
            {
                if (cmbTipo.Text == "Datos Laborales")
                {
                    string codEmpleado = e.Node.Text;
                    rtbInfo.Text = "";
                    objBD.MostrarDatosLABORALES(codEmpleado, rtbInfo);
                }
                else
                {
                    if (cmbTipo.Text == "Datos Personales")
                    {
                        string codEmpleado = e.Node.Text;
                        rtbInfo.Text = "";
                        objBD.MostrarDatosPERSONALES(codEmpleado, rtbInfo);
                    }
                }
            }





        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex != -1)
            {
                tvEmpleados.Enabled = true;
            }
        }

        private void tvEmpleados_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void rtbInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
