namespace Kütüphane
{
    partial class Anasayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kişilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üyelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kütüphaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitaplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emanetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kişilerToolStripMenuItem,
            this.kütüphaneToolStripMenuItem,
            this.kullanıcıToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kişilerToolStripMenuItem
            // 
            this.kişilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personelToolStripMenuItem,
            this.üyelerToolStripMenuItem});
            this.kişilerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kişilerToolStripMenuItem.Image")));
            this.kişilerToolStripMenuItem.Name = "kişilerToolStripMenuItem";
            this.kişilerToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.kişilerToolStripMenuItem.Text = "Kişiler";
            // 
            // personelToolStripMenuItem
            // 
            this.personelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("personelToolStripMenuItem.Image")));
            this.personelToolStripMenuItem.Name = "personelToolStripMenuItem";
            this.personelToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.personelToolStripMenuItem.Text = "Personel";
            this.personelToolStripMenuItem.Click += new System.EventHandler(this.personelToolStripMenuItem_Click);
            // 
            // üyelerToolStripMenuItem
            // 
            this.üyelerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("üyelerToolStripMenuItem.Image")));
            this.üyelerToolStripMenuItem.Name = "üyelerToolStripMenuItem";
            this.üyelerToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.üyelerToolStripMenuItem.Text = "Üyeler";
            this.üyelerToolStripMenuItem.Click += new System.EventHandler(this.üyelerToolStripMenuItem_Click);
            // 
            // kütüphaneToolStripMenuItem
            // 
            this.kütüphaneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitaplarToolStripMenuItem,
            this.emanetToolStripMenuItem});
            this.kütüphaneToolStripMenuItem.Image = global::Kütüphane.Properties.Resources.books_icon_1_;
            this.kütüphaneToolStripMenuItem.Name = "kütüphaneToolStripMenuItem";
            this.kütüphaneToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.kütüphaneToolStripMenuItem.Text = "Kütüphane";
            // 
            // kitaplarToolStripMenuItem
            // 
            this.kitaplarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kitaplarToolStripMenuItem.Image")));
            this.kitaplarToolStripMenuItem.Name = "kitaplarToolStripMenuItem";
            this.kitaplarToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.kitaplarToolStripMenuItem.Text = "Kitaplar";
            this.kitaplarToolStripMenuItem.Click += new System.EventHandler(this.kitaplarToolStripMenuItem_Click);
            // 
            // emanetToolStripMenuItem
            // 
            this.emanetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("emanetToolStripMenuItem.Image")));
            this.emanetToolStripMenuItem.Name = "emanetToolStripMenuItem";
            this.emanetToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.emanetToolStripMenuItem.Text = "Emanet";
            this.emanetToolStripMenuItem.Click += new System.EventHandler(this.emanetToolStripMenuItem_Click);
            // 
            // kullanıcıToolStripMenuItem
            // 
            this.kullanıcıToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kullanıcıToolStripMenuItem.Image")));
            this.kullanıcıToolStripMenuItem.Name = "kullanıcıToolStripMenuItem";
            this.kullanıcıToolStripMenuItem.Size = new System.Drawing.Size(115, 29);
            this.kullanıcıToolStripMenuItem.Text = "Kullanıcı";
            this.kullanıcıToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("çıkışToolStripMenuItem.Image")));
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(992, 430);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kişilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üyelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kütüphaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitaplarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emanetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}