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

namespace Editor_de_codigo
{
    public partial class Main : Form
    {
        String Archivo;
        public Main()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            MyTextBox1.Clear();
            Archivo = null;
        }

        private void Abrir_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Texto|*.txt";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                Archivo = OpenFile.FileName;
                using (StreamReader A = new StreamReader(Archivo))
                {
                    MyTextBox1.Text = A.ReadToEnd();
                }

            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {

            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Texto|*.txt";
            if (Archivo != null)
            {
                using (StreamWriter G = new StreamWriter(Archivo))
                {
                    G.Write(MyTextBox1.Text);
                }
            }
            else
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    Archivo = SaveFile.FileName;
                    using (StreamWriter g = new StreamWriter(SaveFile.FileName))
                    {
                        g.Write(MyTextBox1.Text);

                    }
                }


            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Deshacer_Click(object sender, EventArgs e)
        {
            MyTextBox1.Undo();
        }

        private void Rehacer_Click(object sender, EventArgs e)
        {
            MyTextBox1.Redo();
        }

        private void Copiar_Click(object sender, EventArgs e)
        {
            MyTextBox1.Copy();
        }

        private void Cortar_Click(object sender, EventArgs e)
        {
            MyTextBox1.Cut();
        }

        private void Pegar_Click(object sender, EventArgs e)
        {
            MyTextBox1.Paste();
        }

        private void SeleccionarTodo_Click(object sender, EventArgs e)
        {
            MyTextBox1.SelectAll();
        }

        private void EliminarTodo_Click(object sender, EventArgs e)
        {
            MyTextBox1.Clear();
        }

        private void Estilos_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                MyTextBox1.ForeColor = color.Color;
            }
        }

        private void Fuente_Click(object sender, EventArgs e)
        {
            FontDialog fuente = new FontDialog();

            if (fuente.ShowDialog() == DialogResult.OK)
            {
                MyTextBox1.Font = fuente.Font;
            }
        }


    }
}
