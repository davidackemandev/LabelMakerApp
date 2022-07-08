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
    /// Interaction logic for _3x2_serialized.xaml
    /// </summary>
    public partial class Serialized3x2 : Page
    {
        private Product[] _products;
        public Serialized3x2()
        {
            InitializeComponent();

            _products = ModularFunctions.ReadCSV(Settings1.Default.PathToCSV3x2).ToArray();

            ModelNumberInput.ItemsSource = _products;
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            ModularFunctions.SaveCSV("3x2", ModelNumberOutput.Text, SerialNumberInput.Text);
            PrintFunctions.Print(Settings1.Default.Printer3x2, LabelTemplate);
        }

        private void SerialNumberInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SerialNumberOutput.Text = SerialNumberInput.Text;
            SerialNumberBarcode.Code = SerialNumberInput.Text;
        }

        private void ModelNumberInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string model = ((ComboBox)sender).SelectedValue.ToString()!;
            ModelNumberOutput.Text = model;
            ModelNumberBarcode.Code = model;
            string description = _products.First(product => product.ModelNumber == model).Description;
            ModelDescriptionOutput.Text = description.Trim('"');
        }
    }
}
