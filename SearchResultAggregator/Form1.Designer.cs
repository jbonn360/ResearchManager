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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.grpbPubMedOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(700, 17);
            this.btnGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(565, 34);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(701, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Records Hit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(877, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duplicates Found:";
            // 
            // lblTotalHits
            // 
            this.lblTotalHits.AutoSize = true;
            this.lblTotalHits.Location = new System.Drawing.Point(837, 87);
            this.lblTotalHits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalHits.Name = "lblTotalHits";
            this.lblTotalHits.Size = new System.Drawing.Size(16, 17);
            this.lblTotalHits.TabIndex = 6;
            this.lblTotalHits.Text = "0";
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.AutoSize = true;
            this.lblDuplicates.Location = new System.Drawing.Point(1003, 65);
            this.lblDuplicates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(16, 17);
            this.lblDuplicates.TabIndex = 7;
            this.lblDuplicates.Text = "0";
            // 
            // lblSearches
            // 
            this.lblSearches.AutoSize = true;
            this.lblSearches.Location = new System.Drawing.Point(837, 65);
            this.lblSearches.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearches.Name = "lblSearches";
            this.lblSearches.Size = new System.Drawing.Size(16, 17);
            this.lblSearches.TabIndex = 9;
            this.lblSearches.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(701, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Searches Found:";
            // 
            // grpbPubMedOptions
            // 
            this.grpbPubMedOptions.Controls.Add(this.groupBox3);
            this.grpbPubMedOptions.Controls.Add(this.groupBox2);
            this.grpbPubMedOptions.Controls.Add(this.groupBox1);
            this.grpbPubMedOptions.Location = new System.Drawing.Point(35, 11);
            this.grpbPubMedOptions.Margin = new System.Windows.Forms.Padding(4);
            this.grpbPubMedOptions.Name = "grpbPubMedOptions";
            this.grpbPubMedOptions.Padding = new System.Windows.Forms.Padding(4);
            this.grpbPubMedOptions.Size = new System.Drawing.Size(659, 174);
            this.grpbPubMedOptions.TabIndex = 10;
            this.grpbPubMedOptions.TabStop = false;
            this.grpbPubMedOptions.Text = "PubMed Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkHumans);
            this.groupBox3.Controls.Add(this.chkAnimals);
            this.groupBox3.Location = new System.Drawing.Point(468, 20);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(159, 103);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Species";
            // 
            // chkHumans
            // 
            this.chkHumans.AutoSize = true;
            this.chkHumans.Location = new System.Drawing.Point(28, 33);
            this.chkHumans.Margin = new System.Windows.Forms.Padding(4);
            this.chkHumans.Name = "chkHumans";
            this.chkHumans.Size = new System.Drawing.Size(82, 21);
            this.chkHumans.TabIndex = 0;
            this.chkHumans.Text = "Humans";
            this.chkHumans.UseVisualStyleBackColor = true;
            // 
            // chkAnimals
            // 
            this.chkAnimals.AutoSize = true;
            this.chkAnimals.Location = new System.Drawing.Point(28, 66);
            this.chkAnimals.Margin = new System.Windows.Forms.Padding(4);
            this.chkAnimals.Name = "chkAnimals";
            this.chkAnimals.Size = new System.Drawing.Size(119, 21);
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
            this.groupBox2.Location = new System.Drawing.Point(199, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(249, 143);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "       Publication Dates";
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.AutoSize = true;
            this.chkUseDateFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseDateFilter.Location = new System.Drawing.Point(16, 0);
            this.chkUseDateFilter.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(18, 17);
            this.chkUseDateFilter.TabIndex = 3;
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            this.chkUseDateFilter.CheckedChanged += new System.EventHandler(this.chkUseDateFilter_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "From:";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd /MMMM/ yyyy";
            this.dtFrom.Enabled = false;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(16, 48);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(205, 22);
            this.dtFrom.TabIndex = 11;
            this.dtFrom.Value = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd /MMMM/ yyyy";
            this.dtTo.Enabled = false;
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(16, 101);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(205, 22);
            this.dtTo.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAbstract);
            this.groupBox1.Controls.Add(this.chkFreeFull);
            this.groupBox1.Controls.Add(this.chkFullText);
            this.groupBox1.Location = new System.Drawing.Point(21, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(159, 143);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Visibility";
            // 
            // chkAbstract
            // 
            this.chkAbstract.AutoSize = true;
            this.chkAbstract.Location = new System.Drawing.Point(28, 33);
            this.chkAbstract.Margin = new System.Windows.Forms.Padding(4);
            this.chkAbstract.Name = "chkAbstract";
            this.chkAbstract.Size = new System.Drawing.Size(82, 21);
            this.chkAbstract.TabIndex = 0;
            this.chkAbstract.Text = "Abstract";
            this.chkAbstract.UseVisualStyleBackColor = true;
            // 
            // chkFreeFull
            // 
            this.chkFreeFull.AutoSize = true;
            this.chkFreeFull.Location = new System.Drawing.Point(28, 66);
            this.chkFreeFull.Margin = new System.Windows.Forms.Padding(4);
            this.chkFreeFull.Name = "chkFreeFull";
            this.chkFreeFull.Size = new System.Drawing.Size(116, 21);
            this.chkFreeFull.TabIndex = 1;
            this.chkFreeFull.Text = "Free Full Text";
            this.chkFreeFull.UseVisualStyleBackColor = true;
            // 
            // chkFullText
            // 
            this.chkFullText.AutoSize = true;
            this.chkFullText.Location = new System.Drawing.Point(28, 101);
            this.chkFullText.Margin = new System.Windows.Forms.Padding(4);
            this.chkFullText.Name = "chkFullText";
            this.chkFullText.Size = new System.Drawing.Size(83, 21);
            this.chkFullText.TabIndex = 2;
            this.chkFullText.Text = "Full Text";
            this.chkFullText.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(877, 112);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(101, 17);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Error Message";
            // 
            // lblUniques
            // 
            this.lblUniques.AutoSize = true;
            this.lblUniques.Location = new System.Drawing.Point(1003, 87);
            this.lblUniques.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUniques.Name = "lblUniques";
            this.lblUniques.Size = new System.Drawing.Size(16, 17);
            this.lblUniques.TabIndex = 13;
            this.lblUniques.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(877, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(35, 228);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1233, 599);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // title
            // 
            this.title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.title.DefaultCellStyle = dataGridViewCellStyle5;
            this.title.HeaderText = "Study Title";
            this.title.MinimumWidth = 500;
            this.title.Name = "title";
            this.title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // lblFullText
            // 
            this.lblFullText.AutoSize = true;
            this.lblFullText.Location = new System.Drawing.Point(1248, 87);
            this.lblFullText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullText.Name = "lblFullText";
            this.lblFullText.Size = new System.Drawing.Size(16, 17);
            this.lblFullText.TabIndex = 18;
            this.lblFullText.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1049, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Discarded - Full Text";
            // 
            // lblTitleAbs
            // 
            this.lblTitleAbs.AutoSize = true;
            this.lblTitleAbs.Location = new System.Drawing.Point(1248, 65);
            this.lblTitleAbs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleAbs.Name = "lblTitleAbs";
            this.lblTitleAbs.Size = new System.Drawing.Size(16, 17);
            this.lblTitleAbs.TabIndex = 16;
            this.lblTitleAbs.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1049, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Discarded - Title and Abstract";
            // 
            // lblUnmarked
            // 
            this.lblUnmarked.AutoSize = true;
            this.lblUnmarked.Location = new System.Drawing.Point(837, 111);
            this.lblUnmarked.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnmarked.Name = "lblUnmarked";
            this.lblUnmarked.Size = new System.Drawing.Size(16, 17);
            this.lblUnmarked.TabIndex = 20;
            this.lblUnmarked.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(701, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Unmarked Records";
            // 
            // btnCopyUnmarked
            // 
            this.btnCopyUnmarked.Location = new System.Drawing.Point(1075, 139);
            this.btnCopyUnmarked.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopyUnmarked.Name = "btnCopyUnmarked";
            this.btnCopyUnmarked.Size = new System.Drawing.Size(189, 25);
            this.btnCopyUnmarked.TabIndex = 21;
            this.btnCopyUnmarked.Text = "Copy Unmarked Records";
            this.btnCopyUnmarked.UseVisualStyleBackColor = true;
            this.btnCopyUnmarked.Click += new System.EventHandler(this.btnCopyUnmarked_Click);
            // 
            // btnCopyTitleAbs
            // 
            this.btnCopyTitleAbs.Location = new System.Drawing.Point(1022, 168);
            this.btnCopyTitleAbs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopyTitleAbs.Name = "btnCopyTitleAbs";
            this.btnCopyTitleAbs.Size = new System.Drawing.Size(242, 25);
            this.btnCopyTitleAbs.TabIndex = 22;
            this.btnCopyTitleAbs.Text = "Copy Discarded - Title and Abstract";
            this.btnCopyTitleAbs.UseVisualStyleBackColor = true;
            this.btnCopyTitleAbs.Click += new System.EventHandler(this.btnCopyTitleAbs_Click);
            // 
            // btnCopyFullText
            // 
            this.btnCopyFullText.Location = new System.Drawing.Point(1082, 197);
            this.btnCopyFullText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopyFullText.Name = "btnCopyFullText";
            this.btnCopyFullText.Size = new System.Drawing.Size(182, 25);
            this.btnCopyFullText.TabIndex = 23;
            this.btnCopyFullText.Text = "Copy Discarded - Full Text";
            this.btnCopyFullText.UseVisualStyleBackColor = true;
            this.btnCopyFullText.Click += new System.EventHandler(this.btnCopyFullText_Click);
            // 
            // lblCopied
            // 
            this.lblCopied.AutoSize = true;
            this.lblCopied.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCopied.Location = new System.Drawing.Point(862, 176);
            this.lblCopied.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(65, 17);
            this.lblCopied.TabIndex = 24;
            this.lblCopied.Text = "Message";
            // 
            // btnMarkDuplicate
            // 
            this.btnMarkDuplicate.BackColor = System.Drawing.Color.Red;
            this.btnMarkDuplicate.Location = new System.Drawing.Point(35, 197);
            this.btnMarkDuplicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.btnMarkDiscTitleAbs.Location = new System.Drawing.Point(249, 197);
            this.btnMarkDiscTitleAbs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMarkDiscTitleAbs.Name = "btnMarkDiscTitleAbs";
            this.btnMarkDiscTitleAbs.Size = new System.Drawing.Size(248, 25);
            this.btnMarkDiscTitleAbs.TabIndex = 26;
            this.btnMarkDiscTitleAbs.Text = "Mark Discarded - Title and Abstract";
            this.btnMarkDiscTitleAbs.UseVisualStyleBackColor = false;
            this.btnMarkDiscTitleAbs.Click += new System.EventHandler(this.btnMarkDiscTitleAbs_Click);
            // 
            // btnMarkDiscFullText
            // 
            this.btnMarkDiscFullText.BackColor = System.Drawing.Color.LightGreen;
            this.btnMarkDiscFullText.Location = new System.Drawing.Point(516, 197);
            this.btnMarkDiscFullText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMarkDiscFullText.Name = "btnMarkDiscFullText";
            this.btnMarkDiscFullText.Size = new System.Drawing.Size(189, 25);
            this.btnMarkDiscFullText.TabIndex = 27;
            this.btnMarkDiscFullText.Text = "Mark Discarded - Full Text";
            this.btnMarkDiscFullText.UseVisualStyleBackColor = false;
            this.btnMarkDiscFullText.Click += new System.EventHandler(this.btnMarkDiscFullText_Click);
            // 
            // btnUnmark
            // 
            this.btnUnmark.Location = new System.Drawing.Point(726, 197);
            this.btnUnmark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnmark.Name = "btnUnmark";
            this.btnUnmark.Size = new System.Drawing.Size(189, 25);
            this.btnUnmark.TabIndex = 28;
            this.btnUnmark.Text = "Unmark";
            this.btnUnmark.UseVisualStyleBackColor = true;
            this.btnUnmark.Click += new System.EventHandler(this.btnUnmark_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 842);
            this.Controls.Add(this.btnUnmark);
            this.Controls.Add(this.btnMarkDiscFullText);
            this.Controls.Add(this.btnMarkDiscTitleAbs);
            this.Controls.Add(this.btnMarkDuplicate);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.btnCopyFullText);
            this.Controls.Add(this.btnCopyTitleAbs);
            this.Controls.Add(this.btnCopyUnmarked);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Search Result Aggregator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpbPubMedOptions.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}

