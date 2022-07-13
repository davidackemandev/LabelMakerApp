using System;
using System.Collections.Generic;
using System.Linq;
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
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace LabelMaker
{
    public class ModularFunctions
    {
        public static void SaveCSV(string size, string model, string serial = "", string descriptionInput = "")
        {
            var dir = "data";
            var file = dir + "/history.csv";

            if (model == null) { model = ""; }

            var date = DateTime.Now.Date.ToString();
            var description = "\"" + descriptionInput + "\"";

            var textWrite = date + "," + 
                            size + "," + 
                            model + "," + 
                            serial + "," +
                            description;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(file))
                File.Create(file);

            using StreamWriter sw = File.AppendText(file);
            sw.WriteLine(textWrite);
        }

        // Using https://github.com/JoshClose/CsvHelper
        public static IEnumerable<Product> ReadCSV(string PathToCSV)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ",",
            };
            using (var reader = new StreamReader(PathToCSV))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Product>().ToList();
            }
            
        }

        public class Product
        {
            public string ModelNumber { get; set; }
            public string Description { get; set; }

        }
    }

    public class PrintFunctions
    {
        public static void Print(string Printer, Border LabelTemplate)
        {
            Transform originalScale = LabelTemplate.LayoutTransform;
            Size originalSize = new Size(LabelTemplate.Width, LabelTemplate.Height);

            try
            {
                PrintDialog printDlg = new();
                printDlg.PrintQueue = new PrintQueue(new PrintServer(), Printer);

                LabelTemplate.Arrange(new Rect(new Point(0, 0), new Size(LabelTemplate.Width, LabelTemplate.Height)));

                printDlg.PrintVisual(LabelTemplate, "Print Label");
            }
            catch (Exception ex)
            {
                //Dialog Fail here
                MessageBox.Show(ex.Message);
            }

            LabelTemplate.LayoutTransform = originalScale;
            LabelTemplate.Measure(originalSize);
            LabelTemplate.Arrange(new Rect(new Point(1, 1), originalSize));
        }
    }
}
