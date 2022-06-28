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

            ModelNumberInput.ItemsSource = ReadCSV();
        }
        public IEnumerable<Product> ReadCSV()
        {
            string[] lines = File.ReadAllLines(@"modelsdata.csv");

            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                return new Product(data[0], data[1]);
            });
        }

        //public function to get row by model number string

        // START EVENTS
        string SerialNumberValue;
        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            string SerialNumberValue;
            if (!string.IsNullOrWhiteSpace(SerialNumberInput.Text) && !string.IsNullOrWhiteSpace(ModelNumberInput.Text))
            {
                SerialNumberValue = ModelNumberInput.Text;
            }
        }

        private void SerialNumberInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            SerialNumberOutput.Text = SerialNumberInput.Text;
        }

        private void ModelNumberInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelNumberOutput.Text = ((ComboBox)sender).SelectedValue.ToString();
        
        }

    public class Product
    {
        public string ModelNumber { get; set; }
        public string Description { get; set; }

        public Product(string modelNumber, string description)
        {
            ModelNumber = modelNumber;
            Description = description;
        }
       
    }
    }
}
