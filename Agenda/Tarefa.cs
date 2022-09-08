using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Contato
    {
        public Contato()
        {
            this.Codigo = 0;
            this.Titulo = "";
            this.Descricao = "";
            this.Data = "";
            this.Inicio = "";
            this.Fim = "";
            this.Prioridade = "";
            this.Status = "";
        }

        public Contato(int codigo, string titulo, string descricao, string data, 
            string inicio, string fim, string prioridade, string status)
        {
            this.Codigo = codigo;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Data = data;
            this.Inicio = inicio;
            this.Fim = fim;
            this.Prioridade = prioridade;
            this.Status = status;
        }

        private int con_cod;
        public int Codigo
        {
            get
            {
                return this.con_cod;
            }
            set
            {
                this.con_cod = value;
            }
        }


        private string con_taref;
        public string Titulo
        {
            get { return this.con_taref; }
            set { this.con_taref = value; }
        }


        private string con_descri;
        public string Descricao
        {
            get { return this.con_descri; }
            set { this.con_descri = value; }
        }


        private string con_data;
        public string Data
        {
            get { return this.con_data; }
            set { this.con_data = value; }
        }


        private string con_hini;
        public string Inicio
        {
            get { return this.con_hini; }
            set { this.con_hini = value; }
        }


        private string con_hfim;
        public string Fim
        {
            get { return this.con_hfim; }
            set { this.con_hfim = value; }
        }


        private string con_prio;
        public string Prioridade
        {
            get { return this.con_prio; }
            set { this.con_prio = value; }
        }


        private string con_status;
        public string Status
        {
            get { return this.con_status; }
            set { this.con_status = value; }
        }

    }
}
