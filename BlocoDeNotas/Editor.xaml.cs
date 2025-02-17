using BlocoDeNotas.Config;
using BlocoDeNotas.Config.DefinirConfig;
using BlocoDeNotas.Config.Frames;
using BlocoDeNotas.Menu;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#pragma warning disable WPF0001

namespace BlocoDeNotas
{
    /// <summary>
    /// Interação lógica para Editor.xam
    /// </summary>
    public partial class Editor : Page
    {
        // Atributos e objetos
        private MainWindow mainWindow;
        private Eventos eventos;
        private MenuArquivo menuArquivo;
        private MenuEditar menuEditar;
        private MenuExibir menuExibir;
        private MenuFerramentas menuFerramentas;
        private CarregarConfig carregarConfig;
        private Personalizacao personalizacao;
        private string arquivo = String.Empty;
        private StringBuilder documento = new StringBuilder();
        private bool textoModificado = false;

        // Construtor da classe
        public Editor(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            eventos = new Eventos(mainWindow, this);
            menuArquivo = new MenuArquivo(mainWindow, this);
            menuEditar = new MenuEditar(this);
            menuExibir = new MenuExibir(mainWindow, this);
            menuFerramentas = new MenuFerramentas(mainWindow, this);
            carregarConfig = new CarregarConfig(mainWindow, this);
            personalizacao = new Personalizacao(this);
            CarregarConfig();
        }

        // Getters e setters
        public string Arquivo
        {
            get { return arquivo; }
            set { arquivo = value; }
        }

        public StringBuilder Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public bool TextoModificado
        {
            get { return textoModificado; }
            set { textoModificado = value; }
        }

        // Eventos
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            eventos.VerificarAreaDeTransferencia();
            eventos.RegistrarTeclas();
            editorDeTexto.Focus();
        }

        // Carregar Configurações
        public void CarregarConfig()
        {
            personalizacao.MudarTema(Properties.Settings.Default.Tema);
            personalizacao.AplicarCordeFundo("Magenta");
            carregarConfig.ConfigBarraDeStatus(Properties.Settings.Default.BarraDeStatus);
        }

        // Quando ocorre uma mudança no texto
        private void editorDeTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            eventos.AtualizarRotulos();
            eventos.VerificarTextoModificado();
            eventos.AtualizarBarraDeTítulo();
        }

        // Quando o texto é selecionado
        private void editorDeTexto_SelectionChanged(object sender, RoutedEventArgs e)
        {
            eventos.TextoSelecionado();
        }

        // Slider tamanho da fonte na barra de status
        private void SliderTamanhoFonte_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { if (tamanhoFonteLabel != null) menuExibir.SliderMudarFonte((int)e.NewValue); }
        private void Slider_DoubleClick(object sender, MouseButtonEventArgs e) => menuExibir.SliderDuploClick();

        // Atalhos do teclado
        private void AtalhosDoTeclado_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Menu arquivo
            if (e.Key == Key.N && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift)) menuArquivo.NovaJanela();
            if (e.Key == Key.F4 && Keyboard.Modifiers == ModifierKeys.Alt) menuArquivo.FecharJanela();
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control) menuArquivo.AbrirArquivo();
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control) menuArquivo.SalvarArquivo();
            if (e.Key == Key.S && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift)) menuArquivo.SalvarArquivoComo();
            if (e.Key == Key.F4 && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Alt)) menuArquivo.Sair();
            // Menu Editar
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X) menuEditar.Recortar();
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.C) menuEditar.Copiar();
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V) menuEditar.Colar();
            if (e.Key == Key.Delete) menuEditar.Excluir();
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A) menuEditar.SelecionarTudo();
        }

        // Menu Arquivo
        private void NovaJanela_Click(object sender, RoutedEventArgs e) => menuArquivo.NovaJanela();
        private void FecharJanela_Click(object sender, RoutedEventArgs e) => menuArquivo.FecharJanela();
        private void AbrirArquivo_Click(object sender, RoutedEventArgs e) => menuArquivo.AbrirArquivo();
        private void SalvarArquivo_Click(object sender, RoutedEventArgs e) => menuArquivo.SalvarArquivo();
        private void SalvarArquivoComo_Click(object sender, RoutedEventArgs e) => menuArquivo.SalvarArquivoComo();
        private void FecharArquivo_Click(object sender, RoutedEventArgs e) => menuArquivo.FecharArquivo();
        private void Sair_Click(object sender, RoutedEventArgs e) => menuArquivo.Sair();

        // Menu Editar
        private void Recortar_Click(object sender, RoutedEventArgs e) => menuEditar.Recortar();
        private void Copiar_Click(object sender, RoutedEventArgs e) => menuEditar.Copiar();
        private void Colar_Click(object sender, RoutedEventArgs e) => menuEditar.Colar();
        private void Excluir_Click(object sender, RoutedEventArgs e) => menuEditar.Excluir();
        private void SelecionarTudo_Click(object sender, RoutedEventArgs e) => menuEditar.SelecionarTudo();

        // Menu Exibir
        private void BarraDeStatus_Click(object sender, RoutedEventArgs e) => menuExibir.BarraDeStatus();
        private void SliderTamanhoFonteMenu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { if (tamanhoFonteLabel != null) menuExibir.SliderMudarFonteMenu((int)e.NewValue); }

        // Ferramentas barra de menu
        private void MiniBlock_Click(object sender, RoutedEventArgs e) => new MiniBloco(mainWindow, this).Show();
        private void Config_Click(object sender, RoutedEventArgs e) => mainWindow.MudarTela(new Configuracoes(mainWindow, this));
    }
}
