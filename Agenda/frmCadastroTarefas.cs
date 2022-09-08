using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmCadastroTarefas : Form
    {
        public string operacao = "";
        public frmCadastroTarefas()
        {
            InitializeComponent();
        }

        public void AlteraBotoes(int op)
        {
            pDados.Enabled = false;
            btInserir.Enabled = false;
            btLocalizar.Enabled = false;
            btAlterar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            btCancelar.Enabled = false;

            if(op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }
            if(op == 2)
            {
                pDados.Enabled = true;
                btSalvar.Enabled = true;
                btCancelar.Enabled = true;
            }
            if(op == 3)
            {
                btExcluir.Enabled = true;
                btAlterar.Enabled = true;
                btCancelar.Enabled = true;

            }

        }

        public void LimpaCampos()
        {
            txtCodigo.Clear();
            txtTarefa.Clear();
            txtDescricao.Clear();
            txtData.Clear();
            txtHinicio.Clear();
            txtHfim.Clear();
            txtPrioridade.Clear();
            txtStatus.Clear();
        }

        private void frmCadastroTarefas_Load(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.AlteraBotoes(2);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                Contato contato = new Contato();
                if(txtTarefa.Text.Length <= 0)
                {
                    MessageBox.Show("Titulo da tarefa obrigatório");
                    return;
                }
                if (txtDescricao.Text.Length <= 0)
                {
                    MessageBox.Show("Descrição da tarefa obrigatório");
                    return;
                }
                if (txtData.Text.Length <= 0)
                {
                    MessageBox.Show("Data da tarefa obrigatório");
                    return;
                }                              
                if (txtPrioridade.Text.Length <= 0)
                {
                    MessageBox.Show("Prioridade da tarefa obrigatório");
                    return;
                }
                if (txtStatus.Text.Length <= 0)
                {
                    MessageBox.Show("Status da tarefa obrigatório");
                    return;
                }
                contato.Titulo = txtTarefa.Text;
                contato.Descricao = txtDescricao.Text;
                contato.Data = txtData.Text;
                contato.Inicio = txtHinicio.Text;
                contato.Fim = txtHfim.Text;
                contato.Prioridade = txtPrioridade.Text;
                contato.Status = txtStatus.Text;

                //inserir um registro no banco de dados
                String strConexao = "Data Source=DESKTOP-P43OHMJ\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;Pooling=False";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);

                if (this.operacao == "inserir")
                {

                    dal.Incluir(contato);
                    MessageBox.Show("O código gerado foi:"+contato.Codigo.ToString());


                }
                else
                {
                    contato.Codigo = Convert.ToInt32(txtCodigo.Text);
                    dal.Alterar(contato);
                    MessageBox.Show("Tarefa Alterada");
                    //alterar o contato que esta na tela
                }
                this.AlteraBotoes(1);
                this.LimpaCampos();
            }

            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }




        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaTarefas f = new frmConsultaTarefas();
            f.ShowDialog();
            if(f.codigo != 0)
            {
                String strConexao = "Data Source=DESKTOP-P43OHMJ\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;Pooling=False";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);
                Contato contato = dal.carregaContato(f.codigo);
                txtCodigo.Text = contato.Codigo.ToString();
                txtTarefa.Text = contato.Titulo;
                txtDescricao.Text = contato.Descricao;
                txtData.Text = contato.Data;
                txtHinicio.Text = contato.Inicio;
                txtHfim.Text = contato.Fim;
                txtPrioridade.Text = contato.Prioridade;
                txtStatus.Text = contato.Status;
                this.AlteraBotoes(3);

            }
            f.Dispose();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Deseja excluir a tarefa?", "Aviso", MessageBoxButtons.YesNo);
            if(d.ToString() == "Yes")
            {

                String strConexao = "Data Source=DESKTOP-P43OHMJ\\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;Pooling=False";
                Conexao conexao = new Conexao(strConexao);
                DALContato dal = new DALContato(conexao);
                dal.Excluir(Convert.ToInt32(txtCodigo.Text));
                this.AlteraBotoes(1);
                this.LimpaCampos();

            }

        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.AlteraBotoes(2);
        }
    }
}
