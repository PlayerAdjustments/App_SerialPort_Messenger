namespace App_SerialPort_Messenger
{
    partial class Inicio_sesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio_sesion));
            this.Btn_entrar = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_entrar
            // 
            this.Btn_entrar.AutoSize = false;
            this.Btn_entrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_entrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Btn_entrar.Depth = 0;
            this.Btn_entrar.Enabled = false;
            this.Btn_entrar.HighEmphasis = true;
            this.Btn_entrar.Icon = null;
            this.Btn_entrar.Location = new System.Drawing.Point(409, 374);
            this.Btn_entrar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Btn_entrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_entrar.Name = "Btn_entrar";
            this.Btn_entrar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Btn_entrar.Size = new System.Drawing.Size(212, 62);
            this.Btn_entrar.TabIndex = 3;
            this.Btn_entrar.Text = "Iniciar Sesión";
            this.Btn_entrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_entrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Btn_entrar.UseAccentColor = false;
            this.Btn_entrar.UseVisualStyleBackColor = true;
            this.Btn_entrar.Click += new System.EventHandler(this.Btn_entrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(360, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione su canal de comunicación:";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(452, 203);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 132);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(723, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio_sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1049, 507);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_entrar);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Inicio_sesion";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.ShowIcon = false;
            this.Text = "Ceviche";
            this.Load += new System.EventHandler(this.Inicio_sesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton Btn_entrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}