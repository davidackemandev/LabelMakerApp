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
        private string ModelNumber = "";
        private string Description = "";
        public Fillable2x1()
        {
            InitializeComponent();
        }

        private void ModelNumberInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelNumber = ModelNumberInput.Text;
            ModelNumberOutput.Text = ModelNumber;
            ModelNumberBarcode.Code = ModelNumber;
        }

        private void ModelDescriptionInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Description = ModelDescriptionInput.Text;
            ModelDescriptionOutput.Text = Description;
        }
        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            ModularFunctions.SaveCSV("2x1_fillable", ModelNumberOutput.Text,"", Description);
            PrintFunctions.Print(Settings1.Default.Printer2x1Fillable, LabelTemplate);
        }
    }
}

