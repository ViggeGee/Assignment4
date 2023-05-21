namespace Assignment4_CS_GUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.rtxtSource = new System.Windows.Forms.RichTextBox();
            this.rtxtDest = new System.Windows.Forms.RichTextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(24, 11);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(124, 49);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Replace";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(230, 10);
            this.txtFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(452, 23);
            this.txtFind.TabIndex = 3;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(228, 37);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(454, 23);
            this.txtReplace.TabIndex = 4;
            // 
            // rtxtSource
            // 
            this.rtxtSource.Location = new System.Drawing.Point(9, 20);
            this.rtxtSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtSource.Name = "rtxtSource";
            this.rtxtSource.Size = new System.Drawing.Size(374, 203);
            this.rtxtSource.TabIndex = 5;
            this.rtxtSource.Text = "";
            // 
            // rtxtDest
            // 
            this.rtxtDest.Location = new System.Drawing.Point(389, 20);
            this.rtxtDest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtDest.Name = "rtxtDest";
            this.rtxtDest.Size = new System.Drawing.Size(374, 203);
            this.rtxtDest.TabIndex = 5;
            this.rtxtDest.Text = "";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(24, 71);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(49, 15);
            this.lblSource.TabIndex = 6;
            this.lblSource.Text = "Source: ";
            // 
            // lstStatus
            // 
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.ItemHeight = 15;
            this.lstStatus.Location = new System.Drawing.Point(14, 29);
            this.lstStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(769, 214);
            this.lstStatus.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtDest);
            this.groupBox1.Controls.Add(this.rtxtSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(787, 237);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  Editor  ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstStatus);
            this.groupBox2.Location = new System.Drawing.Point(4, 350);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(798, 192);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logbook";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOk
            // 
            this.btnOk.CausesValidation = false;
            this.btnOk.Location = new System.Drawing.Point(688, 13);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 47);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 530);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnLoadFile;
        private Label label1;
        private Label label2;
        private TextBox txtFind;
        private TextBox txtReplace;
        private RichTextBox rtxtSource;
        private RichTextBox rtxtDest;
        private Label lblSource;
        private ListBox lstStatus;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private OpenFileDialog openFileDialog1;
        private Button btnOk;
        private ToolTip toolTip1;
        private SaveFileDialog saveFileDialog1;
    }
}