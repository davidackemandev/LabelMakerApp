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
    /// Interaction logic for Fillable2x1.xaml
    /// </summary>
    public partial class Fillable2x1 : Page
    {
        public Fillable2x1()
        {
            InitializeComponent();
        }

        private void ModelNumberInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelNumberOutput.Text = ModelNumberInput.Text;
            ModelNumberBarcode.Code = ModelNumberInput.Text;
        }

        private void ModelDescriptionInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelDescriptionOutput.Text = ModelDescriptionInput.Text;
        }
        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintFunctions.Print(Settings1.Default.Printer2x1, LabelTemplate);
        }
    }
}

