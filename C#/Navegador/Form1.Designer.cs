namespace Navegador
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.webZAOF = new System.Windows.Forms.WebBrowser();
            this.grpWebs = new System.Windows.Forms.GroupBox();
            this.radMiURL = new System.Windows.Forms.RadioButton();
            this.radGoogle = new System.Windows.Forms.RadioButton();
            this.btnNavegar = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFondo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpWebs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.webZAOF, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpWebs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnNavegar, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(881, 721);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(875, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorador ZAOF";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webZAOF
            // 
            this.webZAOF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webZAOF.Location = new System.Drawing.Point(3, 38);
            this.webZAOF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webZAOF.MinimumSize = new System.Drawing.Size(20, 20);
            this.webZAOF.Name = "webZAOF";
            this.webZAOF.Size = new System.Drawing.Size(875, 500);
            this.webZAOF.TabIndex = 1;
            // 
            // grpWebs
            // 
            this.grpWebs.Controls.Add(this.btnColor);
            this.grpWebs.Controls.Add(this.label3);
            this.grpWebs.Controls.Add(this.cmbFondo);
            this.grpWebs.Controls.Add(this.label2);
            this.grpWebs.Controls.Add(this.txtURL);
            this.grpWebs.Controls.Add(this.radMiURL);
            this.grpWebs.Controls.Add(this.radGoogle);
            this.grpWebs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWebs.Location = new System.Drawing.Point(3, 542);
            this.grpWebs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpWebs.Name = "grpWebs";
            this.grpWebs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpWebs.Size = new System.Drawing.Size(875, 104);
            this.grpWebs.TabIndex = 2;
            this.grpWebs.TabStop = false;
            this.grpWebs.Text = "Webs";
            // 
            // radMiURL
            // 
            this.radMiURL.Location = new System.Drawing.Point(409, 37);
            this.radMiURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radMiURL.Name = "radMiURL";
            this.radMiURL.Size = new System.Drawing.Size(100, 40);
            this.radMiURL.TabIndex = 1;
            this.radMiURL.TabStop = true;
            this.radMiURL.Text = "MI URL";
            this.radMiURL.UseVisualStyleBackColor = true;
            // 
            // radGoogle
            // 
            this.radGoogle.Location = new System.Drawing.Point(9, 31);
            this.radGoogle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radGoogle.Name = "radGoogle";
            this.radGoogle.Size = new System.Drawing.Size(104, 40);
            this.radGoogle.TabIndex = 0;
            this.radGoogle.TabStop = true;
            this.radGoogle.Text = "Google";
            this.radGoogle.UseVisualStyleBackColor = true;
            // 
            // btnNavegar
            // 
            this.btnNavegar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNavegar.Location = new System.Drawing.Point(3, 651);
            this.btnNavegar.Name = "btnNavegar";
            this.btnNavegar.Size = new System.Drawing.Size(875, 67);
            this.btnNavegar.TabIndex = 3;
            this.btnNavegar.Text = "NAVEGAR";
            this.btnNavegar.UseVisualStyleBackColor = true;
            this.btnNavegar.Click += new System.EventHandler(this.btnNavegar_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(146, 44);
            this.txtURL.MaxLength = 500;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(248, 27);
            this.txtURL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(146, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navega Directo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFondo
            // 
            this.cmbFondo.FormattingEnabled = true;
            this.cmbFondo.Location = new System.Drawing.Point(573, 44);
            this.cmbFondo.Name = "cmbFondo";
            this.cmbFondo.Size = new System.Drawing.Size(140, 28);
            this.cmbFondo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(573, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Color de Fondo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(744, 37);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 37);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "CAMBIAR";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(881, 721);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpWebs.ResumeLayout(false);
            this.grpWebs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpWebs;
        private System.Windows.Forms.WebBrowser webZAOF;
        private System.Windows.Forms.RadioButton radGoogle;
        private System.Windows.Forms.Button btnNavegar;
        private System.Windows.Forms.RadioButton radMiURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFondo;
        private System.Windows.Forms.Button btnColor;
    }
}