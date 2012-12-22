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
            this.save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(12, 108);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(430, 164);
            this.output.TabIndex = 1;
            // 
            // process
            // 
            this.process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.process.Location = new System.Drawing.Point(367, 8);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
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
            this.label1.Location = new System.Drawing.Point(111, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Output Filename (<seed> is replaced with file seed)";
            // 
            // outputFilename
            // 
            this.outputFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFilename.Location = new System.Drawing.Point(114, 82);
            this.outputFilename.Name = "outputFilename";
            this.outputFilename.Size = new System.Drawing.Size(297, 20);
            this.outputFilename.TabIndex = 6;
            this.outputFilename.Text = "SM Random <seed>.sfc";
            this.outputFilename.TextChanged += new System.EventHandler(this.outputFilename_TextChanged);
            // 
            // seed
            // 
            this.seed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seed.Location = new System.Drawing.Point(114, 43);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(328, 20);
            this.seed.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seed (leave blank to generate new random ROM)";
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Image = global::SuperMetroidRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.save.Location = new System.Drawing.Point(417, 79);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(25, 25);
            this.save.TabIndex = 7;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 284);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.save);
            this.Controls.Add(this.outputFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.process);
            this.Controls.Add(this.output);
            this.Name = "MainForm";
            this.Text = "Super Metroid Randomizer v10";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

