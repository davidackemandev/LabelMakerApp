using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
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
using static LabelMaker.ModularFunctions;

namespace LabelMaker.LabelPages
{
    /// <summary>
    /// Interaction logic for _2x1_nonserialized.xaml
    /// </summary>
    public partial class NonSerialized2x1 : Page
    {
        private Product[] _products;
        public NonSerialized2x1()
        {
            InitializeComponent();
            _products = ModularFunctions.ReadCSV(Settings1.Default.PathToCSV2x1).ToArray();
            ModelNumberInput.ItemsSource = _products;
        }
        
        private void ModelNumberInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string model = ((ComboBox)sender).SelectedValue.ToString()!;
            ModelNumberOutput.Text = model;
            ModelNumberBarcode.Code = model;
            string description = _products.First(product => product.ModelNumber == model).Description;
            ModelDescriptionOutput.Text = description.Trim('"');
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintFunctions.Print(Settings1.Default.Printer2x1, LabelTemplate);
        }
    }
}
