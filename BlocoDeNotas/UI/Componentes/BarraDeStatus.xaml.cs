using BlocoDeNotas.Interfaces.UI.Componentes;
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

namespace BlocoDeNotas.UI.Componentes
{
    /// <summary>  
    /// Interação lógica para BarraDeStatus.xam  
    /// </summary>  
    public partial class BarraDeStatus : UserControl, IBarraDeStatus
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public BarraDeStatus(IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void linhasColunas_LayoutUpdated(object sender, EventArgs e)
        {
           linhasColunas.Content = $"Linha(s): {_editorDeDocumentos.Linhas} ";
        }
    }
}
