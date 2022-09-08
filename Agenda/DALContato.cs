using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Agenda
{
    class DALContato
    {

        private Conexao objConexao;

        public DALContato(Conexao conexao)
        {
            objConexao = conexao;
        }

        public void Incluir(Contato contato)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "insert into contato(con_taref, con_descri,"+
                "con_data, con_hini, con_hfim, con_prio, con_status)"+
                " values (@taref, @descri, @data, @hini, @hfim,"+
                "@prio, @status); select @@IDENTITY;";

            cmd.Parameters.AddWithValue("@taref", contato.Titulo);
            cmd.Parameters.AddWithValue("@descri", contato.Descricao);
            cmd.Parameters.AddWithValue("@data", contato.Data);
            cmd.Parameters.AddWithValue("@hini", contato.Inicio);
            cmd.Parameters.AddWithValue("@hfim", contato.Fim);
            cmd.Parameters.AddWithValue("@prio", contato.Prioridade);
            cmd.Parameters.AddWithValue("@status", contato.Status);
            objConexao.Conectar();
            contato.Codigo = Convert.ToInt32(cmd.ExecuteScalar());
            objConexao.Desconectar();

        }

        public void Alterar(Contato contato)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "update contato set con_taref=@taref, con_descri=@descri, con_data=@data, " +
                " con_hini=@hini, con_hfim=@hfim, con_prio=@prio, con_status=@status " +
                " where con_cod = @cod";
            cmd.Parameters.AddWithValue("@taref", contato.Titulo);
            cmd.Parameters.AddWithValue("@descri", contato.Descricao);
            cmd.Parameters.AddWithValue("@data", contato.Data);
            cmd.Parameters.AddWithValue("@hini", contato.Inicio);
            cmd.Parameters.AddWithValue("@hfim", contato.Fim);
            cmd.Parameters.AddWithValue("@prio", contato.Prioridade);
            cmd.Parameters.AddWithValue("@status", contato.Status);
            cmd.Parameters.AddWithValue("@cod", contato.Codigo);
            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();

        }

        public void Excluir(int Codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "delete from contato" +
                " where con_cod = @cod";
            cmd.Parameters.AddWithValue("@cod", Codigo);
            objConexao.Conectar();
            cmd.ExecuteNonQuery();
            objConexao.Desconectar();


        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from contato where con_taref like '%" +
                valor + "%'", objConexao.StringConexao);
            da.Fill(tabela);
            return tabela;  
        }

        public Contato carregaContato(int codigo)
        {
            Contato modelo = new Contato();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConexao.ObjetoConexao;
            cmd.CommandText = "select * from contato where con_cod =" + codigo.ToString();
            objConexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.Codigo = Convert.ToInt32(registro["con_cod"]);
                modelo.Titulo = Convert.ToString(registro["con_taref"]);
                modelo.Descricao = Convert.ToString(registro["con_descri"]);
                modelo.Data = Convert.ToString(registro["con_data"]);
                modelo.Inicio = Convert.ToString(registro["con_hini"]);
                modelo.Fim = Convert.ToString(registro["con_hfim"]);
                modelo.Prioridade = Convert.ToString(registro["con_prio"]);
                modelo.Status = Convert.ToString(registro["con_status"]);

            }
            return modelo;

        }

    }
}
