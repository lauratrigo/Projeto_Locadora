namespace Projeto_Final_Prog_III
{
    partial class GraficosForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPizza = new System.Windows.Forms.Button();
            this.chartGeneroFilmes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFilmesPorDiretor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBarras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneroFilmes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFilmesPorDiretor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPizza
            // 
            this.btnPizza.Location = new System.Drawing.Point(241, 588);
            this.btnPizza.Name = "btnPizza";
            this.btnPizza.Size = new System.Drawing.Size(104, 56);
            this.btnPizza.TabIndex = 87;
            this.btnPizza.Text = "Gráfico de Filmes por Gênero";
            this.btnPizza.UseVisualStyleBackColor = true;
            this.btnPizza.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // chartGeneroFilmes
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGeneroFilmes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGeneroFilmes.Legends.Add(legend1);
            this.chartGeneroFilmes.Location = new System.Drawing.Point(12, 29);
            this.chartGeneroFilmes.Name = "chartGeneroFilmes";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGeneroFilmes.Series.Add(series1);
            this.chartGeneroFilmes.Size = new System.Drawing.Size(582, 543);
            this.chartGeneroFilmes.TabIndex = 89;
            this.chartGeneroFilmes.Text = "chart1";
            // 
            // chartFilmesPorDiretor
            // 
            chartArea2.Name = "ChartArea1";
            this.chartFilmesPorDiretor.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartFilmesPorDiretor.Legends.Add(legend2);
            this.chartFilmesPorDiretor.Location = new System.Drawing.Point(628, 29);
            this.chartFilmesPorDiretor.Name = "chartFilmesPorDiretor";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartFilmesPorDiretor.Series.Add(series2);
            this.chartFilmesPorDiretor.Size = new System.Drawing.Size(585, 543);
            this.chartFilmesPorDiretor.TabIndex = 91;
            this.chartFilmesPorDiretor.Text = "chart1";
            // 
            // btnBarras
            // 
            this.btnBarras.Location = new System.Drawing.Point(856, 588);
            this.btnBarras.Name = "btnBarras";
            this.btnBarras.Size = new System.Drawing.Size(104, 56);
            this.btnBarras.TabIndex = 90;
            this.btnBarras.Text = "Gráfico de Filmes por Diretor";
            this.btnBarras.UseVisualStyleBackColor = true;
            this.btnBarras.Click += new System.EventHandler(this.btnBarras_Click);
            // 
            // GraficosForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 697);
            this.Controls.Add(this.chartFilmesPorDiretor);
            this.Controls.Add(this.btnBarras);
            this.Controls.Add(this.chartGeneroFilmes);
            this.Controls.Add(this.btnPizza);
            this.Name = "GraficosForms";
            this.Text = "GraficosForms";
            ((System.ComponentModel.ISupportInitialize)(this.chartGeneroFilmes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFilmesPorDiretor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPizza;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGeneroFilmes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFilmesPorDiretor;
        private System.Windows.Forms.Button btnBarras;
    }
}