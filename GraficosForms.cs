using MySql.Data.MySqlClient;
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

namespace Projeto_Final_Prog_III
{
    public partial class GraficosForms : Form
    {
        public GraficosForms()
        {
            InitializeComponent();
        }

        private void CarregarGraficoFilmesPorGenero()
        {
            var dados = Filme.ObterQuantidadePorGenero();

            chartGeneroFilmes.Series.Clear();
            chartGeneroFilmes.Titles.Clear();

            chartGeneroFilmes.Titles.Add("Quantidade de Filmes por Gênero");

            Series serie = new Series
            {
                Name = "Filmes",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };

            chartGeneroFilmes.Series.Add(serie);

            foreach (var item in dados)
            {
                serie.Points.AddXY(item.Key, item.Value);
            }

            chartGeneroFilmes.Legends[0].Docking = Docking.Right;
            chartGeneroFilmes.Legends[0].Alignment = StringAlignment.Center;
            chartGeneroFilmes.Legends[0].Title = "Gêneros";

            // Opcional: mostrar o valor em % no gráfico
            serie.Label = "#PERCENT{P0}";
            serie.LegendText = "#VALX";
        }

        private void CarregarGraficoFilmesPorDiretor()
        {
            var dados = Filme.ObterQuantidadePorDiretor();

            chartFilmesPorDiretor.Series.Clear();
            chartFilmesPorDiretor.Titles.Clear();

            chartFilmesPorDiretor.Titles.Add("Quantidade de Filmes por Diretor");

            Series serie = new Series
            {
                Name = "Filmes",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column // barras verticais
            };

            chartFilmesPorDiretor.Series.Add(serie);

            foreach (var item in dados)
            {
                serie.Points.AddXY(item.Key, item.Value);
            }

            // Estética dos eixos
            chartFilmesPorDiretor.ChartAreas[0].AxisX.Title = "Diretor";
            chartFilmesPorDiretor.ChartAreas[0].AxisY.Title = "Quantidade de Filmes";
            chartFilmesPorDiretor.ChartAreas[0].AxisX.Interval = 1;
            chartFilmesPorDiretor.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // inclina os nomes dos diretores
            chartFilmesPorDiretor.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8); // fonte menor para caber melhor
        }




        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CarregarGraficoFilmesPorGenero();
        }

        private void btnBarras_Click(object sender, EventArgs e)
        {
            CarregarGraficoFilmesPorDiretor();
        }
    }
}
