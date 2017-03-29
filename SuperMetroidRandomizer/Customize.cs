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
        string DifficultyDefault;

        public Customize()
        {
            InitializeComponent();
        }
        public Customize(string diff)
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
                case "Casual":
                    NormalMissiles.Value = 230;
                    NormalMissilesMax.Value = 230;
                    SuperMissiles.Value = 50;
                    SuperMissilesMax.Value = 50;
                    PowerBombs.Value = 50;
                    PowerBombsMax.Value = 50;
                    EnergyTanks.Value = 14;
                    EnergyTanksMax.Value = 14;
                    AllowHiddenItems.Checked = false;
                    RouteGen.SelectedItem = "Casual";
                    break;
                case "Speedrunner":
                    NormalMissiles.Value = 50;
                    NormalMissilesMax.Value = 50;
                    SuperMissiles.Value = 30;
                    SuperMissilesMax.Value = 30;
                    PowerBombs.Value = 20;
                    PowerBombsMax.Value = 20;
                    EnergyTanks.Value = 7;
                    EnergyTanksMax.Value = 7;
                    AllowHiddenItems.Checked = true;
                    RouteGen.SelectedItem = "Speedrunner";
                    break;
                case "Masochist":
                    NormalMissiles.Value = 15;
                    NormalMissilesMax.Value = 15;
                    SuperMissiles.Value = 15;
                    SuperMissilesMax.Value = 15;
                    PowerBombs.Value = 15;
                    PowerBombsMax.Value = 15;
                    EnergyTanks.Value = 3;
                    EnergyTanksMax.Value = 3;
                    AllowHiddenItems.Checked = true;
                    RouteGen.SelectedItem = "Masochist";
                    break;
                default:
                    NormalMissiles.Value = Settings.Default.CustomNormalMissiles;
                    SuperMissiles.Value = Settings.Default.CustomSuperMissiles;
                    PowerBombs.Value = Settings.Default.CustomPowerBombs;
                    EnergyTanks.Value = Settings.Default.CustomEnergyTanks;
                    NormalMissilesMax.Value = Settings.Default.CustomNormalMissilesMax;
                    SuperMissilesMax.Value = Settings.Default.CustomSuperMissilesMax;
                    PowerBombsMax.Value = Settings.Default.CustomPowerBombsMax;
                    EnergyTanksMax.Value = Settings.Default.CustomEnergyTanksMax;
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
            Settings.Default.CustomNormalMissilesMax = NormalMissilesMax.Value;
            Settings.Default.CustomSuperMissilesMax = SuperMissilesMax.Value;
            Settings.Default.CustomPowerBombsMax = PowerBombsMax.Value;
            Settings.Default.CustomEnergyTanksMax = EnergyTanksMax.Value;
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
            if (sender == NormalMissilesMax && NormalMissilesMax.Value < NormalMissiles.Value)
                NormalMissilesMax.Value = NormalMissiles.Value;
            else if (sender == SuperMissilesMax && SuperMissilesMax.Value < SuperMissiles.Value)
                SuperMissilesMax.Value = SuperMissiles.Value;
            else if (sender == PowerBombsMax && PowerBombsMax.Value < PowerBombs.Value)
                PowerBombsMax.Value = PowerBombs.Value;
            else if (sender == EnergyTanksMax && EnergyTanksMax.Value < EnergyTanks.Value)
                EnergyTanksMax.Value = EnergyTanks.Value;

            decimal percent = CalculatePercentage();
            if (percent > 100 && !RandomNoBlanks.Checked)
                CustomSave.Enabled = false;
            else
                CustomSave.Enabled = true;

            if (NoFill.Enabled && !NoFill.Checked)
            {
                Minlbl.Visible = Maxlbl.Visible = NormalMissilesMax.Visible = SuperMissilesMax.Visible = PowerBombsMax.Visible = EnergyTanksMax.Visible = true;
            }
            else
                Minlbl.Visible = Maxlbl.Visible = NormalMissilesMax.Visible = SuperMissilesMax.Visible = PowerBombsMax.Visible = EnergyTanksMax.Visible = false;

            if (RandomBlanks.Enabled && RandomBlanks.Checked)
                Percent.Text = "??%";
            else if (RandomNoBlanks.Enabled && RandomNoBlanks.Checked)
            {
                if (percent > 100)
                    Percent.Text = "100%";
                else
                    Percent.Text = string.Format("{0}%", percent);
            }
            else
                Percent.Text = string.Format("{0}%", percent);
        }

        private decimal CalculatePercentage()
        {
            decimal start = 0;
            switch(DifficultyDefault)
            {
                case "Casual":
                    start = 20;
                    break;
                case "Speedrunner":
                    start = 20;
                    break;
                case "Masochist":
                    start = 13;
                    break;
                default:
                    start = 20;
                    break;
            }

            start += (NormalMissiles.Value / 5) + (SuperMissiles.Value / 5) + (PowerBombs.Value / 5) + EnergyTanks.Value;
            if (RandomNoBlanks.Checked)
            {
                start += ((NormalMissilesMax.Value - NormalMissiles.Value) / 5) + ((SuperMissilesMax.Value - SuperMissiles.Value) / 5);
                start += ((PowerBombsMax.Value - PowerBombs.Value) / 5) + (EnergyTanksMax.Value - EnergyTanks.Value);
            }
            return start;
        }
    }
}
