namespace PayBitForwardGui
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addSeedButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.seedBrowseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.seederDataGridView = new System.Windows.Forms.DataGridView();
            this.contentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.downloadButton = new System.Windows.Forms.Button();
            this.saveTextBox = new System.Windows.Forms.TextBox();
            this.searchBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchDataGridView = new System.Windows.Forms.DataGridView();
            this.contentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.contentListRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byteSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentHashDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentHashDataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byteSizeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seederDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentBindingSource1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentListRequestBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.seederDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Torrents";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.addSeedButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.seedBrowseButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.seedTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 115);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add a Seed";
            // 
            // addSeedButton
            // 
            this.addSeedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSeedButton.BackColor = System.Drawing.Color.LimeGreen;
            this.addSeedButton.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.addSeedButton.FlatAppearance.BorderSize = 0;
            this.addSeedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            this.addSeedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.addSeedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSeedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSeedButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addSeedButton.Location = new System.Drawing.Point(762, 67);
            this.addSeedButton.Name = "addSeedButton";
            this.addSeedButton.Size = new System.Drawing.Size(75, 24);
            this.addSeedButton.TabIndex = 6;
            this.addSeedButton.Text = "Add Seed";
            this.addSeedButton.UseVisualStyleBackColor = false;
            this.addSeedButton.Click += new System.EventHandler(this.addSeedButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(75, 69);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(681, 20);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // seedBrowseButton
            // 
            this.seedBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.seedBrowseButton.Location = new System.Drawing.Point(762, 31);
            this.seedBrowseButton.Name = "seedBrowseButton";
            this.seedBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.seedBrowseButton.TabIndex = 5;
            this.seedBrowseButton.Text = "Browse";
            this.seedBrowseButton.UseVisualStyleBackColor = true;
            this.seedBrowseButton.Click += new System.EventHandler(this.seedBrowseButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "File:";
            // 
            // seedTextBox
            // 
            this.seedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seedTextBox.Location = new System.Drawing.Point(47, 32);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(709, 20);
            this.seedTextBox.TabIndex = 3;
            // 
            // seederDataGridView
            // 
            this.seederDataGridView.AllowUserToAddRows = false;
            this.seederDataGridView.AllowUserToDeleteRows = false;
            this.seederDataGridView.AllowUserToOrderColumns = true;
            this.seederDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seederDataGridView.AutoGenerateColumns = false;
            this.seederDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.seederDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seederDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn1,
            this.localPathDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.contentHashDataGridViewImageColumn1,
            this.byteSizeDataGridViewTextBoxColumn1});
            this.seederDataGridView.DataSource = this.contentBindingSource1;
            this.seederDataGridView.Location = new System.Drawing.Point(6, 6);
            this.seederDataGridView.Name = "seederDataGridView";
            this.seederDataGridView.ReadOnly = true;
            this.seederDataGridView.RowHeadersVisible = false;
            this.seederDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.seederDataGridView.Size = new System.Drawing.Size(843, 305);
            this.seederDataGridView.TabIndex = 0;
            // 
            // contentBindingSource1
            // 
            this.contentBindingSource1.DataSource = typeof(PayBitForward.Models.Content);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.downloadButton);
            this.tabPage2.Controls.Add(this.saveTextBox);
            this.tabPage2.Controls.Add(this.searchBrowseButton);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.searchDataGridView);
            this.tabPage2.Controls.Add(this.searchButton);
            this.tabPage2.Controls.Add(this.searchTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(762, 406);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 24);
            this.downloadButton.TabIndex = 7;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // saveTextBox
            // 
            this.saveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTextBox.Location = new System.Drawing.Point(67, 408);
            this.saveTextBox.Name = "saveTextBox";
            this.saveTextBox.Size = new System.Drawing.Size(608, 20);
            this.saveTextBox.TabIndex = 6;
            // 
            // searchBrowseButton
            // 
            this.searchBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBrowseButton.Location = new System.Drawing.Point(681, 406);
            this.searchBrowseButton.Name = "searchBrowseButton";
            this.searchBrowseButton.Size = new System.Drawing.Size(75, 24);
            this.searchBrowseButton.TabIndex = 5;
            this.searchBrowseButton.Text = "Browse";
            this.searchBrowseButton.UseVisualStyleBackColor = true;
            this.searchBrowseButton.Click += new System.EventHandler(this.searchBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Save to:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // searchDataGridView
            // 
            this.searchDataGridView.AllowUserToAddRows = false;
            this.searchDataGridView.AllowUserToDeleteRows = false;
            this.searchDataGridView.AllowUserToOrderColumns = true;
            this.searchDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDataGridView.AutoGenerateColumns = false;
            this.searchDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.byteSizeDataGridViewTextBoxColumn,
            this.localPathDataGridViewTextBoxColumn,
            this.contentHashDataGridViewImageColumn});
            this.searchDataGridView.DataSource = this.contentBindingSource;
            this.searchDataGridView.Location = new System.Drawing.Point(21, 51);
            this.searchDataGridView.Name = "searchDataGridView";
            this.searchDataGridView.ReadOnly = true;
            this.searchDataGridView.RowHeadersVisible = false;
            this.searchDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchDataGridView.Size = new System.Drawing.Size(816, 350);
            this.searchDataGridView.TabIndex = 2;
            // 
            // contentBindingSource
            // 
            this.contentBindingSource.DataSource = typeof(PayBitForward.Models.Content);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(762, 17);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 22);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(67, 18);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(689, 20);
            this.searchTextBox.TabIndex = 0;
            // 
            // contentListRequestBindingSource
            // 
            this.contentListRequestBindingSource.DataSource = typeof(PayBitForward.Messaging.ContentListRequest);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // byteSizeDataGridViewTextBoxColumn
            // 
            this.byteSizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.byteSizeDataGridViewTextBoxColumn.DataPropertyName = "ByteSize";
            this.byteSizeDataGridViewTextBoxColumn.HeaderText = "ByteSize";
            this.byteSizeDataGridViewTextBoxColumn.Name = "byteSizeDataGridViewTextBoxColumn";
            this.byteSizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.byteSizeDataGridViewTextBoxColumn.Width = 73;
            // 
            // localPathDataGridViewTextBoxColumn
            // 
            this.localPathDataGridViewTextBoxColumn.DataPropertyName = "LocalPath";
            this.localPathDataGridViewTextBoxColumn.HeaderText = "LocalPath";
            this.localPathDataGridViewTextBoxColumn.Name = "localPathDataGridViewTextBoxColumn";
            this.localPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.localPathDataGridViewTextBoxColumn.Visible = false;
            // 
            // contentHashDataGridViewImageColumn
            // 
            this.contentHashDataGridViewImageColumn.DataPropertyName = "ContentHash";
            this.contentHashDataGridViewImageColumn.HeaderText = "ContentHash";
            this.contentHashDataGridViewImageColumn.Name = "contentHashDataGridViewImageColumn";
            this.contentHashDataGridViewImageColumn.ReadOnly = true;
            this.contentHashDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.contentHashDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contentHashDataGridViewImageColumn.Visible = false;
            // 
            // fileNameDataGridViewTextBoxColumn1
            // 
            this.fileNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameDataGridViewTextBoxColumn1.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn1.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn1.Name = "fileNameDataGridViewTextBoxColumn1";
            this.fileNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // localPathDataGridViewTextBoxColumn1
            // 
            this.localPathDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.localPathDataGridViewTextBoxColumn1.DataPropertyName = "LocalPath";
            this.localPathDataGridViewTextBoxColumn1.HeaderText = "LocalPath";
            this.localPathDataGridViewTextBoxColumn1.Name = "localPathDataGridViewTextBoxColumn1";
            this.localPathDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // contentHashDataGridViewImageColumn1
            // 
            this.contentHashDataGridViewImageColumn1.DataPropertyName = "ContentHash";
            this.contentHashDataGridViewImageColumn1.HeaderText = "ContentHash";
            this.contentHashDataGridViewImageColumn1.Name = "contentHashDataGridViewImageColumn1";
            this.contentHashDataGridViewImageColumn1.ReadOnly = true;
            this.contentHashDataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.contentHashDataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contentHashDataGridViewImageColumn1.Visible = false;
            // 
            // byteSizeDataGridViewTextBoxColumn1
            // 
            this.byteSizeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.byteSizeDataGridViewTextBoxColumn1.DataPropertyName = "ByteSize";
            this.byteSizeDataGridViewTextBoxColumn1.HeaderText = "ByteSize";
            this.byteSizeDataGridViewTextBoxColumn1.Name = "byteSizeDataGridViewTextBoxColumn1";
            this.byteSizeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.byteSizeDataGridViewTextBoxColumn1.Width = 73;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 488);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Pay Bit Forward";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seederDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentBindingSource1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentListRequestBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView searchDataGridView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox saveTextBox;
        private System.Windows.Forms.Button searchBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource contentListRequestBindingSource;
        private System.Windows.Forms.BindingSource contentBindingSource;
        private System.Windows.Forms.DataGridView seederDataGridView;
        private System.Windows.Forms.BindingSource contentBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addSeedButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button seedBrowseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentHashDataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn byteSizeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byteSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentHashDataGridViewImageColumn;
    }
}

