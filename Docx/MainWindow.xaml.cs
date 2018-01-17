using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Docx
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void saveClick(object sender,RoutedEventArgs args)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XPS файлы (*.xps)|*.xps";

            bool? isOk=dialog.ShowDialog();
            if (isOk != null && isOk.Value)
            {
                using(XpsDocument document=new XpsDocument(dialog.FileName, FileAccess.Write))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(document);
                    writer.Write(doc);
                } 
            }
        }

        public void loadClick(object sender, RoutedEventArgs args)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XPS файлы (*.xps)|*.xps";

            bool? isOk = dialog.ShowDialog();
            if (isOk != null && isOk.Value)
            {
                using (XpsDocument document = new XpsDocument(dialog.FileName, FileAccess.Read))
                {
                    container.Document = document.GetFixedDocumentSequence();
                }
            }
        }
    }
}
