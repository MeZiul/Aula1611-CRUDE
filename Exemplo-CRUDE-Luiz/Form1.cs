using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exemplo_CRUDE_Luiz.BLL;
using Exemplo_CRUDE_Luiz.Model;

namespace Exemplo_CRUDE_Luiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Salvar(PessoaModel pessoa)
        {
            pessoasBLL pessoasBLL = new pessoasBLL();
                try
            {
                if (txtNome.Text.Trim() == String.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);// apresenta uma tela de informação
                    txtNome.BackColor = Color.LightYellow;//muda a cor do campo
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.White;
                }
                else if (!mtbCPF.MaskCompleted)
                {
                    MessageBox.Show("O campo CPF não pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.White;
                    mtbCPF.BackColor = Color.LightYellow;
                }
                else if (cbSexo.Text == String.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode ser vazio!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    cbSexo.BackColor = Color.LightYellow;
                    mtbCPF.BackColor = Color.White;
                }
                else
                {
                    pessoa.Name = txtNome.Text;
                    pessoa.Nasc = dtNasc.Text;
                    pessoa.Sexo = cbSexo.Text;
                    mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // remove as mascaras
                    pessoa.Cpf = mtbCPF.Text;
                    mtbCell.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Celular = mtbCell.Text;
                    pessoa.Endereco = txtEndereco.Text;
                    pessoa.Bairro = txtBairro.Text;
                    pessoa.Cidade = txtCidade.Text;
                    pessoa.Estado = cbEstado.Text;
                    mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    pessoa.Cep = mtbCEP.Text;

                    pessoasBLL.Salvar(pessoa);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("erro ao realizar cadastro!\n"+erro, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);// apresenta uma tela de informação
                throw erro;
            }
                }




        private void Listar()
        { pessoasBLL pessoasBLL = new pessoasBLL();
            try
            {
                dataGridView.DataSource = pessoasBLL.Listar();

                //renomear coluna
                dataGridView.Columns[0].HeaderText = "Código";
                dataGridView.Columns[1].HeaderText = "Nome";
                dataGridView.Columns[2].HeaderText = "Dt.Nasc";
                dataGridView.Columns[3].HeaderText = "Sexo";
                dataGridView.Columns[4].HeaderText = "CPF";
                dataGridView.Columns[5].HeaderText = "Tel.Celular";
                dataGridView.Columns[6].HeaderText = "Endereço";
                dataGridView.Columns[7].HeaderText = "Bairro";
                dataGridView.Columns[8].HeaderText = "Cidade";
                dataGridView.Columns[9].HeaderText = "UF";
                dataGridView.Columns[10].HeaderText = "CEP";

                //Remover colunas do datagrid
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;

                //Ajuste largura das colunas
                dataGridView.Columns[0].Width = 45;
                dataGridView.Columns[1].Width = 165;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 40;
                dataGridView.Columns[4].Width = 80;
                dataGridView.Columns[5].Width = 90;

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao exibir os dados!\n"+erro,"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw erro;
            }
        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PessoaModel pessoa = new PessoaModel();
            Salvar(pessoa);
        }
    }
}

