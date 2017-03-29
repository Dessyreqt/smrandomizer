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
            this.RandomBlanks = new System.Windows.Forms.RadioButton();
            this.RandomNoBlanks = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.NoFill = new System.Windows.Forms.RadioButton();
            this.ResetControls = new System.Windows.Forms.Button();
            this.CustomSave = new System.Windows.Forms.Button();
            this.CustomCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
            this.RouteGen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Minlbl = new System.Windows.Forms.Label();
            this.Maxlbl = new System.Windows.Forms.Label();
            this.NormalMissilesMax = new System.Windows.Forms.NumericUpDown();
            this.SuperMissilesMax = new System.Windows.Forms.NumericUpDown();
            this.PowerBombsMax = new System.Windows.Forms.NumericUpDown();
            this.EnergyTanksMax = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NormalMissiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperMissiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerBombs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalMissilesMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperMissilesMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerBombsMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTanksMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Missiles";
            // 
            // NormalMissiles
            // 
            this.NormalMissiles.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NormalMissiles.Location = new System.Drawing.Point(146, 94);
            this.NormalMissiles.Maximum = new decimal(new int[] {
            390,
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
            this.label2.Location = new System.Drawing.Point(40, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Super Missiles";
            // 
            // SuperMissiles
            // 
            this.SuperMissiles.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SuperMissiles.Location = new System.Drawing.Point(146, 119);
            this.SuperMissiles.Maximum = new decimal(new int[] {
            395,
            0,
            0,
            0});
            this.SuperMissiles.Minimum = new decimal(new int[] {
            5,
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
            this.label3.Location = new System.Drawing.Point(40, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Power Bombs";
            // 
            // PowerBombs
            // 
            this.PowerBombs.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PowerBombs.Location = new System.Drawing.Point(146, 144);
            this.PowerBombs.Maximum = new decimal(new int[] {
            395,
            0,
            0,
            0});
            this.PowerBombs.Minimum = new decimal(new int[] {
            5,
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
            this.label4.Location = new System.Drawing.Point(40, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Energy Tanks";
            // 
            // EnergyTanks
            // 
            this.EnergyTanks.Location = new System.Drawing.Point(146, 171);
            this.EnergyTanks.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.EnergyTanks.Name = "EnergyTanks";
            this.EnergyTanks.ReadOnly = true;
            this.EnergyTanks.Size = new System.Drawing.Size(42, 20);
            this.EnergyTanks.TabIndex = 7;
            this.toolTip1.SetToolTip(this.EnergyTanks, "Warning: Increase at own risk. Numbers higher than 14 can cause glitchy results.");
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
            this.AllowHiddenItems.Location = new System.Drawing.Point(43, 295);
            this.AllowHiddenItems.Name = "AllowHiddenItems";
            this.AllowHiddenItems.Size = new System.Drawing.Size(88, 17);
            this.AllowHiddenItems.TabIndex = 8;
            this.AllowHiddenItems.Text = "Hidden Items";
            this.toolTip1.SetToolTip(this.AllowHiddenItems, "If checked, allows items to be hidden.");
            this.AllowHiddenItems.UseVisualStyleBackColor = true;
            // 
            // RandomBlanks
            // 
            this.RandomBlanks.AutoSize = true;
            this.RandomBlanks.Location = new System.Drawing.Point(43, 240);
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
            this.RandomNoBlanks.Location = new System.Drawing.Point(43, 264);
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
            this.label7.Location = new System.Drawing.Point(40, 201);
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
            this.NoFill.Location = new System.Drawing.Point(43, 217);
            this.NoFill.Name = "NoFill";
            this.NoFill.Size = new System.Drawing.Size(54, 17);
            this.NoFill.TabIndex = 21;
            this.NoFill.TabStop = true;
            this.NoFill.Text = "No Fill";
            this.toolTip1.SetToolTip(this.NoFill, "Disables this feature. (default)");
            this.NoFill.UseVisualStyleBackColor = true;
            // 
            // ResetControls
            // 
            this.ResetControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResetControls.Location = new System.Drawing.Point(77, 396);
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
            this.CustomSave.Location = new System.Drawing.Point(43, 425);
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
            this.CustomCancel.Location = new System.Drawing.Point(130, 425);
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
            this.label5.Location = new System.Drawing.Point(12, 340);
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
            this.Percent.Location = new System.Drawing.Point(15, 363);
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
            // Minlbl
            // 
            this.Minlbl.AutoSize = true;
            this.Minlbl.Location = new System.Drawing.Point(150, 78);
            this.Minlbl.Name = "Minlbl";
            this.Minlbl.Size = new System.Drawing.Size(24, 13);
            this.Minlbl.TabIndex = 22;
            this.Minlbl.Text = "Min";
            this.Minlbl.Visible = false;
            // 
            // Maxlbl
            // 
            this.Maxlbl.AutoSize = true;
            this.Maxlbl.Location = new System.Drawing.Point(197, 78);
            this.Maxlbl.Name = "Maxlbl";
            this.Maxlbl.Size = new System.Drawing.Size(27, 13);
            this.Maxlbl.TabIndex = 23;
            this.Maxlbl.Text = "Max";
            this.Maxlbl.Visible = false;
            // 
            // NormalMissilesMax
            // 
            this.NormalMissilesMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NormalMissilesMax.Location = new System.Drawing.Point(195, 93);
            this.NormalMissilesMax.Maximum = new decimal(new int[] {
            390,
            0,
            0,
            0});
            this.NormalMissilesMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NormalMissilesMax.Name = "NormalMissilesMax";
            this.NormalMissilesMax.ReadOnly = true;
            this.NormalMissilesMax.Size = new System.Drawing.Size(42, 20);
            this.NormalMissilesMax.TabIndex = 24;
            this.NormalMissilesMax.Value = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.NormalMissilesMax.Visible = false;
            this.NormalMissilesMax.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // SuperMissilesMax
            // 
            this.SuperMissilesMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SuperMissilesMax.Location = new System.Drawing.Point(195, 118);
            this.SuperMissilesMax.Maximum = new decimal(new int[] {
            395,
            0,
            0,
            0});
            this.SuperMissilesMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SuperMissilesMax.Name = "SuperMissilesMax";
            this.SuperMissilesMax.ReadOnly = true;
            this.SuperMissilesMax.Size = new System.Drawing.Size(42, 20);
            this.SuperMissilesMax.TabIndex = 25;
            this.SuperMissilesMax.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SuperMissilesMax.Visible = false;
            this.SuperMissilesMax.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // PowerBombsMax
            // 
            this.PowerBombsMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PowerBombsMax.Location = new System.Drawing.Point(195, 143);
            this.PowerBombsMax.Maximum = new decimal(new int[] {
            395,
            0,
            0,
            0});
            this.PowerBombsMax.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PowerBombsMax.Name = "PowerBombsMax";
            this.PowerBombsMax.ReadOnly = true;
            this.PowerBombsMax.Size = new System.Drawing.Size(42, 20);
            this.PowerBombsMax.TabIndex = 26;
            this.PowerBombsMax.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.PowerBombsMax.Visible = false;
            this.PowerBombsMax.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // EnergyTanksMax
            // 
            this.EnergyTanksMax.Location = new System.Drawing.Point(195, 170);
            this.EnergyTanksMax.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.EnergyTanksMax.Name = "EnergyTanksMax";
            this.EnergyTanksMax.ReadOnly = true;
            this.EnergyTanksMax.Size = new System.Drawing.Size(42, 20);
            this.EnergyTanksMax.TabIndex = 27;
            this.EnergyTanksMax.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.EnergyTanksMax.Visible = false;
            this.EnergyTanksMax.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // Customize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 460);
            this.Controls.Add(this.EnergyTanksMax);
            this.Controls.Add(this.PowerBombsMax);
            this.Controls.Add(this.SuperMissilesMax);
            this.Controls.Add(this.NormalMissilesMax);
            this.Controls.Add(this.Maxlbl);
            this.Controls.Add(this.Minlbl);
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
            ((System.ComponentModel.ISupportInitialize)(this.NormalMissilesMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperMissilesMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerBombsMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTanksMax)).EndInit();
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
        private System.Windows.Forms.Label Minlbl;
        private System.Windows.Forms.Label Maxlbl;
        private System.Windows.Forms.NumericUpDown NormalMissilesMax;
        private System.Windows.Forms.NumericUpDown SuperMissilesMax;
        private System.Windows.Forms.NumericUpDown PowerBombsMax;
        private System.Windows.Forms.NumericUpDown EnergyTanksMax;
    }
}