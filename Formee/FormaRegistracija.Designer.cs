namespace Formee
{
    partial class FormaRegistracija
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.lb4 = new System.Windows.Forms.Label();
            this.Lb1 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPRez = new System.Windows.Forms.TextBox();
            this.txJmbg = new System.Windows.Forms.TextBox();
            this.txtDat = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sacuvaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(9, 96);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(44, 13);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "Prezime";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Location = new System.Drawing.Point(9, 134);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(36, 13);
            this.lb3.TabIndex = 3;
            this.lb3.Text = "JMBG";
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Location = new System.Drawing.Point(9, 171);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(83, 13);
            this.lb4.TabIndex = 4;
            this.lb4.Text = "Datum Rodjenja";
            // 
            // Lb1
            // 
            this.Lb1.AutoSize = true;
            this.Lb1.Location = new System.Drawing.Point(9, 22);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(71, 13);
            this.Lb1.TabIndex = 5;
            this.Lb1.Text = "SifraKorisnika";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(98, 55);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(100, 20);
            this.txtIme.TabIndex = 8;
            // 
            // txtPRez
            // 
            this.txtPRez.Location = new System.Drawing.Point(98, 93);
            this.txtPRez.Name = "txtPRez";
            this.txtPRez.Size = new System.Drawing.Size(100, 20);
            this.txtPRez.TabIndex = 9;
            // 
            // txJmbg
            // 
            this.txJmbg.Location = new System.Drawing.Point(98, 131);
            this.txJmbg.Name = "txJmbg";
            this.txJmbg.Size = new System.Drawing.Size(100, 20);
            this.txJmbg.TabIndex = 10;
            // 
            // txtDat
            // 
            this.txtDat.Location = new System.Drawing.Point(98, 168);
            this.txtDat.Name = "txtDat";
            this.txtDat.Size = new System.Drawing.Size(100, 20);
            this.txtDat.TabIndex = 11;
            this.txtDat.Text = "25.03.1998";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(98, 19);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtKorisnickoIme);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPRez);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lb2);
            this.panel1.Controls.Add(this.txtDat);
            this.panel1.Controls.Add(this.lb3);
            this.panel1.Controls.Add(this.txJmbg);
            this.panel1.Controls.Add(this.lb4);
            this.panel1.Controls.Add(this.Lb1);
            this.panel1.Controls.Add(this.txtIme);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 362);
            this.panel1.TabIndex = 15;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(98, 243);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 16;
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(98, 206);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(100, 20);
            this.txtKorisnickoIme.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Sifra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Korisnicko ime";
            // 
            // FormaRegistracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 386);
            this.Controls.Add(this.panel1);
            this.Name = "FormaRegistracija";
            this.Text = "Registracija";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.Label Lb1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPRez;
        private System.Windows.Forms.TextBox txJmbg;
        private System.Windows.Forms.TextBox txtDat;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}