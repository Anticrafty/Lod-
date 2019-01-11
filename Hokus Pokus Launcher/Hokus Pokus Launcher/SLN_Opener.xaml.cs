using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hokus_Pokus_Launcher
{
    /// <summary>
    /// Interakční logika pro SLN_Opener.xaml
    /// </summary>
    public partial class SLN_Opener : Page
    {
        public sln Project;
        private Frame pretchoziFrame;

        public SLN_Opener()
        {
            InitializeComponent();
        }

        public SLN_Opener(Frame predchozistranka, sln project) : this()
        {
            pretchoziFrame = predchozistranka;
            Project = project;

            try
            {
                READMErator.Text = File.ReadAllText(project.README_location);
            }
            catch
            {

            }
            if (File.Exists(project.exe_location))
            {
                EXElsior.Click += (Open_Exe);
                EXElsior.Content = "Open Exe";
            }
        }

        private void zavrit_SLN(object sender, RoutedEventArgs e)
        {
            pretchoziFrame.Navigate(new Disky(0, pretchoziFrame, null, null, null));
        }
        private void Open_Exe(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Project.exe_location;
            proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Project.exe_location);
            proc.Start();
        }
    }
}
