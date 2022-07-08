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

namespace LabelMaker
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LabelPagesFrame.Content = new LabelPages.Serialized3x2();
            LabelSizeComboBox.SelectedIndex = Settings1.Default.ActiveLabelSizeIndex;
        }

        private void LabelSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem LabelSize = (ComboBoxItem)LabelSizeComboBox.SelectedValue;
            var CurrentIndex = LabelSizeComboBox.SelectedIndex;

            if (LabelSize.Content.ToString() == "3x2_serialized"){
                LabelPagesFrame.Content = new LabelPages.Serialized3x2();
                Settings1.Default.ActiveLabelSizeIndex = CurrentIndex;
                Settings1.Default.Save();
            } else if(LabelSize.Content.ToString() == "2.641x1_nonserialized")
            {
                LabelPagesFrame.Content = new LabelPages.NonSerialized2x1();
                Settings1.Default.ActiveLabelSizeIndex = CurrentIndex;
                Settings1.Default.Save();
            }
        }
    }
}
