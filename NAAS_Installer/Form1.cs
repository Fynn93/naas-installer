using System.Diagnostics;
using AutoUpdaterDotNET;

namespace NAAS_Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string installdir = AppDomain.CurrentDomain.BaseDirectory;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = $"Change the Install Directory.\nCurrent: {installdir}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialog1.ShowDialog();
            if(fbd == DialogResult.OK && folderBrowserDialog1.SelectedPath != null)
            {
                installdir = folderBrowserDialog1.SelectedPath;
                richTextBox1.Text = $"Change the Install Directory.\nCurrent: {installdir}";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://wiki.fynn93.tech/wiki/New_Adventure_All_Stars/Installation", UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoUpdater.InstalledVersion = new Version("1.0.0.0");
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.DownloadPath = Application.StartupPath + "update";
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Forced;
            var currentDirectory = new DirectoryInfo(installdir);
            if (currentDirectory.Parent != null)
            {
                AutoUpdater.InstallationPath = currentDirectory.FullName;
            }
            AutoUpdater.Start("https://api.fynn93.tech/naas/update.xml");
        }
    }
}