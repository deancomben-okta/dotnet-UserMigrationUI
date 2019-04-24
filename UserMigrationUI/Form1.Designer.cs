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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.testData_tab = new System.Windows.Forms.TabPage();
            this.testDataStop_btn = new System.Windows.Forms.Button();
            this.testDataDelete_btn = new System.Windows.Forms.Button();
            this.testDataStart_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.jsonFile_tab = new System.Windows.Forms.TabPage();
            this.jsonFileStop_btn = new System.Windows.Forms.Button();
            this.displayOpenFileDialog_btn = new System.Windows.Forms.Button();
            this.jsonFilename_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jsonFileDelete_btn = new System.Windows.Forms.Button();
            this.jsonFileStart_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progress_Lbl = new System.Windows.Forms.Label();
            this.etc_Lbl = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBoxSuccess = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtBoxFailure = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.oktaOrgURL_txtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.oktaAPIKey_txtBox = new System.Windows.Forms.TextBox();
            this.numThreads_upDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.testData_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.jsonFile_tab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads_upDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.testData_tab);
            this.tabControl1.Controls.Add(this.jsonFile_tab);
            this.tabControl1.Location = new System.Drawing.Point(8, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 251);
            this.tabControl1.TabIndex = 5;
            // 
            // testData_tab
            // 
            this.testData_tab.Controls.Add(this.testDataStop_btn);
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
            // testDataStop_btn
            // 
            this.testDataStop_btn.Enabled = false;
            this.testDataStop_btn.Location = new System.Drawing.Point(300, 110);
            this.testDataStop_btn.Name = "testDataStop_btn";
            this.testDataStop_btn.Size = new System.Drawing.Size(212, 89);
            this.testDataStop_btn.TabIndex = 9;
            this.testDataStop_btn.Text = "Stop";
            this.testDataStop_btn.UseVisualStyleBackColor = true;
            this.testDataStop_btn.Click += new System.EventHandler(this.TestDataStop_btn_Click);
            // 
            // testDataDelete_btn
            // 
            this.testDataDelete_btn.Location = new System.Drawing.Point(540, 110);
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
            this.testDataStart_btn.Text = "Create";
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
            this.jsonFile_tab.Controls.Add(this.jsonFileStop_btn);
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
            // jsonFileStop_btn
            // 
            this.jsonFileStop_btn.Enabled = false;
            this.jsonFileStop_btn.Location = new System.Drawing.Point(300, 110);
            this.jsonFileStop_btn.Name = "jsonFileStop_btn";
            this.jsonFileStop_btn.Size = new System.Drawing.Size(212, 89);
            this.jsonFileStop_btn.TabIndex = 14;
            this.jsonFileStop_btn.Text = "Stop";
            this.jsonFileStop_btn.UseVisualStyleBackColor = true;
            this.jsonFileStop_btn.Click += new System.EventHandler(this.JsonFileStop_btn_Click);
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
            this.jsonFileDelete_btn.Location = new System.Drawing.Point(540, 110);
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
            this.jsonFileStart_btn.Text = "Create";
            this.jsonFileStart_btn.UseVisualStyleBackColor = true;
            this.jsonFileStart_btn.Click += new System.EventHandler(this.JsonFileStart_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 403);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // progress_Lbl
            // 
            this.progress_Lbl.Location = new System.Drawing.Point(12, 366);
            this.progress_Lbl.Name = "progress_Lbl";
            this.progress_Lbl.Size = new System.Drawing.Size(379, 23);
            this.progress_Lbl.TabIndex = 7;
            // 
            // etc_Lbl
            // 
            this.etc_Lbl.Location = new System.Drawing.Point(397, 366);
            this.etc_Lbl.Name = "etc_Lbl";
            this.etc_Lbl.Size = new System.Drawing.Size(391, 23);
            this.etc_Lbl.TabIndex = 8;
            this.etc_Lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(8, 436);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(776, 169);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBoxSuccess);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 143);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Success";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxSuccess
            // 
            this.txtBoxSuccess.Location = new System.Drawing.Point(3, 3);
            this.txtBoxSuccess.Multiline = true;
            this.txtBoxSuccess.Name = "txtBoxSuccess";
            this.txtBoxSuccess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxSuccess.Size = new System.Drawing.Size(759, 134);
            this.txtBoxSuccess.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtBoxFailure);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 143);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Failure";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtBoxFailure
            // 
            this.txtBoxFailure.Location = new System.Drawing.Point(5, 4);
            this.txtBoxFailure.Multiline = true;
            this.txtBoxFailure.Name = "txtBoxFailure";
            this.txtBoxFailure.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxFailure.Size = new System.Drawing.Size(759, 134);
            this.txtBoxFailure.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Okta Org URL";
            // 
            // oktaOrgURL_txtBox
            // 
            this.oktaOrgURL_txtBox.Location = new System.Drawing.Point(132, 6);
            this.oktaOrgURL_txtBox.Name = "oktaOrgURL_txtBox";
            this.oktaOrgURL_txtBox.Size = new System.Drawing.Size(652, 20);
            this.oktaOrgURL_txtBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Okta API Key";
            // 
            // oktaAPIKey_txtBox
            // 
            this.oktaAPIKey_txtBox.Location = new System.Drawing.Point(132, 36);
            this.oktaAPIKey_txtBox.Name = "oktaAPIKey_txtBox";
            this.oktaAPIKey_txtBox.Size = new System.Drawing.Size(652, 20);
            this.oktaAPIKey_txtBox.TabIndex = 13;
            // 
            // numThreads_upDown
            // 
            this.numThreads_upDown.Location = new System.Drawing.Point(132, 62);
            this.numThreads_upDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numThreads_upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads_upDown.Name = "numThreads_upDown";
            this.numThreads_upDown.Size = new System.Drawing.Size(120, 20);
            this.numThreads_upDown.TabIndex = 14;
            this.numThreads_upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Number of Threads";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numThreads_upDown);
            this.Controls.Add(this.oktaAPIKey_txtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.oktaOrgURL_txtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.etc_Lbl);
            this.Controls.Add(this.progress_Lbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bulk Load Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.testData_tab.ResumeLayout(false);
            this.testData_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.jsonFile_tab.ResumeLayout(false);
            this.jsonFile_tab.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads_upDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button testDataStop_btn;
        private System.Windows.Forms.Button jsonFileStop_btn;
        private System.Windows.Forms.Label progress_Lbl;
        private System.Windows.Forms.Label etc_Lbl;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBoxSuccess;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtBoxFailure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oktaOrgURL_txtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox oktaAPIKey_txtBox;
        private System.Windows.Forms.NumericUpDown numThreads_upDown;
        private System.Windows.Forms.Label label5;
    }
}

