using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;//conjunto de classes e objetos capazes de fazer a integração com o SQLServer
using System.Windows.Forms;



namespace POOBancoCSharp
{
    class Conexao
    {
        string strCon;
        SqlConnection con;


        public Conexao()
        {
            strCon = "Data Source=DESKTOP-CTPO8JA\\SQLEXPRESS;  " + //servidor sqlserver
                "Initial Catalog=conexao; " + //banco que será conectado
                "Integrated Security=True";//ativando a segurança integrada do windows
        }

        public SqlConnection GetConnection()
        {
           con = new SqlConnection(strCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao conectar o banco\n" + ex.Message );
            }
            return con;
        }
    }
}
