namespace Formee
{
    partial class FormRezervacija
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
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.cmbDestinacijeOd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDestinacijeDo = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDatumPolaska = new System.Windows.Forms.ListBox();
            this.lbDatumOdl = new System.Windows.Forms.ListBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAvion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSedistePov = new System.Windows.Forms.Label();
            this.lblSedistePovratak = new System.Windows.Forms.Label();
            this.lblSedistePocetak = new System.Windows.Forms.Label();
            this.btnOdaberiSediste = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(50, 331);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(228, 23);
            this.btnRezervisi.TabIndex = 0;
            this.btnRezervisi.Text = "Rezervisi";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // cmbDestinacijeOd
            // 
            this.cmbDestinacijeOd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinacijeOd.FormattingEnabled = true;
            this.cmbDestinacijeOd.Location = new System.Drawing.Point(50, 64);
            this.cmbDestinacijeOd.Name = "cmbDestinacijeOd";
            this.cmbDestinacijeOd.Size = new System.Drawing.Size(123, 21);
            this.cmbDestinacijeOd.TabIndex = 1;
            this.cmbDestinacijeOd.SelectedIndexChanged += new System.EventHandler(this.cmbDestinacijeOd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destinacije";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Do:";
            // 
            // cmbDestinacijeDo
            // 
            this.cmbDestinacijeDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinacijeDo.FormattingEnabled = true;
            this.cmbDestinacijeDo.Location = new System.Drawing.Point(237, 64);
            this.cmbDestinacijeDo.Name = "cmbDestinacijeDo";
            this.cmbDestinacijeDo.Size = new System.Drawing.Size(129, 21);
            this.cmbDestinacijeDo.TabIndex = 5;
            this.cmbDestinacijeDo.SelectedIndexChanged += new System.EventHandler(this.cmbDestinacijeDo_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(398, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "      Povratna karta";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Datum polaska:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Datum odlaska:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 360);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(491, 104);
            this.dataGridView1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Otkazi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDatumPolaska
            // 
            this.lbDatumPolaska.FormattingEnabled = true;
            this.lbDatumPolaska.Location = new System.Drawing.Point(96, 121);
            this.lbDatumPolaska.Name = "lbDatumPolaska";
            this.lbDatumPolaska.Size = new System.Drawing.Size(93, 95);
            this.lbDatumPolaska.TabIndex = 12;
            this.lbDatumPolaska.SelectedIndexChanged += new System.EventHandler(this.lbDatumPolaska_SelectedIndexChanged);
            // 
            // lbDatumOdl
            // 
            this.lbDatumOdl.FormattingEnabled = true;
            this.lbDatumOdl.Location = new System.Drawing.Point(290, 121);
            this.lbDatumOdl.Name = "lbDatumOdl";
            this.lbDatumOdl.Size = new System.Drawing.Size(93, 95);
            this.lbDatumOdl.TabIndex = 13;
            this.lbDatumOdl.SelectedIndexChanged += new System.EventHandler(this.lbDatumOdl_SelectedIndexChanged);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(160, 483);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(280, 31);
            this.btnSacuvaj.TabIndex = 14;
            this.btnSacuvaj.Text = "Sacuvaj rezervaciju";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sediste:";
            // 
            // cmbAvion
            // 
            this.cmbAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvion.FormattingEnabled = true;
            this.cmbAvion.Location = new System.Drawing.Point(428, 131);
            this.cmbAvion.Name = "cmbAvion";
            this.cmbAvion.Size = new System.Drawing.Size(121, 21);
            this.cmbAvion.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Avion:";
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(449, 11);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(168, 38);
            this.btnPretrazi.TabIndex = 24;
            this.btnPretrazi.Text = "Pretrazi letove";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblSedistePov);
            this.panel1.Controls.Add(this.lblSedistePovratak);
            this.panel1.Controls.Add(this.lblSedistePocetak);
            this.panel1.Controls.Add(this.btnOdaberiSediste);
            this.panel1.Controls.Add(this.btnPretrazi);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbAvion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSacuvaj);
            this.panel1.Controls.Add(this.lbDatumOdl);
            this.panel1.Controls.Add(this.lbDatumPolaska);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cmbDestinacijeDo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbDestinacijeOd);
            this.panel1.Controls.Add(this.btnRezervisi);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 582);
            this.panel1.TabIndex = 0;
            // 
            // lblSedistePov
            // 
            this.lblSedistePov.AutoSize = true;
            this.lblSedistePov.Location = new System.Drawing.Point(308, 233);
            this.lblSedistePov.Name = "lblSedistePov";
            this.lblSedistePov.Size = new System.Drawing.Size(10, 13);
            this.lblSedistePov.TabIndex = 38;
            this.lblSedistePov.Text = "-";
            // 
            // lblSedistePovratak
            // 
            this.lblSedistePovratak.AutoSize = true;
            this.lblSedistePovratak.Location = new System.Drawing.Point(254, 233);
            this.lblSedistePovratak.Name = "lblSedistePovratak";
            this.lblSedistePovratak.Size = new System.Drawing.Size(45, 13);
            this.lblSedistePovratak.TabIndex = 37;
            this.lblSedistePovratak.Text = "Sediste:";
            // 
            // lblSedistePocetak
            // 
            this.lblSedistePocetak.AutoSize = true;
            this.lblSedistePocetak.Location = new System.Drawing.Point(80, 233);
            this.lblSedistePocetak.Name = "lblSedistePocetak";
            this.lblSedistePocetak.Size = new System.Drawing.Size(10, 13);
            this.lblSedistePocetak.TabIndex = 36;
            this.lblSedistePocetak.Text = "-";
            // 
            // btnOdaberiSediste
            // 
            this.btnOdaberiSediste.Location = new System.Drawing.Point(428, 211);
            this.btnOdaberiSediste.Name = "btnOdaberiSediste";
            this.btnOdaberiSediste.Size = new System.Drawing.Size(142, 35);
            this.btnOdaberiSediste.TabIndex = 35;
            this.btnOdaberiSediste.Text = "Odaberi sediste";
            this.btnOdaberiSediste.UseVisualStyleBackColor = true;
            this.btnOdaberiSediste.Click += new System.EventHandler(this.btnOdaberiSediste_Click);
            // 
            // FormRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 537);
            this.Controls.Add(this.panel1);
            this.Name = "FormRezervacija";
            this.Text = "Rezervacija";
            this.Load += new System.EventHandler(this.Rezervacija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.ComboBox cmbDestinacijeOd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDestinacijeDo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbDatumPolaska;
        private System.Windows.Forms.ListBox lbDatumOdl;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAvion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOdaberiSediste;
        private System.Windows.Forms.Label lblSedistePov;
        private System.Windows.Forms.Label lblSedistePovratak;
        private System.Windows.Forms.Label lblSedistePocetak;
    }
}