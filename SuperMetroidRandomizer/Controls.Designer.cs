namespace SuperMetroidRandomizer
{
    partial class Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controls));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.shot = new System.Windows.Forms.ComboBox();
            this.jump = new System.Windows.Forms.ComboBox();
            this.dash = new System.Windows.Forms.ComboBox();
            this.itemSelect = new System.Windows.Forms.ComboBox();
            this.itemCancel = new System.Windows.Forms.ComboBox();
            this.angleUp = new System.Windows.Forms.ComboBox();
            this.angleDown = new System.Windows.Forms.ComboBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shot";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jump";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dash";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Item Select";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Item Cancel";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Angle Up";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Angle Down";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // shot
            // 
            this.shot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shot.FormattingEnabled = true;
            this.shot.Items.AddRange(new object[] {
            "None",
            "A",
            "B",
            "X",
            "Y",
            "L",
            "R",
            "Select"});
            this.shot.Location = new System.Drawing.Point(83, 10);
            this.shot.Name = "shot";
            this.shot.Size = new System.Drawing.Size(121, 21);
            this.shot.TabIndex = 7;
            this.shot.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // jump
            // 
            this.jump.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jump.FormattingEnabled = true;
            this.jump.Items.AddRange(new object[] {
            "A",
            "B",
            "X",
            "Y",
            "L",
            "R",
            "Select"});
            this.jump.Location = new System.Drawing.Point(83, 37);
            this.jump.Name = "jump";
            this.jump.Size = new System.Drawing.Size(121, 21);
            this.jump.TabIndex = 8;
            this.jump.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // dash
            // 
            this.dash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dash.FormattingEnabled = true;
            this.dash.Items.AddRange(new object[] {
            "A",
            "B",
            "X",
            "Y",
            "L",
            "R",
            "Select"});
            this.dash.Location = new System.Drawing.Point(83, 64);
            this.dash.Name = "dash";
            this.dash.Size = new System.Drawing.Size(121, 21);
            this.dash.TabIndex = 9;
            this.dash.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // itemSelect
            // 
            this.itemSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemSelect.FormattingEnabled = true;
            this.itemSelect.Items.AddRange(new object[] {
            "A",
            "B",
            "X",
            "Y",
            "L",
            "R",
            "Select"});
            this.itemSelect.Location = new System.Drawing.Point(83, 91);
            this.itemSelect.Name = "itemSelect";
            this.itemSelect.Size = new System.Drawing.Size(121, 21);
            this.itemSelect.TabIndex = 10;
            this.itemSelect.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // itemCancel
            // 
            this.itemCancel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemCancel.FormattingEnabled = true;
            this.itemCancel.Items.AddRange(new object[] {
            "A",
            "B",
            "X",
            "Y",
            "L",
            "R",
            "Select"});
            this.itemCancel.Location = new System.Drawing.Point(83, 118);
            this.itemCancel.Name = "itemCancel";
            this.itemCancel.Size = new System.Drawing.Size(121, 21);
            this.itemCancel.TabIndex = 11;
            this.itemCancel.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // angleUp
            // 
            this.angleUp.BackColor = System.Drawing.SystemColors.Window;
            this.angleUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.angleUp.FormattingEnabled = true;
            this.angleUp.Items.AddRange(new object[] {
            "L",
            "R"});
            this.angleUp.Location = new System.Drawing.Point(83, 145);
            this.angleUp.Name = "angleUp";
            this.angleUp.Size = new System.Drawing.Size(121, 21);
            this.angleUp.TabIndex = 12;
            this.angleUp.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // angleDown
            // 
            this.angleDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.angleDown.FormattingEnabled = true;
            this.angleDown.Items.AddRange(new object[] {
            "L",
            "R"});
            this.angleDown.Location = new System.Drawing.Point(83, 172);
            this.angleDown.Name = "angleDown";
            this.angleDown.Size = new System.Drawing.Size(121, 21);
            this.angleDown.TabIndex = 13;
            this.angleDown.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(129, 199);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 14;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.Location = new System.Drawing.Point(12, 204);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(40, 13);
            this.cancel.TabIndex = 15;
            this.cancel.TabStop = true;
            this.cancel.Text = "Cancel";
            this.cancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cancel_LinkClicked);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 234);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.angleDown);
            this.Controls.Add(this.angleUp);
            this.Controls.Add(this.itemCancel);
            this.Controls.Add(this.itemSelect);
            this.Controls.Add(this.dash);
            this.Controls.Add(this.jump);
            this.Controls.Add(this.shot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Controls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.Controls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox shot;
        private System.Windows.Forms.ComboBox jump;
        private System.Windows.Forms.ComboBox dash;
        private System.Windows.Forms.ComboBox itemSelect;
        private System.Windows.Forms.ComboBox itemCancel;
        private System.Windows.Forms.ComboBox angleUp;
        private System.Windows.Forms.ComboBox angleDown;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.LinkLabel cancel;
    }
}