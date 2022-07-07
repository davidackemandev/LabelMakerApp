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
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new();
            if (printDlg.ShowDialog() == true)
            {

                Transform originalScale = LabelTemplate.LayoutTransform;
                Size originalSize = new Size(LabelTemplate.Width, LabelTemplate.Height);
                LabelTemplate.Arrange(new Rect(new Point(0, 0), new Size(LabelTemplate.Width, LabelTemplate.Height)));
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
