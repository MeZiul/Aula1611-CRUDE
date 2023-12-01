using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exemplo_CRUDE_Luiz.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace Exemplo_CRUDE_Luiz.DAL
{
    public class PessoaDAL : ConexaoDAL
    {
        MySqlCommand comando = null;

        public void Alterar(PessoaModel pessoa)
        {
            try
            {
                AbrirConexão();
                comando = new MySqlCommand("UPDATE pessoa SET nome = @nome, nascimento = @nascimento, sexo = @sexo, cpf = @cpf, celular = @celular, endereco = @endereco," +
                    " bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@id", pessoa.Id);
                comando.Parameters.AddWithValue("@nome", pessoa.Name);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nasc).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);
                comando.Parameters.AddWithValue("@cep", pessoa.Cep);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                EncerrarConexão();
            }
        }

        //método para salvar
        public void Salvar( PessoaModel pessoa)
        {
            try
            {
                AbrirConexão();
                comando = new MySqlCommand("INSERT INTO pessoa(nome, nascimento, sexo, cpf, celular ,endereco, bairro, cidade, estado, cep) " +
                "VALUES (@nome, @nascimento, @sexo, @cpf, @celular, @endereco, @bairro, @cidade, @estado, @cep)", conexao);

                comando.Parameters.AddWithValue("@nome",     pessoa.Name);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nasc).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo",     pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf",      pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular",  pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro",   pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade",   pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado",   pessoa.Estado);
                comando.Parameters.AddWithValue("@cep",      pessoa.Cep);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                EncerrarConexão();
            }
            
        }
        public DataTable Listar()
        {
            try
            {
                AbrirConexão();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("Select * FROM pessoa ORDER BY nome", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                EncerrarConexão();
            }
        }
    }
}
