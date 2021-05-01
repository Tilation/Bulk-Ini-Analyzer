using System.Windows.Forms;
using System.Windows;

namespace IniCompacter
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRoot = new System.Windows.Forms.TextBox();
            this.buttonChangeRoot = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGather = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEXT = new System.Windows.Forms.TextBox();
            this.SPLITTER = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.textBoxResultsSearch = new System.Windows.Forms.TextBox();
            this.groupBoxFoundIn = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxFoundIn = new System.Windows.Forms.ListBox();
            this.textBoxFoundInSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPLITTER)).BeginInit();
            this.SPLITTER.Panel1.SuspendLayout();
            this.SPLITTER.Panel2.SuspendLayout();
            this.SPLITTER.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxFoundIn.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SPLITTER, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxRoot, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonChangeRoot, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(568, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root:";
            // 
            // textBoxRoot
            // 
            this.textBoxRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRoot.Location = new System.Drawing.Point(60, 7);
            this.textBoxRoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRoot.Name = "textBoxRoot";
            this.textBoxRoot.Size = new System.Drawing.Size(421, 26);
            this.textBoxRoot.TabIndex = 1;
            // 
            // buttonChangeRoot
            // 
            this.buttonChangeRoot.AutoSize = true;
            this.buttonChangeRoot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeRoot.Location = new System.Drawing.Point(489, 5);
            this.buttonChangeRoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonChangeRoot.Name = "buttonChangeRoot";
            this.buttonChangeRoot.Size = new System.Drawing.Size(75, 30);
            this.buttonChangeRoot.TabIndex = 2;
            this.buttonChangeRoot.Text = "Change";
            this.buttonChangeRoot.UseVisualStyleBackColor = true;
            this.buttonChangeRoot.Click += new System.EventHandler(this.buttonChangeRoot_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.buttonGather, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxEXT, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(17, 55);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(542, 40);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonGather
            // 
            this.buttonGather.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGather.AutoSize = true;
            this.buttonGather.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGather.Location = new System.Drawing.Point(338, 5);
            this.buttonGather.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGather.Name = "buttonGather";
            this.buttonGather.Size = new System.Drawing.Size(200, 30);
            this.buttonGather.TabIndex = 2;
            this.buttonGather.Text = "Gather Unique Properties";
            this.buttonGather.UseVisualStyleBackColor = true;
            this.buttonGather.Click += new System.EventHandler(this.buttonGather_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Treat Extension as INI:";
            // 
            // textBoxEXT
            // 
            this.textBoxEXT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxEXT.Location = new System.Drawing.Point(182, 7);
            this.textBoxEXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxEXT.Name = "textBoxEXT";
            this.textBoxEXT.Size = new System.Drawing.Size(148, 26);
            this.textBoxEXT.TabIndex = 4;
            this.textBoxEXT.Text = "dat";
            // 
            // SPLITTER
            // 
            this.SPLITTER.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SPLITTER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPLITTER.Location = new System.Drawing.Point(4, 105);
            this.SPLITTER.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SPLITTER.Name = "SPLITTER";
            // 
            // SPLITTER.Panel1
            // 
            this.SPLITTER.Panel1.Controls.Add(this.groupBox1);
            // 
            // SPLITTER.Panel2
            // 
            this.SPLITTER.Panel2.Controls.Add(this.groupBoxFoundIn);
            this.tableLayoutPanel1.SetRowSpan(this.SPLITTER, 2);
            this.SPLITTER.Size = new System.Drawing.Size(568, 445);
            this.SPLITTER.SplitterDistance = 261;
            this.SPLITTER.SplitterWidth = 24;
            this.SPLITTER.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(257, 441);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unique Properties:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.listBoxResults, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBoxResultsSearch, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(249, 412);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // listBoxResults
            // 
            this.listBoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 20;
            this.listBoxResults.Location = new System.Drawing.Point(4, 41);
            this.listBoxResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(241, 366);
            this.listBoxResults.TabIndex = 1;
            this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
            // 
            // textBoxResultsSearch
            // 
            this.textBoxResultsSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResultsSearch.Location = new System.Drawing.Point(4, 5);
            this.textBoxResultsSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxResultsSearch.Name = "textBoxResultsSearch";
            this.textBoxResultsSearch.Size = new System.Drawing.Size(241, 26);
            this.textBoxResultsSearch.TabIndex = 0;
            this.textBoxResultsSearch.TextChanged += new System.EventHandler(this.textBoxResultsSearch_TextChanged);
            // 
            // groupBoxFoundIn
            // 
            this.groupBoxFoundIn.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxFoundIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFoundIn.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFoundIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFoundIn.Name = "groupBoxFoundIn";
            this.groupBoxFoundIn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFoundIn.Size = new System.Drawing.Size(279, 441);
            this.groupBoxFoundIn.TabIndex = 5;
            this.groupBoxFoundIn.TabStop = false;
            this.groupBoxFoundIn.Text = "Property Found In:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.listBoxFoundIn, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxFoundInSearch, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(271, 412);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // listBoxFoundIn
            // 
            this.listBoxFoundIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFoundIn.FormattingEnabled = true;
            this.listBoxFoundIn.ItemHeight = 20;
            this.listBoxFoundIn.Location = new System.Drawing.Point(4, 41);
            this.listBoxFoundIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxFoundIn.Name = "listBoxFoundIn";
            this.listBoxFoundIn.Size = new System.Drawing.Size(263, 366);
            this.listBoxFoundIn.TabIndex = 1;
            this.listBoxFoundIn.DoubleClick += new System.EventHandler(this.listBoxFoundIn_DoubleClick);
            // 
            // textBoxFoundInSearch
            // 
            this.textBoxFoundInSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFoundInSearch.Location = new System.Drawing.Point(4, 5);
            this.textBoxFoundInSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFoundInSearch.Name = "textBoxFoundInSearch";
            this.textBoxFoundInSearch.Size = new System.Drawing.Size(263, 26);
            this.textBoxFoundInSearch.TabIndex = 2;
            this.textBoxFoundInSearch.TextChanged += new System.EventHandler(this.textBoxFoundInSearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 555);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(592, 594);
            this.Name = "Form1";
            this.Text = "INI Property Compacter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.SPLITTER.Panel1.ResumeLayout(false);
            this.SPLITTER.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPLITTER)).EndInit();
            this.SPLITTER.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBoxFoundIn.ResumeLayout(false);
            this.groupBoxFoundIn.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRoot;
        private System.Windows.Forms.Button buttonChangeRoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonGather;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEXT;
        private System.Windows.Forms.SplitContainer SPLITTER;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxFoundIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.TextBox textBoxResultsSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListBox listBoxFoundIn;
        private System.Windows.Forms.TextBox textBoxFoundInSearch;
    }
}

