using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Random;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer
{
    public enum Suitless
    {
        Disabled,
        Possible,
        Forced
    }

    public partial class MainForm : Form
    {
        private Thread checkUpdateThread;

        public MainForm()
        {
            InitializeSettings();
            InitializeComponent();
        }

        private void InitializeSettings()
        {
            Settings.Default.OutputFile = Settings.Default.OutputFile;
            Settings.Default.OutputFileV11 = Settings.Default.OutputFileV11;
            Settings.Default.ControlsShot = Settings.Default.ControlsShot;
            Settings.Default.ControlsJump = Settings.Default.ControlsJump;
            Settings.Default.ControlsDash = Settings.Default.ControlsDash;
            Settings.Default.ControlsItemSelect = Settings.Default.ControlsItemSelect;
            Settings.Default.ControlsItemCancel = Settings.Default.ControlsItemCancel;
            Settings.Default.ControlsAngleUp = Settings.Default.ControlsAngleUp;
            Settings.Default.ControlsAngleDown = Settings.Default.ControlsAngleDown;
            Settings.Default.RandomizerDifficulty = Settings.Default.RandomizerDifficulty;
            Settings.Default.CreateSpoilerLog = Settings.Default.CreateSpoilerLog;
        }

        private void RunCheckUpdate()
        {
            checkUpdateThread = new Thread(RandomizerVersion.CheckUpdate);
            checkUpdateThread.SetApartmentState(ApartmentState.STA);
            checkUpdateThread.Start();
        }

        private void process_Click(object sender, EventArgs e)
        {
            var randomizerV10 = new RandomizerV10();

            //default to disabled in case they somehow uncheck all the buttons
            if (suitlessPossible.Checked)
                randomizerV10.IsSuitless = Suitless.Possible;
            else if (suitlessForced.Checked)
                randomizerV10.IsSuitless = Suitless.Forced;
            else
                randomizerV10.IsSuitless = Suitless.Disabled;
   
            ClearOutput();
            var outSeed = randomizerV10.CreateRom(outputFilename.Text, seed.Text);
            WriteOutput(string.Format("Done!{1}{1}{1}Seed: {0}{1}", outSeed, Environment.NewLine));
            if (!string.IsNullOrWhiteSpace(seed.Text))
            {
                WriteOutput(randomizerV10.RequiresSuitless()
                                ? string.Format("{0}Warning: Seed requires suitless Maridia!{0}{0}", Environment.NewLine)
                                : string.Format("{0}Seed does not require suitless Maridia.{0}{0}", Environment.NewLine));

                if (randomizerV10.LikelyImpossible())
                {
                    WriteOutput(string.Format("{0}Warning: Seed is likely impossible!{0}{0}", Environment.NewLine));
                }
            }
        }

        private void WriteOutput(string text)
        {
            output.Text += text;
        }

        private void ClearOutput()
        {
            output.Text = "";
        }

        private void save_Click(object sender, EventArgs e)
        {
            var info = new FileInfo(Regex.Replace(outputFilename.Text, "<.*>", ""));
            var saveFileDialog = new SaveFileDialog { Filter = "All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, InitialDirectory = info.DirectoryName, FileName = info.Name };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFilename.Text = saveFileDialog.FileName;
                MessageBox.Show("Remember to hit \"create\" to create the rom.", "Remember to create the rom!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void outputFilename_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputFile = outputFilename.Text;
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            outputFilename.Text = Settings.Default.OutputFile;
            filenameV11.Text = Settings.Default.OutputFileV11;
            createSpoilerLog.Checked = Settings.Default.CreateSpoilerLog;
            Text = string.Format("Super Metroid Randomizer v{0}", RandomizerVersion.CurrentDisplay);
            randomizerDifficulty.SelectedItem = Settings.Default.RandomizerDifficulty;
            RunCheckUpdate();
        }

        private void createV11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(seedV11.Text))
            {
                switch (randomizerDifficulty.SelectedItem.ToString())
                {
                    case "Casual":
                        seedV11.Text = string.Format("C{0:0000000}", (new SeedRandom()).Next(10000000));
                        break;
                    case "Masochist":
                        seedV11.Text = string.Format("M{0:0000000}", (new SeedRandom()).Next(10000000));
                        break;
                    case "Insane":
                        seedV11.Text = string.Format("I{0:0000000}", (new SeedRandom()).Next(10000000));
                        break;
                    default:
                        seedV11.Text = string.Format("S{0:0000000}", (new SeedRandom()).Next(10000000));
                        break;
                }
            }

            ClearOutputV11();
            
            int parsedSeed;
            RandomizerDifficulty difficulty;
            var seedText = seedV11.Text;

            if (seedText.ToUpper().Contains("C"))
            {
                randomizerDifficulty.SelectedItem = "Casual";
                seedText = seedText.ToUpper().Replace("C", "");
                difficulty = RandomizerDifficulty.Casual;
            }
            else if (seedText.ToUpper().Contains("S"))
            {
                randomizerDifficulty.SelectedItem = "Speedrunner";
                seedText = seedText.ToUpper().Replace("S", "");
                difficulty = RandomizerDifficulty.Speedrunner;
            }
            else if (seedText.ToUpper().Contains("M"))
            {
                randomizerDifficulty.SelectedItem = "Masochist";
                seedText = seedText.ToUpper().Replace("M", "");
                difficulty = RandomizerDifficulty.Masochist;
            }
            else if (seedText.ToUpper().Contains("I"))
            {
                randomizerDifficulty.SelectedItem = "Insane";
                seedText = seedText.ToUpper().Replace("I", "");
                difficulty = RandomizerDifficulty.Insane;
            }
            else
            {
                switch (randomizerDifficulty.SelectedItem.ToString())
                {
                    case "Casual":
                        difficulty = RandomizerDifficulty.Casual;
                        break;
                    case "Speedrunner":
                        difficulty = RandomizerDifficulty.Speedrunner;
                        break;
                    case "Masochist":
                        difficulty = RandomizerDifficulty.Masochist;
                        break;
                    case "Insane":
                        difficulty = RandomizerDifficulty.Insane;
                        break;
                    default:
                        MessageBox.Show("Please select a difficulty.", "Select Difficulty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        WriteOutputV11("Please select a difficulty.");
                        return;
                }
            }

            if (!int.TryParse(seedText, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutputV11("Seed must be numeric or blank.");
            }
            else
            {
                var romPlms = RomPlmsFactory.GetRomPlms(difficulty);
                RandomizerLog log = null;

                if (createSpoilerLog.Checked)
                {
                    log = new RandomizerLog(string.Format(romPlms.SeedFileString, parsedSeed));
                }

                seedV11.Text = string.Format(romPlms.SeedFileString, parsedSeed);
                var randomizerV11 = new RandomizerV11(parsedSeed, romPlms, log);
                randomizerV11.CreateRom(filenameV11.Text);

                var outputString = new StringBuilder();

                outputString.AppendFormat("Done!{0}{0}{0}Seed: ", Environment.NewLine);
                outputString.AppendFormat(romPlms.SeedFileString, parsedSeed);
                outputString.AppendFormat(" ({0} Difficulty){1}{1}", romPlms.DifficultyName, Environment.NewLine);

                WriteOutputV11(outputString.ToString());
            }

            Settings.Default.CreateSpoilerLog = createSpoilerLog.Checked;
            Settings.Default.RandomizerDifficulty = randomizerDifficulty.SelectedItem.ToString();
            Settings.Default.Save();
        }

        private void ClearOutputV11()
        {
            outputV11.Text = "";
        }

        private void WriteOutputV11(string text)
        {
            outputV11.Text += text;
        }

        private void browseV11_Click(object sender, EventArgs e)
        {
            var info = new FileInfo(Regex.Replace(filenameV11.Text, "<.*>", ""));
            var saveFileDialog = new SaveFileDialog { Filter = "All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, InitialDirectory = info.DirectoryName, FileName = info.Name };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filenameV11.Text = saveFileDialog.FileName;
                MessageBox.Show("Remember to hit \"create\" to create the rom.", "Remember to create the rom!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void filenameV11_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputFileV11 = filenameV11.Text;
            Settings.Default.Save();
        }

        private void controlsV11_Click(object sender, EventArgs e)
        {
            var controlsDialog = new Controls();
            controlsDialog.ShowDialog();
        }

        private void controls_Click(object sender, EventArgs e)
        {
            var controlsDialog = new Controls();
            controlsDialog.ShowDialog();
        }

        private void filename_Leave(object sender, EventArgs e)
        {
            var senderText = (TextBox) sender;

            if (!senderText.Text.Contains("."))
            {
                senderText.Text += ".sfc";
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(null, string.Format("https://gitreports.com/issue/Dessyreqt/smrandomizer?issue_title=[v{0}]%20Anonymous%20Issue&details=[v{0}]%0A%0A", RandomizerVersion.CurrentDisplay));
        }
    }
}
