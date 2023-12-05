using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exemplo_CRUDE_Luiz.DAL;
using System.Data;
using Exemplo_CRUDE_Luiz.Model;


namespace Exemplo_CRUDE_Luiz.BLL
{
    public class pessoasBLL
    {
        PessoaDAL pessoaDAL = new PessoaDAL();

        public void Alterar(PessoaModel pessoa)
        {
            try
            {
                pessoaDAL.Alterar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Excluir(PessoaModel pessoa)
        {
            try
            {
                pessoaDAL.Excluir(pessoa);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public void Salvar(PessoaModel pessoa)
        {
            try
            {
                pessoaDAL.Salvar(pessoa);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDAL.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
