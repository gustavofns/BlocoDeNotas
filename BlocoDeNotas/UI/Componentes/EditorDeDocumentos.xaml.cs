using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.CodeDom;
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

namespace BlocoDeNotas.UI.Componentes
{
    /// <summary>
    /// Interação lógica para EditorDeDocumentos.xam
    /// </summary>
    public partial class EditorDeDocumentos : UserControl, IEditorDeDocumentos
    {
        public string Arquivo { get; set; }
        public StringBuilder DocumentoOriginal { get; set; }
        public TextBox Documento { get; private set; }

        public EditorDeDocumentos()
        {
            InitializeComponent();
            Arquivo = string.Empty;
            DocumentoOriginal = new StringBuilder();
            Documento = DocumentoTextBox;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DocumentoTextBox.Focus();
        }
    }
}
