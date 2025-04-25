using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Aplicativo.Componentes
{
    /// <summary>
    /// Interação lógica para EditorDeDocumentos.xam
    /// </summary>
    public partial class EditorDeDocumentos : Page, IEditorDeDocumentos
    {
        public string Arquivo { get; set; }
        public TextBox Documento { get; set; }
        public StringBuilder DocumentoOriginal { get; set; }

        public EditorDeDocumentos()
        {
            InitializeComponent();
            Arquivo = string.Empty;
            DocumentoOriginal = new StringBuilder();
            Documento = EditorDocumento;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Documento.Focus();
        }
    }
}
