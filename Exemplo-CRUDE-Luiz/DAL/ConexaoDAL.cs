using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Exemplo_CRUDE_Luiz.DAL
{
    public class ConexaoDAL
    {
        string conecta = "SERVER=localhost; DATABASE=pessoas; UID=root; PWD=Suporte99;";

        protected MySqlConnection conexao = null;

        //Metodo para conectar ao banco de dados
        public void AbrirConexão()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        //Fechar a conexão
        public void EncerrarConexão()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

    }
}
