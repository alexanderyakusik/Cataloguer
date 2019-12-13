namespace Cataloguer.UI
{
    partial class Cataloguer
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuGroupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualitiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGroupMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuGroupMenuItem
            // 
            this.menuGroupMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companiesMenuItem,
            this.genresMenuItem,
            this.formatsMenuItem,
            this.qualitiesMenuItem});
            this.menuGroupMenuItem.Name = "menuGroupMenuItem";
            this.menuGroupMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuGroupMenuItem.Text = "Меню";
            this.menuGroupMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuGroupMenuItem_DropDownItemClicked);
            // 
            // companiesMenuItem
            // 
            this.companiesMenuItem.Name = "companiesMenuItem";
            this.companiesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.companiesMenuItem.Text = "Компании";
            // 
            // genresMenuItem
            // 
            this.genresMenuItem.Name = "genresMenuItem";
            this.genresMenuItem.Size = new System.Drawing.Size(180, 22);
            this.genresMenuItem.Text = "Жанры";
            // 
            // formatsMenuItem
            // 
            this.formatsMenuItem.Name = "formatsMenuItem";
            this.formatsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formatsMenuItem.Text = "Форматы";
            // 
            // qualitiesMenuItem
            // 
            this.qualitiesMenuItem.Name = "qualitiesMenuItem";
            this.qualitiesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.qualitiesMenuItem.Text = "Качества";
            // 
            // Cataloguer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Cataloguer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильмотека";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuGroupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genresMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualitiesMenuItem;
    }
}

