using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POOBancoCSharp.Banco;
using POOBancoCSharp.Interface;

namespace POOBancoCSharp.Interface
{
    public partial class frmPesqCli : Form
    {
        Form1 frmCli;

        public frmPesqCli()
        {
            InitializeComponent();
        }

        public frmPesqCli(Form1 frmClientes)
        {
            InitializeComponent();
            frmCli = frmClientes;
        }

        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            ClienteBanco cliBanco =new ClienteBanco();
            DataTable dadosClientes;

            if (txtPesq.Text!= string.Empty)
            {
                      

                if (rdbCodigo.Checked ==true)
                {
                    dadosClientes = cliBanco.localizarPorCodigo(Convert.ToInt32( txtPesq.Text));
                    dgvClientes.DataSource = dadosClientes;
                }
                else
                {
                    dadosClientes = cliBanco.localizarPorNome(txtPesq.Text);
                    dgvClientes.DataSource = dadosClientes;
                }
            }
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaSelecionada;
           

            linhaSelecionada = dgvClientes.CurrentRow;

            frmCli.txtCodigo.Text = linhaSelecionada.Cells[0].Value.ToString();
            frmCli.txtNome.Text = linhaSelecionada.Cells[1].Value.ToString();
            frmCli.txtEndereco.Text = linhaSelecionada.Cells[2].Value.ToString();
            frmCli.txtEMail.Text = linhaSelecionada.Cells[3].Value.ToString();
           
            this.Close();
        }
    }
}
