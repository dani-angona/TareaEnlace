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
using System;
using System.IO;
using System.Xml.Linq;

namespace TareaEnlace
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

        private void TextChanged_UpdateUI(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            lblNombrePreview.Text = txtNombre.Text;
            lblTelefonoPreview.Text = txtTelefono.Text;


            btnGuardar.IsEnabled = !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                                   !string.IsNullOrWhiteSpace(txtTelefono.Text);
        }


        private void GuardarEnXML(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string telefono = txtTelefono.Text;
            string filePath = "archivo.xml";

            XDocument doc;

            // Si el archivo XML ya existe, lo cargamos; si no, lo creamos
            if (File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Tareas"));
            }


            XElement nuevoArchivo = new XElement("Tarea",
                new XElement("Nombre", nombre),
                new XElement("Telefono", telefono));

            doc.Root.Add(nuevoArchivo);
            doc.Save(filePath);

            MessageBox.Show("Bien hecho", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
