namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.analizar_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewErrores = new System.Windows.Forms.DataGridView();
            this.dataGridViewTokens = new System.Windows.Forms.DataGridView();
            this.lable2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compiladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sintacticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semanticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 45);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(388, 484);
            this.txtBox.TabIndex = 1;
            this.txtBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // analizar_btn
            // 
            this.analizar_btn.Location = new System.Drawing.Point(406, 27);
            this.analizar_btn.Name = "analizar_btn";
            this.analizar_btn.Size = new System.Drawing.Size(94, 42);
            this.analizar_btn.TabIndex = 3;
            this.analizar_btn.Text = "Analizar Codigo";
            this.analizar_btn.UseVisualStyleBackColor = true;
            this.analizar_btn.Click += new System.EventHandler(this.analizar_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Codigo";
            // 
            // dataGridViewErrores
            // 
            this.dataGridViewErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewErrores.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewErrores.Name = "dataGridViewErrores";
            this.dataGridViewErrores.RowTemplate.Height = 25;
            this.dataGridViewErrores.Size = new System.Drawing.Size(520, 184);
            this.dataGridViewErrores.TabIndex = 5;
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTokens.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            this.dataGridViewTokens.Size = new System.Drawing.Size(520, 217);
            this.dataGridViewTokens.TabIndex = 6;
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Location = new System.Drawing.Point(406, 84);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(43, 15);
            this.lable2.TabIndex = 7;
            this.lable2.Text = "Errores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tokens";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.compiladorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // compiladorToolStripMenuItem
            // 
            this.compiladorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicoToolStripMenuItem,
            this.sintacticoToolStripMenuItem,
            this.semanticoToolStripMenuItem});
            this.compiladorToolStripMenuItem.Name = "compiladorToolStripMenuItem";
            this.compiladorToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.compiladorToolStripMenuItem.Text = "Compilador";
            // 
            // lexicoToolStripMenuItem
            // 
            this.lexicoToolStripMenuItem.Name = "lexicoToolStripMenuItem";
            this.lexicoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lexicoToolStripMenuItem.Text = "Lexico";
            // 
            // sintacticoToolStripMenuItem
            // 
            this.sintacticoToolStripMenuItem.Name = "sintacticoToolStripMenuItem";
            this.sintacticoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.sintacticoToolStripMenuItem.Text = "Sintactico";
            // 
            // semanticoToolStripMenuItem
            // 
            this.semanticoToolStripMenuItem.Name = "semanticoToolStripMenuItem";
            this.semanticoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.semanticoToolStripMenuItem.Text = "Semantico";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewErrores);
            this.panel1.Location = new System.Drawing.Point(406, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 184);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewTokens);
            this.panel2.Location = new System.Drawing.Point(406, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 217);
            this.panel2.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 541);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lable2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.analizar_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox txtBox;
        private Label label1;
        private Button analizar_btn;
        private Label label2;
        private DataGridView dataGridViewErrores;
        private DataGridView dataGridViewTokens;
        private Label lable2;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem compiladorToolStripMenuItem;
        private ToolStripMenuItem lexicoToolStripMenuItem;
        private ToolStripMenuItem sintacticoToolStripMenuItem;
        private ToolStripMenuItem semanticoToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
    }
}