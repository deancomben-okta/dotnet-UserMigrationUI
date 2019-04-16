namespace UserMigrationUI
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.testData_tab = new System.Windows.Forms.TabPage();
            this.testDataDelete_btn = new System.Windows.Forms.Button();
            this.testDataStart_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.jsonFile_tab = new System.Windows.Forms.TabPage();
            this.displayOpenFileDialog_btn = new System.Windows.Forms.Button();
            this.jsonFilename_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jsonFileDelete_btn = new System.Windows.Forms.Button();
            this.jsonFileStart_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.testData_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.jsonFile_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(12, 269);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBox.Size = new System.Drawing.Size(776, 169);
            this.txtBox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.testData_tab);
            this.tabControl1.Controls.Add(this.jsonFile_tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 251);
            this.tabControl1.TabIndex = 5;
            // 
            // testData_tab
            // 
            this.testData_tab.Controls.Add(this.testDataDelete_btn);
            this.testData_tab.Controls.Add(this.testDataStart_btn);
            this.testData_tab.Controls.Add(this.label1);
            this.testData_tab.Controls.Add(this.numericUpDown1);
            this.testData_tab.Location = new System.Drawing.Point(4, 22);
            this.testData_tab.Name = "testData_tab";
            this.testData_tab.Padding = new System.Windows.Forms.Padding(3);
            this.testData_tab.Size = new System.Drawing.Size(768, 225);
            this.testData_tab.TabIndex = 0;
            this.testData_tab.Text = "Test Data";
            this.testData_tab.UseVisualStyleBackColor = true;
            // 
            // testDataDelete_btn
            // 
            this.testDataDelete_btn.Location = new System.Drawing.Point(408, 110);
            this.testDataDelete_btn.Name = "testDataDelete_btn";
            this.testDataDelete_btn.Size = new System.Drawing.Size(212, 89);
            this.testDataDelete_btn.TabIndex = 8;
            this.testDataDelete_btn.Text = "Delete";
            this.testDataDelete_btn.UseVisualStyleBackColor = true;
            this.testDataDelete_btn.Click += new System.EventHandler(this.TestDataDelete_btn_Click);
            // 
            // testDataStart_btn
            // 
            this.testDataStart_btn.Location = new System.Drawing.Point(10, 110);
            this.testDataStart_btn.Name = "testDataStart_btn";
            this.testDataStart_btn.Size = new System.Drawing.Size(259, 89);
            this.testDataStart_btn.TabIndex = 7;
            this.testDataStart_btn.Text = "Start";
            this.testDataStart_btn.UseVisualStyleBackColor = true;
            this.testDataStart_btn.Click += new System.EventHandler(this.TestDataStart_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number of Users";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(120, 30);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // jsonFile_tab
            // 
            this.jsonFile_tab.Controls.Add(this.displayOpenFileDialog_btn);
            this.jsonFile_tab.Controls.Add(this.jsonFilename_textBox);
            this.jsonFile_tab.Controls.Add(this.label2);
            this.jsonFile_tab.Controls.Add(this.jsonFileDelete_btn);
            this.jsonFile_tab.Controls.Add(this.jsonFileStart_btn);
            this.jsonFile_tab.Location = new System.Drawing.Point(4, 22);
            this.jsonFile_tab.Name = "jsonFile_tab";
            this.jsonFile_tab.Padding = new System.Windows.Forms.Padding(3);
            this.jsonFile_tab.Size = new System.Drawing.Size(768, 225);
            this.jsonFile_tab.TabIndex = 1;
            this.jsonFile_tab.Text = "JSON File";
            this.jsonFile_tab.UseVisualStyleBackColor = true;
            // 
            // displayOpenFileDialog_btn
            // 
            this.displayOpenFileDialog_btn.Location = new System.Drawing.Point(725, 31);
            this.displayOpenFileDialog_btn.Name = "displayOpenFileDialog_btn";
            this.displayOpenFileDialog_btn.Size = new System.Drawing.Size(27, 19);
            this.displayOpenFileDialog_btn.TabIndex = 13;
            this.displayOpenFileDialog_btn.Text = "...";
            this.displayOpenFileDialog_btn.UseVisualStyleBackColor = true;
            this.displayOpenFileDialog_btn.Click += new System.EventHandler(this.DisplayOpenFileDialog_btn_Click);
            // 
            // jsonFilename_textBox
            // 
            this.jsonFilename_textBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.jsonFilename_textBox.Enabled = false;
            this.jsonFilename_textBox.Location = new System.Drawing.Point(120, 30);
            this.jsonFilename_textBox.Name = "jsonFilename_textBox";
            this.jsonFilename_textBox.Size = new System.Drawing.Size(592, 20);
            this.jsonFilename_textBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filename";
            // 
            // jsonFileDelete_btn
            // 
            this.jsonFileDelete_btn.Location = new System.Drawing.Point(408, 110);
            this.jsonFileDelete_btn.Name = "jsonFileDelete_btn";
            this.jsonFileDelete_btn.Size = new System.Drawing.Size(212, 89);
            this.jsonFileDelete_btn.TabIndex = 10;
            this.jsonFileDelete_btn.Text = "Delete";
            this.jsonFileDelete_btn.UseVisualStyleBackColor = true;
            this.jsonFileDelete_btn.Click += new System.EventHandler(this.JsonFileDelete_btn_Click);
            // 
            // jsonFileStart_btn
            // 
            this.jsonFileStart_btn.Location = new System.Drawing.Point(10, 110);
            this.jsonFileStart_btn.Name = "jsonFileStart_btn";
            this.jsonFileStart_btn.Size = new System.Drawing.Size(259, 89);
            this.jsonFileStart_btn.TabIndex = 9;
            this.jsonFileStart_btn.Text = "Start";
            this.jsonFileStart_btn.UseVisualStyleBackColor = true;
            this.jsonFileStart_btn.Click += new System.EventHandler(this.JsonFileStart_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bulk Load Tool";
            this.tabControl1.ResumeLayout(false);
            this.testData_tab.ResumeLayout(false);
            this.testData_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.jsonFile_tab.ResumeLayout(false);
            this.jsonFile_tab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage testData_tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TabPage jsonFile_tab;
        private System.Windows.Forms.Button testDataDelete_btn;
        private System.Windows.Forms.Button testDataStart_btn;
        private System.Windows.Forms.Button jsonFileDelete_btn;
        private System.Windows.Forms.Button jsonFileStart_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button displayOpenFileDialog_btn;
        private System.Windows.Forms.TextBox jsonFilename_textBox;
    }
}

