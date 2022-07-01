﻿using System;
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
        private Product[] _products;

        public MainWindow()
        {
            InitializeComponent();

            _products = ReadCSV().ToArray();
            ModelNumberInput.ItemsSource = _products;
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

        // START EVENTS
        string SerialNumberValue;
        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new();
            if (printDlg.ShowDialog() == true)
            {
                Transform originalScale = LabelTemplate.LayoutTransform;
                Size originalSize = new Size(LabelTemplate.ActualWidth, LabelTemplate.ActualHeight);
                LabelTemplate.Arrange(new Rect(new Point(0, 0), new Size(LabelTemplate.ActualWidth, LabelTemplate.ActualHeight)));
                //printDlg.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.Unknown, 288, 192);
                //printDlg.PrintTicket.PageBorderless = PageBorderless.Borderless;
                printDlg.PrintVisual(LabelTemplate, "Print Label");

                LabelTemplate.LayoutTransform = originalScale;
                LabelTemplate.Measure(originalSize);
                LabelTemplate.Arrange(new Rect(new Point(1, 1), originalSize));
            }
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
            ModelDescriptionOutput.Text = description;
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
