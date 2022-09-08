namespace Agenda
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btContato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btContato
            // 
            this.btContato.Location = new System.Drawing.Point(36, 24);
            this.btContato.Name = "btContato";
            this.btContato.Size = new System.Drawing.Size(208, 117);
            this.btContato.TabIndex = 0;
            this.btContato.Text = "Tarefas";
            this.btContato.UseVisualStyleBackColor = true;
            this.btContato.Click += new System.EventHandler(this.btContato_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btContato);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda 2022";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btContato;
    }
}

