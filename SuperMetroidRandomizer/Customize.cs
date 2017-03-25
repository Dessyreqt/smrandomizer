using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer
{
    public partial class Customize : Form
    {
        // Used to set starting values based on difficulty chosen
        RandomizerDifficulty DifficultyDefault;

        public Customize()
        {
            InitializeComponent();
        }
        public Customize(RandomizerDifficulty diff)
        {
            InitializeComponent();
            DifficultyDefault = diff;
        }

        private void Customize_Load(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            switch(DifficultyDefault)
            {
                case RandomizerDifficulty.Casual:
                    NormalMissiles.Value = 230;
                    SuperMissiles.Value = 50;
                    PowerBombs.Value = 50;
                    EnergyTanks.Value = 14;
                    AllowHiddenItems.Checked = false;
                    RouteGen.SelectedItem = "Casual";
                    break;
                case RandomizerDifficulty.Speedrunner:
                    NormalMissiles.Value = 50;
                    SuperMissiles.Value = 30;
                    PowerBombs.Value = 20;
                    EnergyTanks.Value = 7;
                    AllowHiddenItems.Checked = true;
                    RouteGen.SelectedItem = "Speedrunner";
                    break;
                case RandomizerDifficulty.Masochist:
                    NormalMissiles.Value = 15;
                    SuperMissiles.Value = 15;
                    PowerBombs.Value = 15;
                    EnergyTanks.Value = 3;
                    AllowHiddenItems.Checked = true;
                    RouteGen.SelectedItem = "Masochist";
                    break;
                default:
                    NormalMissiles.Value = Settings.Default.CustomNormalMissiles;
                    SuperMissiles.Value = Settings.Default.CustomSuperMissiles;
                    PowerBombs.Value = Settings.Default.CustomPowerBombs;
                    EnergyTanks.Value = Settings.Default.CustomEnergyTanks;
                    AllowHiddenItems.Checked = Settings.Default.CustomHiddenItems;
                    RouteGen.SelectedItem = Settings.Default.CustomRouteGen;
                    break;
            }
        }

        private void CustomSave_Click(object sender, EventArgs e)
        {
            Settings.Default.CustomNormalMissiles = NormalMissiles.Value;
            Settings.Default.CustomSuperMissiles = SuperMissiles.Value;
            Settings.Default.CustomPowerBombs = PowerBombs.Value;
            Settings.Default.CustomEnergyTanks = EnergyTanks.Value;
            Settings.Default.CustomHiddenItems = AllowHiddenItems.Checked;
            Settings.Default.CustomRouteGen = RouteGen.SelectedItem.ToString();

            if (NoFill.Checked)
                Settings.Default.CustomRandomBlanks = Settings.Default.CustomRandomNoBlanks = false;
            else if (RandomBlanks.Checked)
            {
                Settings.Default.CustomRandomBlanks = true;
                Settings.Default.CustomRandomNoBlanks = false;
            }
            else
            {
                Settings.Default.CustomRandomBlanks = false;
                Settings.Default.CustomRandomNoBlanks = true;
            }

            Settings.Default.UseCustomSettings = true;
            Settings.Default.Save();
            Close();
        }

        private void CustomCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetControls_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            decimal percent = CalculatePercentage();
            if (percent > 100)
                NoFill.Enabled = RandomBlanks.Enabled = RandomNoBlanks.Enabled = CustomSave.Enabled = false;
            else if (percent == 100)
            {
                NoFill.Enabled = RandomBlanks.Enabled = RandomNoBlanks.Enabled = false;
                CustomSave.Enabled = true;
            }
            else
                NoFill.Enabled = RandomBlanks.Enabled = RandomNoBlanks.Enabled = CustomSave.Enabled = true;

            if (NoFill.Enabled && !NoFill.Checked)
            {
                label1.Text = label1.Text.Replace("Max", "Min");
                label2.Text = label2.Text.Replace("Max", "Min");
                label3.Text = label3.Text.Replace("Max", "Min");
                label4.Text = label4.Text.Replace("Max", "Min");
            }
            else
            {
                label1.Text = label1.Text.Replace("Min", "Max");
                label2.Text = label2.Text.Replace("Min", "Max");
                label3.Text = label3.Text.Replace("Min", "Max");
                label4.Text = label4.Text.Replace("Min", "Max");
            }

            if (RandomBlanks.Enabled && RandomBlanks.Checked)
                Percent.Text = "??%";
            else if (RandomNoBlanks.Enabled && RandomNoBlanks.Checked)
                Percent.Text = "100%";
            else
                Percent.Text = string.Format("{0}%", percent);
        }

        private decimal CalculatePercentage()
        {
            decimal start = 0;
            switch(DifficultyDefault)
            {
                case RandomizerDifficulty.Casual:
                    start = 20;
                    break;
                case RandomizerDifficulty.Speedrunner:
                    start = 23;
                    break;
                case RandomizerDifficulty.Masochist:
                    start = 16;
                    break;
                default:
                    start = 20;
                    break;
            }

            start += (NormalMissiles.Value / 5) + (SuperMissiles.Value / 5) + (PowerBombs.Value / 5) + EnergyTanks.Value;
            return start;
        }
    }
}
