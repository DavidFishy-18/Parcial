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
    public partial class MD : Form
    {
        List<Persona> p = new List<Persona>();
        List<Registrar> r = new List<Registrar>();
        List<DF> d = new List<DF>();
        public MD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void leerA(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Registrar rr = new Registrar();
                rr.NP = reader.ReadLine();
                rr.Dpi = reader.ReadLine();
                rr.Fecha = Convert.ToDateTime(reader.ReadLine());

                r.Add(rr);
            }

            reader.Close();
        }

        private void MD_Load(object sender, EventArgs e)
        {
            leerC("Ciudadanos.txt"); leerA("Afiliaciones.txt");
            bus(); mostD();
        }

        private void bus()
        {
            bool bl;
            for (int i = 0; i < r.Count; i++)
            {
                bl = true;
                for (int j = 0; j < p.Count && bl; j++)
                {
                    if (r[i].Dpi == p[j].Nombre)
                    {
                        DF dd = new DF();
                        dd.Nombre = p[j].Nombre;
                        dd.Partido = r[i].NP;

                        d.Add(dd); bl = false;
                    }
                }
            }
        }

        private void mostD()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }

        private void ord()
        {
            d = d.OrderBy(d => d.Partido).ToList();
            mostD(); MessageBox.Show("Datos ordenados exitosamente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ord();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La cantidad de personas afiliadas es:"+d.Count);
        }
    }
}
