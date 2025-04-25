using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Menu.ItensMenuEditar;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeMenu.xam
    /// </summary>
    public partial class BarraDeMenu : Page, IBarraDeMenu
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly MenuArquivo _menuArquivo;
        private readonly MenuEditar _menuEditar;
        public MenuItem FecharDocumentoMenu { get; set; }
        public MenuItem DesfazerMenu { get; set; }
        public MenuItem RefazerMenu { get; set; }
        public MenuItem RecortarMenu { get; set; }
        public MenuItem CopiarMenu { get; set; }
        public MenuItem ColarMenu { get; set; }
        public MenuItem ExcluirMenu { get; set ; }

        public BarraDeMenu(IJanela janela, IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
            _menuArquivo = InicializarMenuArquivo();
            _menuEditar = InicializarMenuEditar();
            FecharDocumentoMenu = FecharArquivo;
            DesfazerMenu = Desfazer;
            RefazerMenu = Refazer;
            RecortarMenu = Recortar;
            CopiarMenu = Copiar;
            ColarMenu = Colar;
            ExcluirMenu = Excluir; 
        }

        private MenuArquivo InicializarMenuArquivo()
        {
            return new MenuArquivo(
                new GerenciamentoDeArquivos(_editorDeDocumentos, new CaixaDeDialogodeArquivos(), 
                    new OperacoesComArquivos(_editorDeDocumentos, new Excecoes())),
                new GerenciamentoDeJanelas(_janela)
            );
        }

        private MenuEditar InicializarMenuEditar()
        {
            return new MenuEditar(
                new AcoesDocumento(_editorDeDocumentos.Documento),
                new TextoSelecionado(_editorDeDocumentos.Documento),
                new AreaDeTransferencia(_editorDeDocumentos.Documento),
                new DataEHora(_editorDeDocumentos.Documento)
            );
        }



        // Menu Arquivo
        private void NovaJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.NovaJanela();
        private void FecharJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharJanela();
        private void AbrirArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.AbrirArquivo();
        private void SalvarArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivo();
        private void SalvarArquivoComo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivoComo();
        private void FecharArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharArquivo();
        private void Sair_Click(object sender, RoutedEventArgs e) => _menuArquivo.Sair();
        // Menu Editar
        private void Desfazer_Click(object sender, RoutedEventArgs e) => _menuEditar.Desfazer();
        private void Refazer_Click(object sender, RoutedEventArgs e) => _menuEditar.Refazer();
        private void Recortar_Click(object sender, RoutedEventArgs e) => _menuEditar.Recortar();
        private void Copiar_Click(object sender, RoutedEventArgs e) => _menuEditar.Copiar();
        private void Colar_Click(object sender, RoutedEventArgs e) => _menuEditar.Colar();
        private void Excluir_Click(object sender, RoutedEventArgs e) => _menuEditar.Excluir();
        private void SelecionarTudo_Click(object sender, RoutedEventArgs e) => _menuEditar.SelecionarTudo();
        private void Hora_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirHora();
        private void Data_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirData();
        private void HoraeData_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirDataHora();

        // Menu Exibir

    }
}
