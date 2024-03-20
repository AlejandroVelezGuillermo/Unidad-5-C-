using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad_5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // Configurar DataGridView
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Organización de Archivo";
            dataGridView1.Columns[1].Name = "Ventajas";
            dataGridView1.Columns[2].Name = "Desventajas";

            // Agregar filas
            string[] row1 = { "Archivo Físico", "- Acceso inmediato y sin necesidad de tecnología avanzada.", "- Requiere espacio físico considerable." };
            string[] row2 = { "Archivo Digital Local", "- Ahorro de espacio físico.", "- Requiere inversión en infraestructura de servidores y equipos de almacenamiento." };
            string[] row3 = { "Archivo Digital en la Nube", "- Acceso remoto desde cualquier ubicación con conexión a internet.", "- Dependencia de la disponibilidad y confiabilidad del proveedor de servicios en la nube." };
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);

            // Estilo de las celdas
            DataGridViewCellStyle ventajasStyle = new DataGridViewCellStyle();
            ventajasStyle.ForeColor = System.Drawing.Color.Green;
            DataGridViewCellStyle desventajasStyle = new DataGridViewCellStyle();
            desventajasStyle.ForeColor = System.Drawing.Color.Red;

            // Resaltar ventajas y desventajas
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string ventajas = row.Cells[1].Value.ToString();
                    if (ventajas.StartsWith("-"))
                    {
                        row.Cells[1].Style = ventajasStyle;
                    }
                }
                if (row.Cells[2].Value != null)
                {
                    string desventajas = row.Cells[2].Value.ToString();
                    if (desventajas.StartsWith("-"))
                    {
                        row.Cells[2].Style = desventajasStyle;
                    }
                }
            }

            // Permitir ordenar las filas
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar Cuadro Comparativo";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            writer.WriteLine(row.Cells[0].Value + "\t" + row.Cells[1].Value + "\t" + row.Cells[2].Value);
                        }
                    }
                    MessageBox.Show("Cuadro comparativo guardado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cuadro comparativo: " + ex.Message);
                }
            }
        }
    }
}
