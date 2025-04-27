using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Aplicativo.Componentes;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Menu.ItensMenuEditar;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo
{
    /// <summary>
    /// Interação lógica para Editor.xam
    /// </summary>
    public partial class Editor : Page, IEditor
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IBarraDeStatus _barraDeStatus;
        private readonly IMenuArquivo _menuArquivo;
        private readonly IMenuEditar _menuEditar;
        private readonly IBarraDeMenu _barraDeMenu;

        public Editor(IJanela janela)
        {
            InitializeComponent();
            _janela = janela;
            _editorDeDocumentos = InicializarEditorDeDocumentos();
            _barraDeStatus = InicializarBarraDeStatus();
            _menuArquivo = InicializarMenuArquivo();
            _menuEditar = InicializarMenuEditar();
            _barraDeMenu = InicializarBarraMenu();
            InicializarEventos();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FrameEditorDeDocumentos.Navigate(_editorDeDocumentos);
            FrameBarraDeStatus.Navigate(_barraDeStatus);
            FrameBarraMenu.Navigate(_barraDeMenu);
        }

        private IBarraDeMenu InicializarBarraMenu() { return new BarraDeMenu(_menuArquivo, _menuEditar); }
        private IBarraDeStatus InicializarBarraDeStatus() { return new BarraDeStatus(_editorDeDocumentos.Documento); }
        private IEditorDeDocumentos InicializarEditorDeDocumentos() { return new EditorDeDocumentos(); }

        private IMenuEditar InicializarMenuEditar()
        {
            return new MenuEditar(
                new AcoesDocumento(_editorDeDocumentos.Documento),
                new TextoSelecionado(_editorDeDocumentos.Documento),
                new AreaDeTransferencia(_editorDeDocumentos.Documento),
                new DataEHora(_editorDeDocumentos.Documento)
            );
        }

        private IMenuArquivo InicializarMenuArquivo()
        {
            return new MenuArquivo(
                new GerenciamentoDeArquivos(_editorDeDocumentos, new CaixaDeDialogodeArquivos(),
                    new OperacoesComArquivos(_editorDeDocumentos, new Excecoes())),
                new GerenciamentoDeJanelas(_janela)
            );
        }

        private void InicializarEventos()
        {
            new EventosDeSelecaoTexto(_barraDeMenu, _editorDeDocumentos.Documento);
            new EventosDoAplicativo(_janela, _editorDeDocumentos, _barraDeMenu);
            new EventosDeAcoesDeDocumentos(_barraDeMenu, _editorDeDocumentos.Documento);
        }
    }
}
