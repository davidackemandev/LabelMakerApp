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
namespace LabelMaker
{
    public class ModularFunctions
    {
        public static void SaveCSV(string size, string model, string serial = "")
        {
            var dir = "data";
            var file = dir + "/history.csv";

            if (model == null) { model = ""; }

            var textWrite = size + "," + model + "," + serial;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!File.Exists(file))
                File.Create(file);

            using StreamWriter sw = File.AppendText(file);
            sw.WriteLine(textWrite);
        }
        public static IEnumerable<Product> ReadCSV(string PathToCSV)
        {
            string[] lines = File.ReadAllLines(PathToCSV);
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            return lines
                .Skip(1)
                .Select(line =>
                {
                    string[] data = CSVParser.Split(line);
                    return new Product(data[0], data[1]);
                }).OrderBy(product => product.ModelNumber);
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

    public class PrintFunctions
    {
        public static void Print(string Printer, Border LabelTemplate)
        {
            PrintDialog printDlg = new();
            printDlg.PrintQueue = new PrintQueue(new PrintServer(), Printer);

            Transform originalScale = LabelTemplate.LayoutTransform;
            Size originalSize = new Size(LabelTemplate.Width, LabelTemplate.Height);
            LabelTemplate.Arrange(new Rect(new Point(0, 0), new Size(LabelTemplate.Width, LabelTemplate.Height)));

            printDlg.PrintVisual(LabelTemplate, "Print Label");

            LabelTemplate.LayoutTransform = originalScale;
            LabelTemplate.Measure(originalSize);
            LabelTemplate.Arrange(new Rect(new Point(1, 1), originalSize));
        }
    }
}
