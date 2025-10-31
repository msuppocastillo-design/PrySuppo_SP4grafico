using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace PrySuppo_SP4grafico
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            Conecion conecionBase = new Conecion();
            conecionBase.ConecionBD(lblMensaje);
            conecionBase.Grafico(chartEstadisticas);
        }

        private void statusStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
