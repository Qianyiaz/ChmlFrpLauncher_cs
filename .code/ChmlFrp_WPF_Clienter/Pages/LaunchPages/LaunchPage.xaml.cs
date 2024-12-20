﻿using IniParser;
using IniParser.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace ChmlFrp_WPF_Clienter.Pages
{
    /// <summary>
    /// Lógica de interacción para HomePage.xaml
    /// </summary>
    public partial class LaunchPage : Page
    {
        //private string directoryPath;
        private string frpPath;
        private string frpIniPath;
        //private string frpExePath;
        //private string setupIniPath;
        //private string temp_path;
        //private string temp_api_path;
        private string cflPath;
        //private string pictures_path;

        public LaunchPage()
        {
            InitializeComponent();
            ClienterClass ClienterClass = new ClienterClass();
            //directoryPath = ClienterClass.DirectoryPath();
            cflPath = ClienterClass.CFLPath();
            frpPath = ClienterClass.FrpPath();
            frpIniPath = ClienterClass.FrpIniPath();
            //frpExePath = ClienterClass.FrpExePath();
            //setupIniPath = ClienterClass.SetupIniPath();
            //temp_path = ClienterClass.Temp_path();
            //temp_api_path = ClienterClass.Temp_api_path();
            //pictures_path = ClienterClass.Pictures_path();
        }


        int i = 0;

        private void Launch(object sender, RoutedEventArgs e)
        {
            LaunchButton.Click -= Launch;
            if (!File.Exists(frpIniPath) && !File.Exists(frpPath))
            {
                LaunchButton.Content = "未找到配置文件";
                return;
            }
            //创建ini实例
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(frpIniPath);
            data = parser.ReadFile(frpIniPath);
            LaunchButton.Content = "正在启动中...";
            if (i == 5) { i = 0; }
            i++; string logs = Path.Combine(cflPath, i + ".logs");
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + frpPath + " -c " + frpIniPath + " >" + logs + " 2>&1")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();
                LaunchButton.Content = "点击关闭 frpc";
                LaunchButton.Click += Killfrp;
            }
            //kongzitaNavigation.Navigate(new System.Uri("Pages/NotesPage.xaml", UriKind.RelativeOrAbsolute));
        }
        static bool IsProcessRunning(string processName, int count)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length >= count;
        }
        private void Killfrp(object sender, RoutedEventArgs e)
        {
            LaunchButton.Click -= Killfrp;
            if (!IsProcessRunning("frpc", 0))
            {
                LaunchButton.Content = "启动 frpc";
                LaunchButton.Click += Launch;
                return;
            }
            string name = "frpc";
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            LaunchButton.Content = "启动 frpc";
            LaunchButton.Click += Launch;
        }
    }
}
