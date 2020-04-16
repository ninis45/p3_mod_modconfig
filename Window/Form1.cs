using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloCI;

namespace Window
{
    public partial class Form1 : Form
    {
        private Entities_ModeloCI db = new Entities_ModeloCI();
        private ModelosConfig.MainWindow modelo;
        private AGUJERO Agujero;
        private string Fecha;
        public Form1()
        {
            InitializeComponent();

            modelo = new ModelosConfig.MainWindow("DDB3A31F-0143-42E3-819B-9B4A4B631D33", "2019-03-27", "9FB4F4ED-4D05-421D-B3BF-6DD4A1E3E275");
            comboBox1.DisplayMember = "NOMBRE";
            //comboBox1.SelectedValue = "IDPOZO";


           
           
            comboBox1.DataSource = db.POZO.OrderBy(o=>o.NOMBRE).ToList();

            elementHost1.Child = modelo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POZO pozo =(POZO) comboBox1.SelectedItem;
           
          
            try
            {
                modelo.actualizar(Agujero.IDAGUJERO, ((DISPARO)comboBox2.SelectedItem).FECHAAPERTURA.ToString("yyyy-MM-dd"),"9FB4F4ED-4D05-421D-B3BF-6DD4A1E3E275");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Campos Inteligentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void SelectFecha(object sender, EventArgs e)
        {
            //var  Disparos = (DISPARO)db.DISPARO.Where(w => w.IDAGUJERO == Agujero.IDAGUJERO).ToList();

        }

        private void SelectPozo(object sender, EventArgs e) {
            var pozo = (POZO) comboBox1.SelectedItem;
            var agujeros = db.AGUJERO.Where(w => w.IDPOZO == pozo.IDPOZO).ToList();

            if (agujeros.Count > 0)
            {
                if (agujeros[0].DISPARO.Count() > 0)
                {
                    Agujero = agujeros[0];
                    comboBox2.DataSource = agujeros[0].DISPARO.ToList();
                }
                else
                {
                    comboBox2.DataSource = null;
                }

                // db.DISPARO.Where(w => w.IDAGUJERO == agujeros[0].IDAGUJERO).ToList();
                comboBox2.DisplayMember = "FECHAAPERTURA";
            }


        }
    }
}
