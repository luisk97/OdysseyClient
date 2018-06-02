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
            this.dataGridViewAmigos = new System.Windows.Forms.DataGridView();
            this.Persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAmigos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxBuscarA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAmigos
            // 
            this.dataGridViewAmigos.AllowUserToAddRows = false;
            this.dataGridViewAmigos.AllowUserToDeleteRows = false;
            this.dataGridViewAmigos.AllowUserToResizeColumns = false;
            this.dataGridViewAmigos.AllowUserToResizeRows = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAmigos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAmigos.EnableHeadersVisualStyles = false;
            this.dataGridViewAmigos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewAmigos.Location = new System.Drawing.Point(0, 53);
            this.dataGridViewAmigos.MultiSelect = false;
            this.dataGridViewAmigos.Name = "dataGridViewAmigos";
            this.dataGridViewAmigos.ReadOnly = true;
            this.dataGridViewAmigos.RowHeadersVisible = false;
            this.dataGridViewAmigos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAmigos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAmigos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAmigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAmigos.Size = new System.Drawing.Size(588, 262);
            this.dataGridViewAmigos.TabIndex = 0;
            this.dataGridViewAmigos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAmigos_CellMouseDoubleClick);
            // 
            // Persona
            // 
            this.Persona.HeaderText = "Usuario";
            this.Persona.Name = "Persona";
            this.Persona.ReadOnly = true;
            this.Persona.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Persona.Width = 180;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nombre.Width = 350;
            // 
            // btnAmigos
            // 
            this.btnAmigos.BackColor = System.Drawing.Color.Transparent;
            this.btnAmigos.FlatAppearance.BorderSize = 0;
            this.btnAmigos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAmigos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmigos.Image = global::OdysseyClient.Properties.Resources.BuscarAmigo2;
            this.btnAmigos.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAmigos.Location = new System.Drawing.Point(546, 10);
            this.btnAmigos.Name = "btnAmigos";
            this.btnAmigos.Size = new System.Drawing.Size(28, 28);
            this.btnAmigos.TabIndex = 1;
            this.btnAmigos.UseVisualStyleBackColor = false;
            this.btnAmigos.Click += new System.EventHandler(this.btnAmigos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OdysseyClient.Properties.Resources.fondoBuscarAmigo;
            this.pictureBox1.Location = new System.Drawing.Point(367, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxBuscarA
            // 
            this.textBoxBuscarA.BackColor = System.Drawing.Color.Black;
            this.textBoxBuscarA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBuscarA.ForeColor = System.Drawing.Color.White;
            this.textBoxBuscarA.Location = new System.Drawing.Point(379, 18);
            this.textBoxBuscarA.Name = "textBoxBuscarA";
            this.textBoxBuscarA.Size = new System.Drawing.Size(170, 13);
            this.textBoxBuscarA.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Amigos";
            // 
            // VentanaAmigos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(588, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBuscarA);
            this.Controls.Add(this.btnAmigos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewAmigos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VentanaAmigos";
            this.Text = "VentanaAmigos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAmigos;
        private System.Windows.Forms.Button btnAmigos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxBuscarA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Label label1;
    }
}