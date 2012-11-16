using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SuperMetroidRandomizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else if (args.Length != 2)
            {
                Console.WriteLine("Usage: SuperMetroidRandomizer.exe <suitless> <filename>");
                Console.WriteLine("<suitless>: can be \"disabled\", \"possible\", or \"forced\".");
                Console.WriteLine("<filename>: The filename. An instance of \"seed\" will be replaced by a seed.");
                Console.WriteLine("Example: SuperMetroidRandomizer.exe disabled \"random <seed>.sfc\"");
            }
            else
            {
                Suitless suitless;
                switch (args[0])
                {
                    case "disabled":
                        suitless = Suitless.Disabled;
                        break;
                    case "possible":
                        suitless = Suitless.Possible;
                        break;
                    case "forced":
                        suitless = Suitless.Forced;
                        break;
                    default:
                        Console.WriteLine("Bad arg for <suitless>.");
                        return;
                }

                var form = new MainForm {IsConsole = true, IsSuitless = suitless, FileName = args[1]};
                form.CreateRom();
            }
        }


    }
}
