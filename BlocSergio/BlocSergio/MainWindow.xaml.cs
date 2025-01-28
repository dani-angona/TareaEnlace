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

namespace BlocSergio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton6_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //fichero.InitialDirectory= @"c:\";
            fichero.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fichero.ShowDialog() == true)
            {
                txtEditor.Text = File.ReadAllText(fichero.FileName);
            }
            else
            {
                MessageBox.Show(" No se ha selecionado NADA", "Nada de nada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Boton7_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ficherito = new SaveFileDialog();
            ficherito.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
            ficherito.InitialDirectory = @"c:\";
            ficherito.AddExtension = true;
            if (ficherito.ShowDialog() == true)
            {
                File.WriteAllText(ficherito.FileName, txtEditor.Text);
                MessageBox.Show(" Guardado ");
            }
            else
            {
                MessageBox.Show(" Cancelado ", "Na de na", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEditor2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
