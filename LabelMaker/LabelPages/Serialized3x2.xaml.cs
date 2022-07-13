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
        private string ModelNumber = "";
        private string SerialNumber = "";
        private string Description = "";
        
        public Serialized3x2()
        {
            InitializeComponent();

            _products = ModularFunctions.ReadCSV(Settings1.Default.PathToCSV3x2).ToArray();

            ModelNumberInput.ItemsSource = _products;
        }

        private void SerialNumberInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SerialNumber = SerialNumberInput.Text;
            SerialNumberOutput.Text = SerialNumberBarcode.Code = SerialNumber;
        }

        private void ModelNumberInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelNumber = ((ComboBox)sender).SelectedValue.ToString()!;
            ModelNumberOutput.Text = ModelNumber;
            ModelNumberBarcode.Code = ModelNumber;
            Description = _products.First(product => product.ModelNumber == ModelNumber).Description;
            ModelDescriptionOutput.Text = Description;
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            ModularFunctions.SaveCSV("3x2_serialized", ModelNumber, SerialNumber, Description);
            PrintFunctions.Print(Settings1.Default.Printer3x2, LabelTemplate);
        }
    }
}
