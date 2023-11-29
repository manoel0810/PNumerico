namespace PNumerico
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MathGrid = new System.Windows.Forms.Panel();
            this.VarCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ExecProc = new System.Windows.Forms.Button();
            this.matrix1 = new Control.MatrixControl();
            this.MathGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VarCount)).BeginInit();
            this.SuspendLayout();
            // 
            // MathGrid
            // 
            this.MathGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MathGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MathGrid.Controls.Add(this.matrix1);
            this.MathGrid.Location = new System.Drawing.Point(16, 55);
            this.MathGrid.Name = "MathGrid";
            this.MathGrid.Size = new System.Drawing.Size(626, 358);
            this.MathGrid.TabIndex = 1;
            // 
            // VarCount
            // 
            this.VarCount.Location = new System.Drawing.Point(151, 26);
            this.VarCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.VarCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.VarCount.Name = "VarCount";
            this.VarCount.Size = new System.Drawing.Size(65, 20);
            this.VarCount.TabIndex = 2;
            this.VarCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VarCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.VarCount.ValueChanged += new System.EventHandler(this.VarCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número de variáveis:";
            // 
            // ExecProc
            // 
            this.ExecProc.Cursor = System.Windows.Forms.Cursors.Help;
            this.ExecProc.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.ExecProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecProc.ForeColor = System.Drawing.Color.Green;
            this.ExecProc.Location = new System.Drawing.Point(536, 26);
            this.ExecProc.Name = "ExecProc";
            this.ExecProc.Size = new System.Drawing.Size(106, 23);
            this.ExecProc.TabIndex = 4;
            this.ExecProc.Text = "Calcular";
            this.ExecProc.UseVisualStyleBackColor = true;
            this.ExecProc.Click += new System.EventHandler(this.ExecProc_Click);
            // 
            // matrix1
            // 
            this.matrix1.Location = new System.Drawing.Point(13, 7);
            this.matrix1.MatrixSize = 0;
            this.matrix1.Name = "matrix1";
            this.matrix1.Size = new System.Drawing.Size(599, 301);
            this.matrix1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(657, 429);
            this.Controls.Add(this.ExecProc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VarCount);
            this.Controls.Add(this.MathGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cálculo Numérico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MathGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VarCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.MatrixControl matrix1;
        private System.Windows.Forms.Panel MathGrid;
        private System.Windows.Forms.NumericUpDown VarCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExecProc;
    }
}

