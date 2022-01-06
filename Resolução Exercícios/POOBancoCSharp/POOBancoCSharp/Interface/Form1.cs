using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using POOBancoCSharp.Banco;
using POOBancoCSharp.Interface;

namespace POOBancoCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            ClienteBanco cliBanco = new ClienteBanco();
            int gravou;

            cli.nome = txtNome.Text;
            cli.email = txtEMail.Text;
            cli.endereco = txtEndereco.Text;
            try
            {
                gravou = cliBanco.InserirCliente(cli);
                MessageBox.Show("Cliente cadastrado com sucesso", "Incluir Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente\n" + ex.Message, "Inserir",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            ClienteBanco cliBanco = new ClienteBanco();
            DataTable dadosClientes;

            dadosClientes = cliBanco.localizarPorCodigo(Convert.ToInt32(txtCodigo.Text));
            
            if (dadosClientes.Rows.Count > 0)
            {
                txtNome.Text = dadosClientes.Rows[0]["nome"].ToString();
                txtEMail.Text = dadosClientes.Rows[0]["email"].ToString();
                txtEndereco.Text = dadosClientes.Rows[0]["endereco"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente não localizado");
            }
        }
    }
}

