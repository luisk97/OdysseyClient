namespace OdysseyClient
{
    partial class VentanaPerfil
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.textBoxEd = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.lblEd = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblUs = new System.Windows.Forms.Label();
            this.textBoxUs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(264, 62);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(206, 24);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Nombre de Usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(263, 121);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(207, 24);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.Color.White;
            this.lblEdad.Location = new System.Drawing.Point(263, 180);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(63, 24);
            this.lblEdad.TabIndex = 3;
            this.lblEdad.Text = "Edad";
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::OdysseyClient.Properties.Resources.editar11;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(552, 0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 45);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OdysseyClient.Properties.Resources.User_blue;
            this.pictureBox1.Location = new System.Drawing.Point(0, -18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.btnCancel);
            this.panelEdit.Controls.Add(this.btnOk);
            this.panelEdit.Controls.Add(this.textBoxEd);
            this.panelEdit.Controls.Add(this.textBoxNom);
            this.panelEdit.Controls.Add(this.lblEd);
            this.panelEdit.Controls.Add(this.lblNom);
            this.panelEdit.Controls.Add(this.lblUs);
            this.panelEdit.Controls.Add(this.textBoxUs);
            this.panelEdit.Location = new System.Drawing.Point(253, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(411, 272);
            this.panelEdit.TabIndex = 5;
            this.panelEdit.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancel.Location = new System.Drawing.Point(233, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Black;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOk.Location = new System.Drawing.Point(324, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Confirmar";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // textBoxEd
            // 
            this.textBoxEd.BackColor = System.Drawing.Color.Black;
            this.textBoxEd.ForeColor = System.Drawing.Color.White;
            this.textBoxEd.Location = new System.Drawing.Point(115, 142);
            this.textBoxEd.Name = "textBoxEd";
            this.textBoxEd.Size = new System.Drawing.Size(284, 20);
            this.textBoxEd.TabIndex = 5;
            // 
            // textBoxNom
            // 
            this.textBoxNom.BackColor = System.Drawing.Color.Black;
            this.textBoxNom.ForeColor = System.Drawing.Color.White;
            this.textBoxNom.Location = new System.Drawing.Point(115, 92);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(284, 20);
            this.textBoxNom.TabIndex = 4;
            // 
            // lblEd
            // 
            this.lblEd.AutoSize = true;
            this.lblEd.ForeColor = System.Drawing.Color.White;
            this.lblEd.Location = new System.Drawing.Point(77, 145);
            this.lblEd.Name = "lblEd";
            this.lblEd.Size = new System.Drawing.Size(35, 13);
            this.lblEd.TabIndex = 3;
            this.lblEd.Text = "Edad:";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.ForeColor = System.Drawing.Color.White;
            this.lblNom.Location = new System.Drawing.Point(18, 95);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(94, 13);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nombre Completo:";
            // 
            // lblUs
            // 
            this.lblUs.AutoSize = true;
            this.lblUs.ForeColor = System.Drawing.Color.White;
            this.lblUs.Location = new System.Drawing.Point(11, 42);
            this.lblUs.Name = "lblUs";
            this.lblUs.Size = new System.Drawing.Size(101, 13);
            this.lblUs.TabIndex = 1;
            this.lblUs.Text = "Nombre de Usuario:";
            // 
            // textBoxUs
            // 
            this.textBoxUs.BackColor = System.Drawing.Color.Black;
            this.textBoxUs.ForeColor = System.Drawing.Color.White;
            this.textBoxUs.Location = new System.Drawing.Point(115, 39);
            this.textBoxUs.Name = "textBoxUs";
            this.textBoxUs.Size = new System.Drawing.Size(284, 20);
            this.textBoxUs.TabIndex = 0;
            // 
            // VentanaPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(665, 271);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VentanaPerfil";
            this.Opacity = 0.9D;
            this.Text = "VentanaPerfil";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label lblEd;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblUs;
        private System.Windows.Forms.TextBox textBoxUs;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox textBoxEd;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Button btnCancel;
    }
}