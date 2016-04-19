using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SuperMetroidRandomizer.Properties;

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
        public static string Version = "20P5";

        public MainForm()
        {
            InitializeComponent();
        }

        private void RunCheckUpdate()
        {
            checkUpdateThread = new Thread(CheckUpdate);
            checkUpdateThread.SetApartmentState(ApartmentState.STA);
            checkUpdateThread.Start();
        }

        private void CheckUpdate()
        {
            try
            {
                var response = GetResponse("https://smrandomizer.codeplex.com/");

                if (string.IsNullOrWhiteSpace(response))
                    return;

                var pattern = "<TD>Super Metroid Randomizer v(?<version>\\S+) </TD>";
                var match = Regex.Match(response, pattern);

                if (match.Success)
                {
                    var currentVersion = match.Groups["version"].Value;
                    int versionNum;
                    int currentVersionNum;

                    if (int.TryParse(Version, out versionNum) && int.TryParse(currentVersion, out currentVersionNum))
                    {
                        if (int.Parse(Version) < int.Parse(currentVersion))
                        {
                            var result =
                                MessageBox.Show(
                                    string.Format(
                                        "You have v{0} and the current version is v{1}. Would you like to update?",
                                        Version,
                                        currentVersion), "Version Update", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                                Help.ShowHelp(null, "https://smrandomizer.codeplex.com/");
                        }
                    }
                    else
                    {
                        if (Version != currentVersion)
                        {
                            var result =
                                MessageBox.Show(
                                    string.Format(
                                        "You have v{0} and the current version is v{1}. Would you like to update?",
                                        Version, currentVersion), "Version Update", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                                Help.ShowHelp(null, "https://smrandomizer.codeplex.com/");
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                // check for update failed, do nothing here
            }
        }

        private static string GetResponse(string address)
        {
            if (!address.Contains("smrandomizer.codeplex.com"))
                return "";

            var webBrowser = new WebBrowser {ScrollBarsEnabled = false, ScriptErrorsSuppressed = true};
            webBrowser.Navigate(address);
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            return webBrowser.Document.Body.InnerHtml;
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
            var info = new FileInfo(outputFilename.Text.Replace("<seed>", ""));
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
            Text = string.Format("Super Metroid Randomizer v{0}", Version);
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
                difficulty = RandomizerDifficulty.Easy;
            }
            else if (seedText.ToUpper().Contains("M"))
            {
                randomizerDifficulty.SelectedItem = "Masochist";
                seedText = seedText.ToUpper().Replace("M", "");
                difficulty = RandomizerDifficulty.Hard;
            }
            else
            {
                randomizerDifficulty.SelectedItem = "Speedrunner";
                seedText = seedText.ToUpper().Replace("S", "");
                difficulty = RandomizerDifficulty.Normal;
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
                    log = new RandomizerLog(seedV11.Text);
                }

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
            var info = new FileInfo(filenameV11.Text.Replace("<seed>", ""));
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

        private void randomizerDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            seedV11.Text = "";
            if (randomizerDifficulty.SelectedItem.ToString() == "Easy")
            {
                seedV11.Text = "♥♥";
            }
            if (randomizerDifficulty.SelectedItem.ToString() == "Hard")
            {
                seedV11.Text = "♦♦";
            }
        }
    }
}
