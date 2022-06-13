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
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 54);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(376, 441);
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
            this.analizar_btn.Location = new System.Drawing.Point(534, 54);
            this.analizar_btn.Name = "analizar_btn";
            this.analizar_btn.Size = new System.Drawing.Size(94, 42);
            this.analizar_btn.TabIndex = 3;
            this.analizar_btn.Text = "Analizar Codigo";
            this.analizar_btn.UseVisualStyleBackColor = true;
            this.analizar_btn.Click += new System.EventHandler(this.analizar_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 541);
            this.Controls.Add(this.analizar_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox txtBox;
        private Label label1;
        private Button analizar_btn;
    }
}