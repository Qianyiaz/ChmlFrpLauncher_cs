﻿/*
//                            _ooOoo_  
//                           o8888888o  
//                           88" . "88  
//                           (| -_- |)  
//                            O\ = /O  
//                        ____/`---'\____  
//                      .   ' \\| |// `.  
//                       / \\||| : |||// \  
//                     / _||||| -:- |||||- \  
//                       | | \\\ - /// | |  
//                     | \_| ''\---/'' | |  
//                      \ .-\__ `-` ___/-. /  
//                   ___`. .' /--.--\ `. . __  
//                ."" '< `.___\_<|>_/___.' >'"".  
//               | | : `- \`.;`\ _ /`;.`/ - ` : | |  
//                 \ \ `-. \_ __\ /__ _/ .-` / /  
//         ======`-.____`-.___\_____/___.-`____.-'======  
//                            `=---='  
//  
//         .............................................  
//                  佛祖保佑             永无BUG 
//          佛曰:  
//                  写字楼里写字间，写字间里程序员；  
//                  程序人员写程序，又拿程序换酒钱。  
//                  酒醒只在网上坐，酒醉还来网下眠；  
//                  酒醉酒醒日复日，网上网下年复年。  
//                  但愿老死电脑间，不愿鞠躬老板前；  
//                  奔驰宝马贵者趣，公交自行程序员。  
//                  别人笑我忒疯癫，我笑自己命太贱；  
//                  不见满街漂亮妹，哪个归得程序员？
*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace ChmlFrpLauncher_cs
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LaunchPageButton.SetValue(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9")));
            LaunchPageButton.SetValue(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1276DB")));
            PagesNavigation.Navigate(new Uri("Pages/LaunchPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdLaunchPage_Click(object sender, RoutedEventArgs e)
        {
            ChmlfrpPageButton.SetValue(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1276DB")));
            ChmlfrpPageButton.SetValue(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9")));
            LaunchPageButton.SetValue(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9")));
            LaunchPageButton.SetValue(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1276DB")));
            PagesNavigation.Navigate(new Uri("Pages/LaunchPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdChmlfrpPage_Click(object sender, RoutedEventArgs e)
        {
            LaunchPageButton.SetValue(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1276DB")));
            LaunchPageButton.SetValue(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9")));
            ChmlfrpPageButton.SetValue(Button.BackgroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9")));
            ChmlfrpPageButton.SetValue(Button.ForegroundProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1276DB")));
            PagesNavigation.Navigate(new Uri("Pages/ChmFlrp.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
