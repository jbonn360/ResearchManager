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
            this.btnGo = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalHits = new System.Windows.Forms.Label();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.lblSearches = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpbPubMedOptions = new System.Windows.Forms.GroupBox();
            this.chkAbstract = new System.Windows.Forms.CheckBox();
            this.chkFreeFull = new System.Windows.Forms.CheckBox();
            this.chkFullText = new System.Windows.Forms.CheckBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkHumans = new System.Windows.Forms.CheckBox();
            this.chkAnimals = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.chkUseDateFilter = new System.Windows.Forms.CheckBox();
            this.grpbPubMedOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(570, 11);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(277, 28);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(26, 155);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(821, 462);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Records Hit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Duplicates Found:";
            // 
            // lblTotalHits
            // 
            this.lblTotalHits.AutoSize = true;
            this.lblTotalHits.Location = new System.Drawing.Point(677, 47);
            this.lblTotalHits.Name = "lblTotalHits";
            this.lblTotalHits.Size = new System.Drawing.Size(13, 13);
            this.lblTotalHits.TabIndex = 6;
            this.lblTotalHits.Text = "0";
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.AutoSize = true;
            this.lblDuplicates.Location = new System.Drawing.Point(677, 67);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(13, 13);
            this.lblDuplicates.TabIndex = 7;
            this.lblDuplicates.Text = "0";
            // 
            // lblSearches
            // 
            this.lblSearches.AutoSize = true;
            this.lblSearches.Location = new System.Drawing.Point(814, 47);
            this.lblSearches.Name = "lblSearches";
            this.lblSearches.Size = new System.Drawing.Size(13, 13);
            this.lblSearches.TabIndex = 9;
            this.lblSearches.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(719, 47);
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
            this.grpbPubMedOptions.Size = new System.Drawing.Size(524, 141);
            this.grpbPubMedOptions.TabIndex = 10;
            this.grpbPubMedOptions.TabStop = false;
            this.grpbPubMedOptions.Text = "PubMed Options";
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
            // dtFrom
            // 
            this.dtFrom.Enabled = false;
            this.dtFrom.Location = new System.Drawing.Point(12, 39);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(197, 20);
            this.dtFrom.TabIndex = 11;
            this.dtFrom.Value = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.Enabled = false;
            this.dtTo.Location = new System.Drawing.Point(12, 82);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(197, 20);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUseDateFilter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtFrom);
            this.groupBox2.Controls.Add(this.dtTo);
            this.groupBox2.Location = new System.Drawing.Point(149, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 116);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Publication Dates";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "To:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkHumans);
            this.groupBox3.Controls.Add(this.chkAnimals);
            this.groupBox3.Location = new System.Drawing.Point(393, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 77);
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
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(578, 89);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(75, 13);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Error Message";
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.AutoSize = true;
            this.chkUseDateFilter.Location = new System.Drawing.Point(194, 15);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(15, 14);
            this.chkUseDateFilter.TabIndex = 3;
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            this.chkUseDateFilter.CheckedChanged += new System.EventHandler(this.chkUseDateFilter_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 626);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grpbPubMedOptions);
            this.Controls.Add(this.lblSearches);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDuplicates);
            this.Controls.Add(this.lblTotalHits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnGo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpbPubMedOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox textBox2;
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
    }
}

