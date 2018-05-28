namespace OdysseyClient
{
    partial class VentanaAmigos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAmigos = new System.Windows.Forms.DataGridView();
            this.btnAmigos = new System.Windows.Forms.Button();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.Persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAmigos
            // 
            this.dataGridViewAmigos.AllowUserToAddRows = false;
            this.dataGridViewAmigos.AllowUserToDeleteRows = false;
            this.dataGridViewAmigos.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewAmigos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewAmigos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAmigos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAmigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAmigos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Persona,
            this.Nombre});
            this.dataGridViewAmigos.EnableHeadersVisualStyles = false;
            this.dataGridViewAmigos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewAmigos.Location = new System.Drawing.Point(0, 53);
            this.dataGridViewAmigos.MultiSelect = false;
            this.dataGridViewAmigos.Name = "dataGridViewAmigos";
            this.dataGridViewAmigos.RowHeadersVisible = false;
            this.dataGridViewAmigos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewAmigos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAmigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAmigos.Size = new System.Drawing.Size(535, 223);
            this.dataGridViewAmigos.TabIndex = 0;
            this.dataGridViewAmigos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAmigos_CellMouseDoubleClick);
            // 
            // btnAmigos
            // 
            this.btnAmigos.Location = new System.Drawing.Point(0, 24);
            this.btnAmigos.Name = "btnAmigos";
            this.btnAmigos.Size = new System.Drawing.Size(75, 23);
            this.btnAmigos.TabIndex = 1;
            this.btnAmigos.Text = "Amigos";
            this.btnAmigos.UseVisualStyleBackColor = true;
            this.btnAmigos.Click += new System.EventHandler(this.btnAmigos_Click);
            // 
            // btnPersonas
            // 
            this.btnPersonas.Location = new System.Drawing.Point(105, 24);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(75, 23);
            this.btnPersonas.TabIndex = 2;
            this.btnPersonas.Text = "Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            // 
            // Persona
            // 
            this.Persona.HeaderText = "Usuario";
            this.Persona.Name = "Persona";
            this.Persona.Width = 180;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 350;
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewUsuarios.EnableHeadersVisualStyles = false;
            this.dataGridViewUsuarios.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(0, 92);
            this.dataGridViewUsuarios.MultiSelect = false;
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowHeadersVisible = false;
            this.dataGridViewUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(535, 223);
            this.dataGridViewUsuarios.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // VentanaAmigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(588, 327);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnAmigos);
            this.Controls.Add(this.dataGridViewAmigos);
            this.Name = "VentanaAmigos";
            this.Text = "VentanaAmigos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAmigos;
        private System.Windows.Forms.Button btnAmigos;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}