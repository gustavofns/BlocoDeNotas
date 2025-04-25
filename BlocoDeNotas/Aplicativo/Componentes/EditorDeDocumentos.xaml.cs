using System.Text;
using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Interfaces.Componentes;

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

        private void Page_Loaded(object sender, RoutedEventArgs e) { Documento.Focus(); }
    }
}
