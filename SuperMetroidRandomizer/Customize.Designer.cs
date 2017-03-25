namespace SuperMetroidRandomizer
{
    partial class Customize
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
            this.label1 = new System.Windows.Forms.Label();
            this.NormalMissiles = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SuperMissiles = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PowerBombs = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.EnergyTanks = new System.Windows.Forms.NumericUpDown();
            this.AllowHiddenItems = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ResetControls = new System.Windows.Forms.Button();
            this.CustomSave = new System.Windows.Forms.Button();
            this.CustomCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
            this.RouteGen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RandomBlanks = new System.Windows.Forms.RadioButton();
            this.RandomNoBlanks = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.NoFill = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.NormalMissiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperMissiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerBombs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTanks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max Missiles";
            // 
            // NormalMissiles
            // 
            this.NormalMissiles.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NormalMissiles.Location = new System.Drawing.Point(163, 71);
            this.NormalMissiles.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NormalMissiles.Name = "NormalMissiles";
            this.NormalMissiles.ReadOnly = true;
            this.NormalMissiles.Size = new System.Drawing.Size(42, 20);
            this.NormalMissiles.TabIndex = 1;
            this.NormalMissiles.Value = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.NormalMissiles.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Super Missiles";
            // 
            // SuperMissiles
            // 
            this.SuperMissiles.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SuperMissiles.Location = new System.Drawing.Point(163, 96);
            this.SuperMissiles.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SuperMissiles.Name = "SuperMissiles";
            this.SuperMissiles.ReadOnly = true;
            this.SuperMissiles.Size = new System.Drawing.Size(42, 20);
            this.SuperMissiles.TabIndex = 3;
            this.SuperMissiles.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SuperMissiles.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max Power Bombs";
            // 
            // PowerBombs
            // 
            this.PowerBombs.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PowerBombs.Location = new System.Drawing.Point(163, 121);
            this.PowerBombs.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.PowerBombs.Name = "PowerBombs";
            this.PowerBombs.ReadOnly = true;
            this.PowerBombs.Size = new System.Drawing.Size(42, 20);
            this.PowerBombs.TabIndex = 5;
            this.PowerBombs.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.PowerBombs.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Energy Tanks";
            // 
            // EnergyTanks
            // 
            this.EnergyTanks.Location = new System.Drawing.Point(163, 148);
            this.EnergyTanks.Name = "EnergyTanks";
            this.EnergyTanks.ReadOnly = true;
            this.EnergyTanks.Size = new System.Drawing.Size(42, 20);
            this.EnergyTanks.TabIndex = 7;
            this.EnergyTanks.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.EnergyTanks.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // AllowHiddenItems
            // 
            this.AllowHiddenItems.AutoSize = true;
            this.AllowHiddenItems.Location = new System.Drawing.Point(43, 272);
            this.AllowHiddenItems.Name = "AllowHiddenItems";
            this.AllowHiddenItems.Size = new System.Drawing.Size(88, 17);
            this.AllowHiddenItems.TabIndex = 8;
            this.AllowHiddenItems.Text = "Hidden Items";
            this.toolTip1.SetToolTip(this.AllowHiddenItems, "If checked, allows items to be hidden.");
            this.AllowHiddenItems.UseVisualStyleBackColor = true;
            // 
            // ResetControls
            // 
            this.ResetControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResetControls.Location = new System.Drawing.Point(77, 361);
            this.ResetControls.Name = "ResetControls";
            this.ResetControls.Size = new System.Drawing.Size(94, 23);
            this.ResetControls.TabIndex = 9;
            this.ResetControls.Text = "Reset to Default";
            this.ResetControls.UseVisualStyleBackColor = true;
            this.ResetControls.Click += new System.EventHandler(this.ResetControls_Click);
            // 
            // CustomSave
            // 
            this.CustomSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CustomSave.Location = new System.Drawing.Point(43, 390);
            this.CustomSave.Name = "CustomSave";
            this.CustomSave.Size = new System.Drawing.Size(75, 23);
            this.CustomSave.TabIndex = 10;
            this.CustomSave.Text = "Save";
            this.CustomSave.UseVisualStyleBackColor = true;
            this.CustomSave.Click += new System.EventHandler(this.CustomSave_Click);
            // 
            // CustomCancel
            // 
            this.CustomCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CustomCancel.Location = new System.Drawing.Point(130, 390);
            this.CustomCancel.Name = "CustomCancel";
            this.CustomCancel.Size = new System.Drawing.Size(75, 23);
            this.CustomCancel.TabIndex = 11;
            this.CustomCancel.Text = "Cancel";
            this.CustomCancel.UseVisualStyleBackColor = true;
            this.CustomCancel.Click += new System.EventHandler(this.CustomCancel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Max Completion:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Percent
            // 
            this.Percent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percent.Location = new System.Drawing.Point(15, 328);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(222, 23);
            this.Percent.TabIndex = 13;
            this.Percent.Text = "100%";
            this.Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RouteGen
            // 
            this.RouteGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RouteGen.FormattingEnabled = true;
            this.RouteGen.Items.AddRange(new object[] {
            "Casual",
            "Speedrunner",
            "Masochist"});
            this.RouteGen.Location = new System.Drawing.Point(67, 36);
            this.RouteGen.Name = "RouteGen";
            this.RouteGen.Size = new System.Drawing.Size(121, 21);
            this.RouteGen.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Route Generation";
            // 
            // RandomBlanks
            // 
            this.RandomBlanks.AutoSize = true;
            this.RandomBlanks.Enabled = false;
            this.RandomBlanks.Location = new System.Drawing.Point(43, 217);
            this.RandomBlanks.Name = "RandomBlanks";
            this.RandomBlanks.Size = new System.Drawing.Size(81, 17);
            this.RandomBlanks.TabIndex = 18;
            this.RandomBlanks.Text = "With blanks";
            this.toolTip1.SetToolTip(this.RandomBlanks, "Random Items have a chance of being blank.");
            this.RandomBlanks.UseVisualStyleBackColor = true;
            this.RandomBlanks.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // RandomNoBlanks
            // 
            this.RandomNoBlanks.AutoSize = true;
            this.RandomNoBlanks.Enabled = false;
            this.RandomNoBlanks.Location = new System.Drawing.Point(43, 241);
            this.RandomNoBlanks.Name = "RandomNoBlanks";
            this.RandomNoBlanks.Size = new System.Drawing.Size(74, 17);
            this.RandomNoBlanks.TabIndex = 19;
            this.RandomNoBlanks.Text = "No Blanks";
            this.toolTip1.SetToolTip(this.RandomNoBlanks, "Random items will never be blank.");
            this.RandomNoBlanks.UseVisualStyleBackColor = true;
            this.RandomNoBlanks.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Random Fill";
            this.toolTip1.SetToolTip(this.label7, "Randomly fill the remaining item locations with Missiles, Super Missiles, Power B" +
        "ombs, or Energy Tanks.");
            // 
            // NoFill
            // 
            this.NoFill.AutoSize = true;
            this.NoFill.Checked = true;
            this.NoFill.Enabled = false;
            this.NoFill.Location = new System.Drawing.Point(43, 194);
            this.NoFill.Name = "NoFill";
            this.NoFill.Size = new System.Drawing.Size(54, 17);
            this.NoFill.TabIndex = 21;
            this.NoFill.TabStop = true;
            this.NoFill.Text = "No Fill";
            this.toolTip1.SetToolTip(this.NoFill, "Disables this feature. (default)");
            this.NoFill.UseVisualStyleBackColor = true;
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 425);
            this.Controls.Add(this.NoFill);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RandomNoBlanks);
            this.Controls.Add(this.RandomBlanks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RouteGen);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomCancel);
            this.Controls.Add(this.CustomSave);
            this.Controls.Add(this.ResetControls);
            this.Controls.Add(this.AllowHiddenItems);
            this.Controls.Add(this.EnergyTanks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PowerBombs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SuperMissiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NormalMissiles);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize";
            this.Load += new System.EventHandler(this.Customize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NormalMissiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperMissiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerBombs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTanks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NormalMissiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SuperMissiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PowerBombs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown EnergyTanks;
        private System.Windows.Forms.CheckBox AllowHiddenItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button ResetControls;
        private System.Windows.Forms.Button CustomSave;
        private System.Windows.Forms.Button CustomCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Percent;
        private System.Windows.Forms.ComboBox RouteGen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RandomBlanks;
        private System.Windows.Forms.RadioButton RandomNoBlanks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton NoFill;
    }
}