using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class ID : Form
    {
        List<Persona> p = new List<Persona>();
        public ID()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1(); f.Show();
        }

        private void leerC(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Persona person = new Persona();
                person.Dpi = reader.ReadLine();
                person.Nombre = reader.ReadLine();
                person.Direccion = reader.ReadLine();

                p.Add(person);
            }

            reader.Close();
        }

        private void ID_Load(object sender, EventArgs e)
        {
            leerC("Ciudadanos.txt");
            for (int i = 0; i < p.Count; i++) comboBox1.Items.Add(p[i].Dpi);
            comboBox1.SelectedIndex = 0;
        }

        private void guardarD(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(textBox1.Text); writer.WriteLine(comboBox1.SelectedItem); 
            writer.WriteLine(DateTime.Now.ToShortDateString());
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardarD("Afiliaciones.txt");
            MessageBox.Show("Datos registrados exitosamente."); textBox1.Text = ""; comboBox1.SelectedIndex = 0;
        }
    }
}
