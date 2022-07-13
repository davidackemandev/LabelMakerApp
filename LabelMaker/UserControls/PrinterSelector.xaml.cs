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
        public string LabelSize
        {
            get { return (string)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly DependencyProperty LabelSizeProperty =
            DependencyProperty.Register("LabelSize", typeof(string), typeof(PrinterSelector), new PropertyMetadata(default(string)));


        public PrinterSelector()
        {
            InitializeComponent();
            this.Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (LabelSize == "Serialized3x2")
            {
                SelectedPathTxtBox.Text = Settings1.Default.Printer3x2;
            }
            else if (LabelSize == "NonSerialized2x1")
            {
                SelectedPathTxtBox.Text = Settings1.Default.Printer2x1;
            }
            else if (LabelSize == "Fillable2x1")
            {
                SelectedPathTxtBox.Text = Settings1.Default.Printer2x1Fillable;
            }
        }

        private void SelectedPathTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LabelSize == "Serialized3x2")
            {
                Settings1.Default.Printer3x2 = SelectedPathTxtBox.Text;
                Settings1.Default.Save();
            }
            else if (LabelSize == "NonSerialized2x1")
            {
                Settings1.Default.Printer2x1 = SelectedPathTxtBox.Text;
                Settings1.Default.Save();
            }
            else if (LabelSize == "Fillable2x1")
            {
                Settings1.Default.Printer2x1Fillable = SelectedPathTxtBox.Text;
                Settings1.Default.Save();
            }
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
