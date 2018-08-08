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

namespace ReadTextFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum CyberSymbols  {SHORT, LONG, BREAK };
        CyberSymbols a = CyberSymbols.SHORT;
        OpenFileDialog filedialog;
        public MainWindow()
        {
            InitializeComponent();
            listBox.Items.Add("ENUM A =  " + a);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            filedialog = new OpenFileDialog();
            filedialog.FileOk += ReadTextFile;
            filedialog.Title = "Opening Text File";
            filedialog.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            filedialog.ShowDialog();
        }

        private void ReadTextFile(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string FullPath = filedialog.FileName;
            FileInfo scr = new FileInfo(FullPath);
            string line;
            int length;

            TextReader reader = scr.OpenText();
            line = reader.ReadLine();

            while (line != null)
            {
                length = line.Length;
                listBox.Items.Add("no of chars " + length);
                listBox.Items.Add( line);
                line = reader.ReadLine();
            }
            
            
            reader.Close();
           

        }
    }
}
