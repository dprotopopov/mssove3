namespace Elliptic
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.wizardPages1 = new Elliptic.WizardPages();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownA6 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownA4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownA3 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownA2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownA1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.wizardPages1.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.tabPage0);
            this.wizardPages1.Controls.Add(this.tabPage1);
            this.wizardPages1.Controls.Add(this.tabPage2);
            this.wizardPages1.Controls.Add(this.tabPage3);
            this.wizardPages1.Controls.Add(this.tabPage4);
            this.wizardPages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPages1.Location = new System.Drawing.Point(0, 0);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(909, 653);
            this.wizardPages1.TabIndex = 0;
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.textBox1);
            this.tabPage0.Location = new System.Drawing.Point(4, 29);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage0.Size = new System.Drawing.Size(901, 620);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Text = "Добро пожаловать";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(895, 614);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.numericUpDownA6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.numericUpDownA4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.numericUpDownA3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numericUpDownA2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericUpDownA1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.numericUpDownN);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(901, 620);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Параметры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 63);
            this.button1.TabIndex = 12;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "a6";
            // 
            // numericUpDownA6
            // 
            this.numericUpDownA6.Location = new System.Drawing.Point(333, 262);
            this.numericUpDownA6.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownA6.Name = "numericUpDownA6";
            this.numericUpDownA6.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownA6.TabIndex = 10;
            this.numericUpDownA6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "a4";
            // 
            // numericUpDownA4
            // 
            this.numericUpDownA4.Location = new System.Drawing.Point(333, 230);
            this.numericUpDownA4.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownA4.Name = "numericUpDownA4";
            this.numericUpDownA4.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownA4.TabIndex = 8;
            this.numericUpDownA4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "a3";
            // 
            // numericUpDownA3
            // 
            this.numericUpDownA3.Location = new System.Drawing.Point(333, 198);
            this.numericUpDownA3.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownA3.Name = "numericUpDownA3";
            this.numericUpDownA3.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownA3.TabIndex = 6;
            this.numericUpDownA3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "a2";
            // 
            // numericUpDownA2
            // 
            this.numericUpDownA2.Location = new System.Drawing.Point(333, 166);
            this.numericUpDownA2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownA2.Name = "numericUpDownA2";
            this.numericUpDownA2.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownA2.TabIndex = 4;
            this.numericUpDownA2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "a1";
            // 
            // numericUpDownA1
            // 
            this.numericUpDownA1.Location = new System.Drawing.Point(333, 134);
            this.numericUpDownA1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownA1.Name = "numericUpDownA1";
            this.numericUpDownA1.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownA1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "N";
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(333, 92);
            this.numericUpDownN.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(234, 26);
            this.numericUpDownN.TabIndex = 0;
            this.numericUpDownN.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(901, 620);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "График";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(895, 614);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(901, 620);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Отчёт";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 3);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(895, 614);
            this.textBox2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(901, 620);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "gnuplot";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(895, 614);
            this.textBox3.TabIndex = 0;
            this.textBox3.DoubleClick += new System.EventHandler(this.textBox3_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 653);
            this.Controls.Add(this.wizardPages1);
            this.Name = "Form1";
            this.Text = "Эллиптическая кривая в кольце вычетов";
            this.wizardPages1.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            this.tabPage0.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage0;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownA6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownA4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownA3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownA2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownA1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

