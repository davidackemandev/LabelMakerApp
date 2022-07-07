using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Printing;
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
    /// Interaction logic for PrinterSelector.xaml
    /// </summary>
    public partial class PrinterSelector : UserControl
    {
        public PrinterSelector()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new System.Windows.Controls.PrintDialog();
            PrintDialog dialog = new PrintDialog();
            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SelectedPathTxtBox.Text = dialog.PrintQueue.FullName;
            }
        }
    }
}
