using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace Projeto_Final_Prog_III
{
    public static class ExportadorPDF
    {
        public static void ExportarDataGridViewParaPDF(DataGridView dgv, string titulo, string nomeArquivoDefault)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo PDF (*.pdf)|*.pdf";
            saveFileDialog.FileName = nomeArquivoDefault;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = saveFileDialog.FileName;

                try
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(caminhoArquivo, FileMode.Create));
                    pdfDoc.Open();

                    Paragraph tituloParagrafo = new Paragraph(titulo);
                    tituloParagrafo.Alignment = Element.ALIGN_CENTER;
                    tituloParagrafo.SpacingAfter = 20f;
                    pdfDoc.Add(tituloParagrafo);

                    PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    foreach (DataGridViewColumn coluna in dgv.Columns)
                    {
                        PdfPCell celula = new PdfPCell(new Phrase(coluna.HeaderText));
                        celula.BackgroundColor = BaseColor.LIGHT_GRAY;
                        pdfTable.AddCell(celula);
                    }

                    foreach (DataGridViewRow linha in dgv.Rows)
                    {
                        if (linha.IsNewRow) continue;

                        foreach (DataGridViewCell celula in linha.Cells)
                        {
                            string valor = celula.Value?.ToString() ?? "";
                            pdfTable.AddCell(new Phrase(valor));
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("PDF exportado com sucesso!\n" + caminhoArquivo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao exportar PDF: " + ex.Message);
                }
            }
        }
    }
}
