using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace PrySuppo_SP4grafico
{
    internal class Conecion
    {
        

        OleDbConnection coneciones;
        OleDbCommand comando;

        public void ConecionBD(Label lblMensaje)
        {
            try
            {
                coneciones = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\base\\control_transporte.accdb");
                lblMensaje.Text = "Encontró la base de datos";
                lblMensaje.BackColor = System.Drawing.Color.LightBlue;
            }
            catch (Exception )
            {
                lblMensaje.Text = "No encontró la base de datos";
                lblMensaje.BackColor = System.Drawing.Color.Red;
            }
        }

        public void Grafico(Chart chart)
        {
            Series serie = new Series("KM por camión");
            serie.ChartType = SeriesChartType.Column;

            try
            {// Abrir la conección con la base de datos.
                coneciones.Open();

                // Define la consulta,
                string query = "SELECT Camión, Kilómetros FROM transporte";
                comando = new OleDbCommand(query, coneciones);

                // Realizo la consulta.
                OleDbDataReader reader = comando.ExecuteReader();


                while (reader.Read())
                {
                    // Extre los datos que necesito y los guardo en variables.
                    string camion = reader["Camión"].ToString();
                    decimal km = Convert.ToDecimal(reader["Kilómetros"]);

                    serie.Points.AddXY(camion, km);
                    
                }

                chart.Series.Add(serie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
