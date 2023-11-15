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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        int hora = 0;
        private void timerHora_Tick(object sender, EventArgs e)
        {
            hora += 1000;
            toolHora.Text = Convert.ToString(DateTime.Now);
        }

        private void registroDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmpleados f = new frmEmpleados();
            f.ShowDialog();
          
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolHora_Click(object sender, EventArgs e)
        {

        }
    }
}
