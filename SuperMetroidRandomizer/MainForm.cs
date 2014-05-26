using System;
using System.Collections;
using System.IO;
using System.Linq;
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

        public MainForm()
        {
            InitializeComponent();
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
                if (randomizerV10.RequiresSuitless())
                {
                    WriteOutput(string.Format("{0}Warning: Seed requires suitless Maridia!{0}{0}", Environment.NewLine));
                }
                else
                {
                    WriteOutput(string.Format("{0}Seed does not require suitless Maridia.{0}{0}", Environment.NewLine));
                }

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
        }

        private void createV11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(seedV11.Text))
                seedV11.Text = string.Format("{0:0000000}", (new Random()).Next(10000000));

            ClearOutputV11();
            
            int parsedSeed;

            if (!int.TryParse(seedV11.Text, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutputV11("Seed must be numeric or blank.");
            }
            else
            {
                var randomizerV11 = new RandomizerV11(parsedSeed);
                randomizerV11.CreateRom(filenameV11.Text);

                WriteOutputV11(string.Format("Done!{1}{1}{1}Seed: {0:0000000}{1}", parsedSeed, Environment.NewLine));
            }
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
            var info = new FileInfo(outputFilename.Text.Replace("<seed>", ""));
            var saveFileDialog = new SaveFileDialog { Filter = "All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, InitialDirectory = info.DirectoryName, FileName = info.Name };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFilename.Text = saveFileDialog.FileName;
                MessageBox.Show("Remember to hit \"create\" to create the rom.", "Remember to create the rom!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void filenameV11_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputFileV11 = filenameV11.Text;
            Settings.Default.Save();
        }
    }
}
