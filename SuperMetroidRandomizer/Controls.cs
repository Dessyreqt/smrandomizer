using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMetroidRandomizer.Properties;

namespace SuperMetroidRandomizer
{
    public partial class Controls : Form
    {
        private readonly Dictionary<string, string> controlsDict;

        public Controls()
        {
            InitializeComponent();
            controlsDict = new Dictionary<string, string>();
        }

        private void Controls_Load(object sender, EventArgs e)
        {
            shot.SelectedItem = Settings.Default.ControlsShot;
            jump.SelectedItem = Settings.Default.ControlsJump;
            dash.SelectedItem = Settings.Default.ControlsDash;
            itemSelect.SelectedItem = Settings.Default.ControlsItemSelect;
            itemCancel.SelectedItem = Settings.Default.ControlsItemCancel;
            angleUp.SelectedItem = Settings.Default.ControlsAngleUp;
            angleDown.SelectedItem = Settings.Default.ControlsAngleDown;

            controlsDict[shot.Name] = shot.SelectedItem.ToString();
            controlsDict[jump.Name] = jump.SelectedItem.ToString();
            controlsDict[dash.Name] = dash.SelectedItem.ToString();
            controlsDict[itemSelect.Name] = itemSelect.SelectedItem.ToString();
            controlsDict[itemCancel.Name] = itemCancel.SelectedItem.ToString();
            controlsDict[angleUp.Name] = angleUp.SelectedItem.ToString();
            controlsDict[angleDown.Name] = angleDown.SelectedItem.ToString();
        }

        private void control_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senderBox = (ComboBox) sender;

            if (senderBox.Items.Contains("None") && senderBox.SelectedItem.ToString() != "None")
            {
                senderBox.Items.Remove("None");
            }

            var otherControl = (from control in Controls.OfType<ComboBox>()
                                where control.SelectedItem == senderBox.SelectedItem && control != senderBox
                                select control).FirstOrDefault();

            if (otherControl != null)
            {
                if (otherControl.Items.Contains(controlsDict[senderBox.Name]))
                {
                    otherControl.SelectedItem = controlsDict[senderBox.Name];
                }
                else
                {
                    if (!otherControl.Items.Contains("None"))
                    {
                        otherControl.Items.Add("None");
                    }

                    otherControl.SelectedItem = "None";
                }
                controlsDict[otherControl.Name] = controlsDict[senderBox.Name];
            }

            controlsDict[senderBox.Name] = senderBox.SelectedItem.ToString();
        }

        private void cancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Settings.Default.ControlsShot = shot.SelectedItem.ToString();
            Settings.Default.ControlsJump = jump.SelectedItem.ToString();
            Settings.Default.ControlsDash = dash.SelectedItem.ToString();
            Settings.Default.ControlsItemSelect = itemSelect.SelectedItem.ToString();
            Settings.Default.ControlsItemCancel = itemCancel.SelectedItem.ToString();
            Settings.Default.ControlsAngleUp = angleUp.SelectedItem.ToString();
            Settings.Default.ControlsAngleDown = angleDown.SelectedItem.ToString();

            Settings.Default.Save();
            Close();
        }
    }
}
