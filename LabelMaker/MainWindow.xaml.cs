using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Printing;

namespace LabelMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new MainPage();
            MainPageButton.Visibility = Visibility.Collapsed;
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new SettingsPage();
            SettingsPageButton.Visibility = Visibility.Collapsed;
            MainPageButton.Visibility = Visibility.Visible;
        }
        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MainPage();
            SettingsPageButton.Visibility = Visibility.Visible;
            MainPageButton.Visibility = Visibility.Collapsed;
        }

    }
}
