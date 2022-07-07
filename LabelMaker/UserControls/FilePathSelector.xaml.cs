using System;
using System.Collections.Generic;
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

namespace LabelMaker.UserControls
{
    /// <summary>
    /// Interaction logic for FilePathSelector.xaml
    /// </summary>
    public partial class FilePathSelector : UserControl
    {
        public string FilePathLabelSize
        {
            get { return (string)GetValue(FilePathLabelSizeProperty); }
            set { SetValue(FilePathLabelSizeProperty, value); }
        }

        public static readonly DependencyProperty FilePathLabelSizeProperty =
            DependencyProperty.Register("FilePathLabelSize", typeof(string), typeof(PrinterSelector), new PropertyMetadata(default(string)));

        public FilePathSelector()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (FilePathLabelSize == "Serialized3x2")
            {
                SelectedPathTxtBox.Text = Settings1.Default.PathToCSV3x2;
            }
            else if (FilePathLabelSize == "NonSerialized2x1")
            {
                SelectedPathTxtBox.Text = Settings1.Default.PathToCSV2x1;
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".csv";
            openFileDlg.Filter = "(.csv)|*.csv";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                SelectedPathTxtBox.Text = openFileDlg.FileName;
            }
        }

        private void SelectedPathTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilePathLabelSize == "Serialized3x2")
            {
                Settings1.Default.PathToCSV3x2 = SelectedPathTxtBox.Text;
                Settings1.Default.Save();
            }
            else if (FilePathLabelSize == "NonSerialized2x1")
            {
                Settings1.Default.PathToCSV2x1 = SelectedPathTxtBox.Text;
                Settings1.Default.Save();
            }
        }
    }
}
