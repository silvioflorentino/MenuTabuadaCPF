using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTabuadaCPF.View.CPF
{
    public partial class TelaCPF : Form
    {
        public TelaCPF()
        {
            InitializeComponent();
        }

        private void ValidarCPF()
        {
            if (string.IsNullOrWhiteSpace(tbxCPF.Text))
            {
                MessageBox.Show("CPF é Obrigatório", "Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                tbxCPF.Focus();
                tbxCPF.SelectAll();
                return;
            }

            string cpfInformado = tbxCPF.Text.Replace(".","").Replace("-","").Replace(" ","");

            if (cpfInformado.Length != 11)
            {
                lblResultado.Text = "Informe um CPF Válido com 11 dígitos.";
                lblResultado.ForeColor = Color.Red;
                tbxCPF.Focus();
                tbxCPF.SelectAll();
                return;
            }
            
            string cpf = cpfInformado.Substring(0, 9);

            //lblResultado.Text = cpf;

            int soma = 0;
            int valorRef = 10;

            for (int i = 0; i <= 8 ; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;
            }
            int dv1 = (int)(soma % 11);

            if(dv1 <2)
            {
                dv1 = 0;
            }
            else
            {
                dv1 = 11 - dv1;
            }
           
            if (!cpfInformado.Substring(9, 1).Equals(dv1.ToString()))
            {
                lblResultado.Text = "Informe um CPF Válido";
                lblResultado.ForeColor = Color.Red;
                return;
            }

            cpf = cpf + dv1.ToString();
            valorRef = 11;
            soma = 0;

            for (int i = 0; i <= 9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * valorRef--;

            }

            int dv2 = (int)(soma % 11);
            if(dv2 < 2)
            {
                dv2 = 0;
            }
            else
            {
                dv2 = 11 - dv2;
            }

            if (!cpfInformado.Substring(10, 1).Equals(dv2.ToString()))
            {
                lblResultado.Text = "Informe um CPF válido.";
                lblResultado.ForeColor = Color.Red;
                return;
            }

            lblResultado.Text = "Cpf Válido";
            lblResultado.ForeColor = Color.Green;





            

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            ValidarCPF();
        }
    }
}
