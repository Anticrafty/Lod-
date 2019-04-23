using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace Either_Mouse
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _NotifikacniIkona;
        private bool _BiEmpty;
        private bool _BiShowed = false;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += Bi_Emptying;

            _NotifikacniIkona = new System.Windows.Forms.NotifyIcon();
            _NotifikacniIkona.DoubleClick += (s, args) => ShowBi();
            _NotifikacniIkona.Icon = Either_Mouse.Properties.Resources.ProsteIkona;
            _NotifikacniIkona.Visible = true;

            VytvorNaklikavaciMenu();
        }
        private void VytvorNaklikavaciMenu()
        {
            _NotifikacniIkona.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _NotifikacniIkona.ContextMenuStrip.Items.Add("UnEmpty").Click += (s, e) => ShowBi();
            _NotifikacniIkona.ContextMenuStrip.Items.Add("Yeet").Click += (s, e) => ThisBiEmpty();
            
        }

        private void ThisBiEmpty()
        {
            Either_Mouse.MainWindow.zarizeninini.SelectedIndex = 0;
            _BiEmpty = true;
            MainWindow.Close();
            _NotifikacniIkona.Dispose();
            _NotifikacniIkona = null;
        }

        private void ShowBi()
        {
            if (_BiShowed)
            {
                MainWindow.Hide();
                _BiShowed = false;
            }
            else
            {
                if (MainWindow.IsVisible)
                {
                    if (MainWindow.WindowState == WindowState.Minimized)
                    {
                        MainWindow.WindowState = WindowState.Normal;
                    }
                    //MainWindow.Activate();
                }
                else
                {
                    MainWindow.Top = najdu_mys().Y - MainWindow.Height;
                    MainWindow.Left = najdu_mys().X - MainWindow.Width;
                    MainWindow.Show();
                    _BiShowed = true;
                }
            }
            
        }

        public Point najdu_mys()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new Point(point.X, point.Y);
        }

        private void Bi_Emptying(object sender, CancelEventArgs e)
        {
            if(!_BiEmpty)
            {
                e.Cancel = true;
                MainWindow.Hide();
            }
        }
    }
}
