
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; //Para o VS22: Microsoft.Data.SqlClient;
using System.Data;//Para o VS22: Microsoft.Data;


namespace POOBancoCSharp.Banco
{

    class ClienteBanco
    {

        public ClienteBanco()
        {
        }

        public int InserirCliente(Cliente cli)
        {
            int gravou;
            SqlCommand comando=new SqlCommand();
            SqlConnection conexaoBanco=new SqlConnection();
            Conexao  dadosConexao =new Conexao();
       
            comando.CommandType=  CommandType.StoredProcedure;//tipo de comando
            
            comando.CommandText = "inserirClientes";//nome da stored procedure

            comando.Parameters.AddWithValue ("@nome", cli.nome);
            comando.Parameters.AddWithValue("@endereco",cli.endereco );
            comando.Parameters.AddWithValue ("@email",cli.email);

            dadosConexao = new Conexao();
            
            conexaoBanco = dadosConexao.GetConnection();
        
            comando.Connection = conexaoBanco;

            try
            {
                gravou=comando.ExecuteNonQuery();//não retorna dados (registros)
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar novo cliente\n" + ex.Message);
            }
            finally
            {
                conexaoBanco.Close();
            } 
            return gravou;
        }


        public DataTable localizarPorCodigo(int codigo)
        {
            DataTable dadosClientes = new DataTable();
            SqlDataAdapter adptClientes;

            Conexao dadosConexao = new Conexao();
            SqlConnection  conexaoBanco = new SqlConnection();
            conexaoBanco = dadosConexao.GetConnection();

            adptClientes = new SqlDataAdapter("clientePorCodigo", conexaoBanco);
            adptClientes.SelectCommand.CommandType = CommandType.StoredProcedure;
            adptClientes.SelectCommand.Parameters.AddWithValue("@id", codigo);
            try
            {
                adptClientes.Fill(dadosClientes);
            }
            catch ( Exception ex)
            {
                throw new Exception ("Falha ao localizar cliente!\n" + ex.Message);
            }
            return dadosClientes;
        }


        public DataTable localizarPorNome(string nome)
        {

            DataTable dadosClientes = new DataTable();
            SqlDataAdapter  adptClientes;


            Conexao dadosConexao = new Conexao();
            SqlConnection  conexaoBanco = new SqlConnection();
            conexaoBanco = dadosConexao.GetConnection();

            adptClientes = new SqlDataAdapter("cliPorNome", conexaoBanco);
            adptClientes.SelectCommand.CommandType = CommandType.StoredProcedure;
            adptClientes.SelectCommand.Parameters.AddWithValue("@nome", nome);

            try
            {
                adptClientes.Fill(dadosClientes);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao localizar cliente!\n" + ex.Message);
            }
            return dadosClientes;
        }
    }
}
