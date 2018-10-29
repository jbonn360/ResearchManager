namespace SearchResultAggregator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalHits = new System.Windows.Forms.Label();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.lblSearches = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpbPubMedOptions = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkHumans = new System.Windows.Forms.CheckBox();
            this.chkAnimals = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUseDateFilter = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAbstract = new System.Windows.Forms.CheckBox();
            this.chkFreeFull = new System.Windows.Forms.CheckBox();
            this.chkFullText = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblUniques = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblFullText = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTitleAbs = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUnmarked = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCopyUnmarked = new System.Windows.Forms.Button();
            this.btnCopyTitleAbs = new System.Windows.Forms.Button();
            this.btnCopyFullText = new System.Windows.Forms.Button();
            this.lblCopied = new System.Windows.Forms.Label();
            this.btnMarkDuplicate = new System.Windows.Forms.Button();
            this.btnMarkDiscTitleAbs = new System.Windows.Forms.Button();
            this.btnMarkDiscFullText = new System.Windows.Forms.Button();
            this.btnUnmark = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grpbPubMedOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(772, 16);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(370, 28);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(772, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Records Hit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(772, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duplicates Found:";
            // 
            // lblTotalHits
            // 
            this.lblTotalHits.AutoSize = true;
            this.lblTotalHits.Location = new System.Drawing.Point(874, 66);
            this.lblTotalHits.Name = "lblTotalHits";
            this.lblTotalHits.Size = new System.Drawing.Size(13, 13);
            this.lblTotalHits.TabIndex = 6;
            this.lblTotalHits.Text = "0";
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.AutoSize = true;
            this.lblDuplicates.Location = new System.Drawing.Point(874, 83);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(13, 13);
            this.lblDuplicates.TabIndex = 7;
            this.lblDuplicates.Text = "0";
            // 
            // lblSearches
            // 
            this.lblSearches.AutoSize = true;
            this.lblSearches.Location = new System.Drawing.Point(874, 49);
            this.lblSearches.Name = "lblSearches";
            this.lblSearches.Size = new System.Drawing.Size(13, 13);
            this.lblSearches.TabIndex = 9;
            this.lblSearches.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(772, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Searches Found:";
            // 
            // grpbPubMedOptions
            // 
            this.grpbPubMedOptions.Controls.Add(this.groupBox3);
            this.grpbPubMedOptions.Controls.Add(this.groupBox2);
            this.grpbPubMedOptions.Controls.Add(this.groupBox1);
            this.grpbPubMedOptions.Location = new System.Drawing.Point(26, 9);
            this.grpbPubMedOptions.Name = "grpbPubMedOptions";
            this.grpbPubMedOptions.Size = new System.Drawing.Size(494, 141);
            this.grpbPubMedOptions.TabIndex = 10;
            this.grpbPubMedOptions.TabStop = false;
            this.grpbPubMedOptions.Text = "PubMed Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkHumans);
            this.groupBox3.Controls.Add(this.chkAnimals);
            this.groupBox3.Location = new System.Drawing.Point(351, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 84);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Species";
            // 
            // chkHumans
            // 
            this.chkHumans.AutoSize = true;
            this.chkHumans.Location = new System.Drawing.Point(21, 27);
            this.chkHumans.Name = "chkHumans";
            this.chkHumans.Size = new System.Drawing.Size(65, 17);
            this.chkHumans.TabIndex = 0;
            this.chkHumans.Text = "Humans";
            this.chkHumans.UseVisualStyleBackColor = true;
            // 
            // chkAnimals
            // 
            this.chkAnimals.AutoSize = true;
            this.chkAnimals.Location = new System.Drawing.Point(21, 54);
            this.chkAnimals.Name = "chkAnimals";
            this.chkAnimals.Size = new System.Drawing.Size(91, 17);
            this.chkAnimals.TabIndex = 1;
            this.chkAnimals.Text = "Other Animals";
            this.chkAnimals.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUseDateFilter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtFrom);
            this.groupBox2.Controls.Add(this.dtTo);
            this.groupBox2.Location = new System.Drawing.Point(149, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 116);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "       Publication Dates";
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.AutoSize = true;
            this.chkUseDateFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseDateFilter.Location = new System.Drawing.Point(12, 0);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(15, 14);
            this.chkUseDateFilter.TabIndex = 3;
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            this.chkUseDateFilter.CheckedChanged += new System.EventHandler(this.chkUseDateFilter_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "From:";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd /MMMM/ yyyy";
            this.dtFrom.Enabled = false;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(12, 39);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(155, 20);
            this.dtFrom.TabIndex = 11;
            this.dtFrom.Value = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd /MMMM/ yyyy";
            this.dtTo.Enabled = false;
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(12, 82);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(155, 20);
            this.dtTo.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAbstract);
            this.groupBox1.Controls.Add(this.chkFreeFull);
            this.groupBox1.Controls.Add(this.chkFullText);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 116);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Visibility";
            // 
            // chkAbstract
            // 
            this.chkAbstract.AutoSize = true;
            this.chkAbstract.Location = new System.Drawing.Point(21, 27);
            this.chkAbstract.Name = "chkAbstract";
            this.chkAbstract.Size = new System.Drawing.Size(65, 17);
            this.chkAbstract.TabIndex = 0;
            this.chkAbstract.Text = "Abstract";
            this.chkAbstract.UseVisualStyleBackColor = true;
            // 
            // chkFreeFull
            // 
            this.chkFreeFull.AutoSize = true;
            this.chkFreeFull.Location = new System.Drawing.Point(21, 54);
            this.chkFreeFull.Name = "chkFreeFull";
            this.chkFreeFull.Size = new System.Drawing.Size(90, 17);
            this.chkFreeFull.TabIndex = 1;
            this.chkFreeFull.Text = "Free Full Text";
            this.chkFreeFull.UseVisualStyleBackColor = true;
            // 
            // chkFullText
            // 
            this.chkFullText.AutoSize = true;
            this.chkFullText.Location = new System.Drawing.Point(21, 82);
            this.chkFullText.Name = "chkFullText";
            this.chkFullText.Size = new System.Drawing.Size(66, 17);
            this.chkFullText.TabIndex = 2;
            this.chkFullText.Text = "Full Text";
            this.chkFullText.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(773, 118);
            this.lblError.MaximumSize = new System.Drawing.Size(370, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(75, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Error Message";
            // 
            // lblUniques
            // 
            this.lblUniques.AutoSize = true;
            this.lblUniques.Location = new System.Drawing.Point(874, 100);
            this.lblUniques.Name = "lblUniques";
            this.lblUniques.Size = new System.Drawing.Size(13, 13);
            this.lblUniques.TabIndex = 13;
            this.lblUniques.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(773, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unique Records:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(26, 185);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1119, 487);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // title
            // 
            this.title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.title.DefaultCellStyle = dataGridViewCellStyle2;
            this.title.HeaderText = "Study Title";
            this.title.MinimumWidth = 500;
            this.title.Name = "title";
            this.title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lblFullText
            // 
            this.lblFullText.AutoSize = true;
            this.lblFullText.Location = new System.Drawing.Point(1093, 65);
            this.lblFullText.Name = "lblFullText";
            this.lblFullText.Size = new System.Drawing.Size(13, 13);
            this.lblFullText.TabIndex = 18;
            this.lblFullText.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(938, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Discarded - Full Text";
            // 
            // lblTitleAbs
            // 
            this.lblTitleAbs.AutoSize = true;
            this.lblTitleAbs.Location = new System.Drawing.Point(1093, 47);
            this.lblTitleAbs.Name = "lblTitleAbs";
            this.lblTitleAbs.Size = new System.Drawing.Size(13, 13);
            this.lblTitleAbs.TabIndex = 16;
            this.lblTitleAbs.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(938, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Discarded - Title and Abstract";
            // 
            // lblUnmarked
            // 
            this.lblUnmarked.AutoSize = true;
            this.lblUnmarked.Location = new System.Drawing.Point(1093, 82);
            this.lblUnmarked.Name = "lblUnmarked";
            this.lblUnmarked.Size = new System.Drawing.Size(13, 13);
            this.lblUnmarked.TabIndex = 20;
            this.lblUnmarked.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(938, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Unmarked Records";
            // 
            // btnCopyUnmarked
            // 
            this.btnCopyUnmarked.Location = new System.Drawing.Point(20, 27);
            this.btnCopyUnmarked.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyUnmarked.Name = "btnCopyUnmarked";
            this.btnCopyUnmarked.Size = new System.Drawing.Size(182, 20);
            this.btnCopyUnmarked.TabIndex = 21;
            this.btnCopyUnmarked.Text = "Copy Unmarked Records";
            this.btnCopyUnmarked.UseVisualStyleBackColor = true;
            this.btnCopyUnmarked.Click += new System.EventHandler(this.btnCopyUnmarked_Click);
            // 
            // btnCopyTitleAbs
            // 
            this.btnCopyTitleAbs.Location = new System.Drawing.Point(20, 54);
            this.btnCopyTitleAbs.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyTitleAbs.Name = "btnCopyTitleAbs";
            this.btnCopyTitleAbs.Size = new System.Drawing.Size(182, 20);
            this.btnCopyTitleAbs.TabIndex = 22;
            this.btnCopyTitleAbs.Text = "Copy Discarded - Title and Abstract";
            this.btnCopyTitleAbs.UseVisualStyleBackColor = true;
            this.btnCopyTitleAbs.Click += new System.EventHandler(this.btnCopyTitleAbs_Click);
            // 
            // btnCopyFullText
            // 
            this.btnCopyFullText.Location = new System.Drawing.Point(20, 81);
            this.btnCopyFullText.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyFullText.Name = "btnCopyFullText";
            this.btnCopyFullText.Size = new System.Drawing.Size(182, 20);
            this.btnCopyFullText.TabIndex = 23;
            this.btnCopyFullText.Text = "Copy Discarded - Full Text";
            this.btnCopyFullText.UseVisualStyleBackColor = true;
            this.btnCopyFullText.Click += new System.EventHandler(this.btnCopyFullText_Click);
            // 
            // lblCopied
            // 
            this.lblCopied.AutoSize = true;
            this.lblCopied.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCopied.Location = new System.Drawing.Point(21, 107);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(50, 13);
            this.lblCopied.TabIndex = 24;
            this.lblCopied.Text = "Message";
            // 
            // btnMarkDuplicate
            // 
            this.btnMarkDuplicate.BackColor = System.Drawing.Color.Red;
            this.btnMarkDuplicate.Enabled = false;
            this.btnMarkDuplicate.Location = new System.Drawing.Point(26, 155);
            this.btnMarkDuplicate.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkDuplicate.Name = "btnMarkDuplicate";
            this.btnMarkDuplicate.Size = new System.Drawing.Size(189, 25);
            this.btnMarkDuplicate.TabIndex = 25;
            this.btnMarkDuplicate.Text = "Mark Duplicate";
            this.btnMarkDuplicate.UseVisualStyleBackColor = false;
            this.btnMarkDuplicate.Click += new System.EventHandler(this.btnMarkDuplicate_Click);
            // 
            // btnMarkDiscTitleAbs
            // 
            this.btnMarkDiscTitleAbs.BackColor = System.Drawing.Color.LightBlue;
            this.btnMarkDiscTitleAbs.Enabled = false;
            this.btnMarkDiscTitleAbs.Location = new System.Drawing.Point(225, 155);
            this.btnMarkDiscTitleAbs.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkDiscTitleAbs.Name = "btnMarkDiscTitleAbs";
            this.btnMarkDiscTitleAbs.Size = new System.Drawing.Size(189, 25);
            this.btnMarkDiscTitleAbs.TabIndex = 26;
            this.btnMarkDiscTitleAbs.Text = "Mark Discarded - Title and Abstract";
            this.btnMarkDiscTitleAbs.UseVisualStyleBackColor = false;
            this.btnMarkDiscTitleAbs.Click += new System.EventHandler(this.btnMarkDiscTitleAbs_Click);
            // 
            // btnMarkDiscFullText
            // 
            this.btnMarkDiscFullText.BackColor = System.Drawing.Color.LightGreen;
            this.btnMarkDiscFullText.Enabled = false;
            this.btnMarkDiscFullText.Location = new System.Drawing.Point(427, 155);
            this.btnMarkDiscFullText.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkDiscFullText.Name = "btnMarkDiscFullText";
            this.btnMarkDiscFullText.Size = new System.Drawing.Size(189, 25);
            this.btnMarkDiscFullText.TabIndex = 27;
            this.btnMarkDiscFullText.Text = "Mark Discarded - Full Text";
            this.btnMarkDiscFullText.UseVisualStyleBackColor = false;
            this.btnMarkDiscFullText.Click += new System.EventHandler(this.btnMarkDiscFullText_Click);
            // 
            // btnUnmark
            // 
            this.btnUnmark.BackColor = System.Drawing.Color.White;
            this.btnUnmark.Enabled = false;
            this.btnUnmark.Location = new System.Drawing.Point(633, 155);
            this.btnUnmark.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnmark.Name = "btnUnmark";
            this.btnUnmark.Size = new System.Drawing.Size(124, 25);
            this.btnUnmark.TabIndex = 28;
            this.btnUnmark.Text = "Unmark";
            this.btnUnmark.UseVisualStyleBackColor = false;
            this.btnUnmark.Click += new System.EventHandler(this.btnUnmark_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCopyUnmarked);
            this.groupBox4.Controls.Add(this.btnCopyTitleAbs);
            this.groupBox4.Controls.Add(this.btnCopyFullText);
            this.groupBox4.Controls.Add(this.lblCopied);
            this.groupBox4.Location = new System.Drawing.Point(536, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 141);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Copy Records to Clipboard";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 684);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnUnmark);
            this.Controls.Add(this.btnMarkDiscFullText);
            this.Controls.Add(this.btnMarkDiscTitleAbs);
            this.Controls.Add(this.btnMarkDuplicate);
            this.Controls.Add(this.lblUnmarked);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFullText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTitleAbs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblUniques);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grpbPubMedOptions);
            this.Controls.Add(this.lblSearches);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDuplicates);
            this.Controls.Add(this.lblTotalHits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Search Result Aggregator";
            this.grpbPubMedOptions.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTotalHits;
        private System.Windows.Forms.Label lblDuplicates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSearches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpbPubMedOptions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkHumans;
        private System.Windows.Forms.CheckBox chkAnimals;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAbstract;
        private System.Windows.Forms.CheckBox chkFreeFull;
        private System.Windows.Forms.CheckBox chkFullText;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkUseDateFilter;
        private System.Windows.Forms.Label lblUniques;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFullText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTitleAbs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUnmarked;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCopyUnmarked;
        private System.Windows.Forms.Button btnCopyTitleAbs;
        private System.Windows.Forms.Button btnCopyFullText;
        private System.Windows.Forms.Label lblCopied;
        private System.Windows.Forms.Button btnMarkDuplicate;
        private System.Windows.Forms.Button btnMarkDiscTitleAbs;
        private System.Windows.Forms.Button btnMarkDiscFullText;
        private System.Windows.Forms.DataGridViewLinkColumn title;
        private System.Windows.Forms.Button btnUnmark;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

