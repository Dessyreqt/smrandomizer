namespace SuperMetroidRandomizer
{
    partial class MainForm
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
            this.output = new System.Windows.Forms.TextBox();
            this.process = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.suitlessForced = new System.Windows.Forms.RadioButton();
            this.suitlessPossible = new System.Windows.Forms.RadioButton();
            this.suitlessDisabled = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.outputFilename = new System.Windows.Forms.TextBox();
            this.seed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.randomizerDifficulty = new System.Windows.Forms.ComboBox();
            this.controlsV11 = new System.Windows.Forms.Button();
            this.browseV11 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputV11 = new System.Windows.Forms.TextBox();
            this.seedV11 = new System.Windows.Forms.TextBox();
            this.createV11 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filenameV11 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.controls = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.createSpoilerLog = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(6, 102);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(514, 236);
            this.output.TabIndex = 1;
            // 
            // process
            // 
            this.process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.process.Location = new System.Drawing.Point(445, 8);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(75, 23);
            this.process.TabIndex = 2;
            this.process.Text = "Create";
            this.process.UseVisualStyleBackColor = true;
            this.process.Click += new System.EventHandler(this.process_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.suitlessForced);
            this.groupBox1.Controls.Add(this.suitlessPossible);
            this.groupBox1.Controls.Add(this.suitlessDisabled);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suitless Maridia";
            // 
            // suitlessForced
            // 
            this.suitlessForced.AutoSize = true;
            this.suitlessForced.Location = new System.Drawing.Point(7, 67);
            this.suitlessForced.Name = "suitlessForced";
            this.suitlessForced.Size = new System.Drawing.Size(58, 17);
            this.suitlessForced.TabIndex = 2;
            this.suitlessForced.TabStop = true;
            this.suitlessForced.Text = "Forced";
            this.suitlessForced.UseVisualStyleBackColor = true;
            // 
            // suitlessPossible
            // 
            this.suitlessPossible.AutoSize = true;
            this.suitlessPossible.Location = new System.Drawing.Point(7, 44);
            this.suitlessPossible.Name = "suitlessPossible";
            this.suitlessPossible.Size = new System.Drawing.Size(64, 17);
            this.suitlessPossible.TabIndex = 1;
            this.suitlessPossible.Text = "Possible";
            this.suitlessPossible.UseVisualStyleBackColor = true;
            // 
            // suitlessDisabled
            // 
            this.suitlessDisabled.AutoSize = true;
            this.suitlessDisabled.Checked = true;
            this.suitlessDisabled.Location = new System.Drawing.Point(7, 20);
            this.suitlessDisabled.Name = "suitlessDisabled";
            this.suitlessDisabled.Size = new System.Drawing.Size(66, 17);
            this.suitlessDisabled.TabIndex = 0;
            this.suitlessDisabled.TabStop = true;
            this.suitlessDisabled.Text = "Disabled";
            this.suitlessDisabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Output Filename (<seed> is replaced with file seed)";
            // 
            // outputFilename
            // 
            this.outputFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFilename.Location = new System.Drawing.Point(108, 76);
            this.outputFilename.Name = "outputFilename";
            this.outputFilename.Size = new System.Drawing.Size(381, 20);
            this.outputFilename.TabIndex = 6;
            this.outputFilename.Text = "SM Random <seed>.sfc";
            this.outputFilename.TextChanged += new System.EventHandler(this.outputFilename_TextChanged);
            this.outputFilename.Leave += new System.EventHandler(this.filename_Leave);
            // 
            // seed
            // 
            this.seed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seed.Location = new System.Drawing.Point(108, 37);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(412, 20);
            this.seed.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seed (leave blank to generate new random ROM)";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 373);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.createSpoilerLog);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.randomizerDifficulty);
            this.tabPage1.Controls.Add(this.controlsV11);
            this.tabPage1.Controls.Add(this.browseV11);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.outputV11);
            this.tabPage1.Controls.Add(this.seedV11);
            this.tabPage1.Controls.Add(this.createV11);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.filenameV11);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current Randomizer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Difficulty:";
            // 
            // randomizerDifficulty
            // 
            this.randomizerDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomizerDifficulty.FormattingEnabled = true;
            this.randomizerDifficulty.Items.AddRange(new object[] {
            "Casual",
            "Speedrunner",
            "Masochist"});
            this.randomizerDifficulty.Location = new System.Drawing.Point(64, 6);
            this.randomizerDifficulty.Name = "randomizerDifficulty";
            this.randomizerDifficulty.Size = new System.Drawing.Size(121, 21);
            this.randomizerDifficulty.TabIndex = 19;
            this.randomizerDifficulty.SelectedIndexChanged += new System.EventHandler(this.randomizerDifficulty_SelectedIndexChanged);
            // 
            // controlsV11
            // 
            this.controlsV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsV11.Location = new System.Drawing.Point(364, 17);
            this.controlsV11.Name = "controlsV11";
            this.controlsV11.Size = new System.Drawing.Size(75, 23);
            this.controlsV11.TabIndex = 18;
            this.controlsV11.Text = "Controls";
            this.controlsV11.UseVisualStyleBackColor = true;
            this.controlsV11.Click += new System.EventHandler(this.controlsV11_Click);
            // 
            // browseV11
            // 
            this.browseV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseV11.Image = global::SuperMetroidRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.browseV11.Location = new System.Drawing.Point(495, 82);
            this.browseV11.Name = "browseV11";
            this.browseV11.Size = new System.Drawing.Size(25, 25);
            this.browseV11.TabIndex = 15;
            this.browseV11.UseVisualStyleBackColor = true;
            this.browseV11.Click += new System.EventHandler(this.browseV11_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Seed (leave blank to generate new random ROM)";
            // 
            // outputV11
            // 
            this.outputV11.AcceptsReturn = true;
            this.outputV11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputV11.Location = new System.Drawing.Point(6, 111);
            this.outputV11.Multiline = true;
            this.outputV11.Name = "outputV11";
            this.outputV11.ReadOnly = true;
            this.outputV11.Size = new System.Drawing.Size(514, 227);
            this.outputV11.TabIndex = 10;
            // 
            // seedV11
            // 
            this.seedV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seedV11.Location = new System.Drawing.Point(6, 46);
            this.seedV11.Name = "seedV11";
            this.seedV11.Size = new System.Drawing.Size(514, 20);
            this.seedV11.TabIndex = 16;
            // 
            // createV11
            // 
            this.createV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createV11.Location = new System.Drawing.Point(445, 17);
            this.createV11.Name = "createV11";
            this.createV11.Size = new System.Drawing.Size(75, 23);
            this.createV11.TabIndex = 11;
            this.createV11.Text = "Create";
            this.createV11.UseVisualStyleBackColor = true;
            this.createV11.Click += new System.EventHandler(this.createV11_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Output Filename (<seed> is replaced with file seed)";
            // 
            // filenameV11
            // 
            this.filenameV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameV11.Location = new System.Drawing.Point(6, 85);
            this.filenameV11.Name = "filenameV11";
            this.filenameV11.Size = new System.Drawing.Size(483, 20);
            this.filenameV11.TabIndex = 14;
            this.filenameV11.Text = "SM Random <seed>.sfc";
            this.filenameV11.TextChanged += new System.EventHandler(this.filenameV11_TextChanged);
            this.filenameV11.Leave += new System.EventHandler(this.filename_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.controls);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.output);
            this.tabPage2.Controls.Add(this.seed);
            this.tabPage2.Controls.Add(this.process);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.outputFilename);
            this.tabPage2.Controls.Add(this.save);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Old Randomizer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // controls
            // 
            this.controls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controls.Location = new System.Drawing.Point(364, 8);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(75, 23);
            this.controls.TabIndex = 19;
            this.controls.Text = "Controls";
            this.controls.UseVisualStyleBackColor = true;
            this.controls.Click += new System.EventHandler(this.controls_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Image = global::SuperMetroidRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.save.Location = new System.Drawing.Point(495, 73);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(25, 25);
            this.save.TabIndex = 7;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // createSpoilerLog
            // 
            this.createSpoilerLog.AutoSize = true;
            this.createSpoilerLog.Location = new System.Drawing.Point(192, 7);
            this.createSpoilerLog.Name = "createSpoilerLog";
            this.createSpoilerLog.Size = new System.Drawing.Size(113, 17);
            this.createSpoilerLog.TabIndex = 21;
            this.createSpoilerLog.Text = "Create Spoiler Log";
            this.createSpoilerLog.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 374);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Super Metroid Randomizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button process;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton suitlessForced;
        private System.Windows.Forms.RadioButton suitlessPossible;
        private System.Windows.Forms.RadioButton suitlessDisabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputFilename;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox seed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button browseV11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputV11;
        private System.Windows.Forms.TextBox seedV11;
        private System.Windows.Forms.Button createV11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filenameV11;
        private System.Windows.Forms.Button controlsV11;
        private System.Windows.Forms.Button controls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox randomizerDifficulty;
        private System.Windows.Forms.CheckBox createSpoilerLog;
    }
}

