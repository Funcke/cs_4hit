namespace PersonTableWithDataAdapter
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataView = new System.Windows.Forms.DataGridView();
            this.cmd_update = new System.Windows.Forms.Button();
            this.cmd_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(12, 12);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 24;
            this.dataView.Size = new System.Drawing.Size(776, 360);
            this.dataView.TabIndex = 0;
            // 
            // cmd_update
            // 
            this.cmd_update.Location = new System.Drawing.Point(12, 378);
            this.cmd_update.Name = "cmd_update";
            this.cmd_update.Size = new System.Drawing.Size(164, 60);
            this.cmd_update.TabIndex = 1;
            this.cmd_update.Text = "Update";
            this.cmd_update.UseVisualStyleBackColor = true;
            this.cmd_update.Click += new System.EventHandler(this.cmd_update_Click);
            // 
            // cmd_exit
            // 
            this.cmd_exit.Location = new System.Drawing.Point(624, 378);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(164, 60);
            this.cmd_exit.TabIndex = 2;
            this.cmd_exit.Text = "Exit";
            this.cmd_exit.UseVisualStyleBackColor = true;
            this.cmd_exit.Click += new System.EventHandler(this.cmd_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.cmd_update);
            this.Controls.Add(this.dataView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button cmd_update;
        private System.Windows.Forms.Button cmd_exit;
    }
}

