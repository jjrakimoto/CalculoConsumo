using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoConsumo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public decimal CalculoConsumo(TextBox num)
        {
            try
            {
                return Convert.ToDecimal(num.Text);
            }
            catch
            {
                num.Focus();
                num.SelectAll();
                throw new Exception("Preencha corretamente o campo" + num.Name.ToUpper().Replace("TEXTBOX", ""));           
            }
        }
        public void Limpartela()
        {
            foreach( Control ctl in this.Controls)
            {
                if(ctl is TextBox)
                {
                    ctl.Text = String.Empty;
                }else if(ctl is Label && Convert.ToInt32(ctl.Tag).Equals(1))
                {
                    ctl.Text = String.Empty;
                }
            }
        }

        private void btmcalcular_Click(object sender, EventArgs e)
        {
            try 
            {
                decimal KM = CalculoConsumo(txtkm);
                decimal Litros = CalculoConsumo(txtlitros);

                decimal Rendimento = KM / Litros;
                decimal Consumo = Litros / KM;

                lblrendimento.Text = Rendimento.ToString("N1");
                lblconsumo.Text = Consumo.ToString("N3");




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
