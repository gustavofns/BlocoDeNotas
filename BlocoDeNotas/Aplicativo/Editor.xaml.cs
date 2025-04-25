using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
using BlocoDeNotas.Aplicativo.Componentes;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Utilitarios;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo
{
    /// <summary>
    /// Interação lógica para Editor.xam
    /// </summary>
    public partial class Editor : Page, IEditor
    {
        private readonly IJanela _janela;
        private readonly IBarraDeMenu _barraDeMenu;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IBarraDeStatus _barraDeStatus;

        public Editor(IJanela janela)
        {
            InitializeComponent();
            _janela = janela;
            _editorDeDocumentos = InicializarEditorDeDocumentos();
            _barraDeStatus = InicializarBarraDeStatus();
            _barraDeMenu = InicializarBarraMenu();
            InicializarEventos();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FrameEditorDeDocumentos.Navigate(_editorDeDocumentos);
            FrameBarraDeStatus.Navigate(_barraDeStatus);
            FrameBarraMenu.Navigate(_barraDeMenu);
        }

        private IBarraDeMenu InicializarBarraMenu() { return new BarraDeMenu(_janela, _editorDeDocumentos); }
        private IBarraDeStatus InicializarBarraDeStatus() { return new BarraDeStatus(_editorDeDocumentos.Documento); }
        private IEditorDeDocumentos InicializarEditorDeDocumentos() { return new EditorDeDocumentos(); }

        private void InicializarEventos()
        {
            new EventosDeSelecaoTexto(_barraDeMenu, _editorDeDocumentos.Documento);
            new EventosDoAplicativo(_janela, _editorDeDocumentos, _barraDeMenu);
            new EventosDeAcoesDeDocumentos(_barraDeMenu, _editorDeDocumentos.Documento);
        }
    }
}
