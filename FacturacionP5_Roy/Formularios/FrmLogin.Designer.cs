
namespace FacturacionP5_Roy.Formularios
{
    partial class FrmLogin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.TxtContrasennia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PbVerPassword = new System.Windows.Forms.PictureBox();
            this.BtnIngresar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblRecuperarContrasennia = new System.Windows.Forms.LinkLabel();
            this.BtnIngresoDirecto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbVerPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(12, 151);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(178, 22);
            this.TxtUsuario.TabIndex = 1;
            this.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtContrasennia
            // 
            this.TxtContrasennia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContrasennia.Location = new System.Drawing.Point(12, 205);
            this.TxtContrasennia.Name = "TxtContrasennia";
            this.TxtContrasennia.Size = new System.Drawing.Size(178, 22);
            this.TxtContrasennia.TabIndex = 2;
            this.TxtContrasennia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtContrasennia.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONTRASEÑA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PbVerPassword
            // 
            this.PbVerPassword.BackColor = System.Drawing.Color.White;
            this.PbVerPassword.BackgroundImage = global::FacturacionP5_Roy.Properties.Resources.show3;
            this.PbVerPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PbVerPassword.Location = new System.Drawing.Point(167, 205);
            this.PbVerPassword.Name = "PbVerPassword";
            this.PbVerPassword.Size = new System.Drawing.Size(23, 22);
            this.PbVerPassword.TabIndex = 5;
            this.PbVerPassword.TabStop = false;
            this.PbVerPassword.Click += new System.EventHandler(this.PbVerPassword_Click);
            this.PbVerPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbVerPassword_MouseDown);
            this.PbVerPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbVerPassword_MouseUp);
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.BackColor = System.Drawing.Color.Green;
            this.BtnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIngresar.ForeColor = System.Drawing.Color.White;
            this.BtnIngresar.Location = new System.Drawing.Point(12, 279);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new System.Drawing.Size(75, 33);
            this.BtnIngresar.TabIndex = 6;
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.UseVisualStyleBackColor = false;
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Red;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(105, 279);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(85, 33);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblRecuperarContrasennia
            // 
            this.LblRecuperarContrasennia.AutoSize = true;
            this.LblRecuperarContrasennia.BackColor = System.Drawing.Color.Transparent;
            this.LblRecuperarContrasennia.Location = new System.Drawing.Point(102, 230);
            this.LblRecuperarContrasennia.Name = "LblRecuperarContrasennia";
            this.LblRecuperarContrasennia.Size = new System.Drawing.Size(108, 13);
            this.LblRecuperarContrasennia.TabIndex = 8;
            this.LblRecuperarContrasennia.TabStop = true;
            this.LblRecuperarContrasennia.Text = "Olivide mi contraseña";
            // 
            // BtnIngresoDirecto
            // 
            this.BtnIngresoDirecto.Location = new System.Drawing.Point(49, 334);
            this.BtnIngresoDirecto.Name = "BtnIngresoDirecto";
            this.BtnIngresoDirecto.Size = new System.Drawing.Size(115, 23);
            this.BtnIngresoDirecto.TabIndex = 9;
            this.BtnIngresoDirecto.Text = "Ingreso Directo";
            this.BtnIngresoDirecto.UseVisualStyleBackColor = true;
            this.BtnIngresoDirecto.Visible = false;
            this.BtnIngresoDirecto.Click += new System.EventHandler(this.BtnIngresoDirecto_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FacturacionP5_Roy.Properties.Resources.image1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(216, 369);
            this.Controls.Add(this.BtnIngresoDirecto);
            this.Controls.Add(this.LblRecuperarContrasennia);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.PbVerPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtContrasennia);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbVerPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.TextBox TxtContrasennia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PbVerPassword;
        private System.Windows.Forms.Button BtnIngresar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.LinkLabel LblRecuperarContrasennia;
        private System.Windows.Forms.Button BtnIngresoDirecto;
    }
}