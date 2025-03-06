using BlocoDeNotas.Config;
using BlocoDeNotas.Menu;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

#pragma warning disable WPF0001
#pragma warning disable CS8622

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
        private Config.AplicarConfig.Fonte fonte;
        private Config.AplicarConfig.Tema tema;
        private Config.AplicarConfig.UI ui;

        // Construtor da classe
        public Editor(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            eventos = new Eventos(mainWindow, this);
            menuArquivo = new MenuArquivo(mainWindow, this);
            menuEditar = new MenuEditar(this);
            menuExibir = new MenuExibir(this);
            menuFerramentas = new MenuFerramentas(this);
            fonte = new Config.AplicarConfig.Fonte(this);
            tema = new Config.AplicarConfig.Tema(this);
            ui = new Config.AplicarConfig.UI(this);
            CarregarConfig();
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
            tema.MudarTema(Properties.Settings.Default.Tema);
            fonte.CarregarTamanhoFonte(Properties.Settings.Default.TamanhoFonte);
            menuExibir.CarregarBarraDeStatus(Properties.Settings.Default.BarraDeStatus);
            ui.IconesColoridos(Properties.Settings.Default.UsarUIColorida);
            ui.FerramentasRapidas(Properties.Settings.Default.FerramentasRapidas);
            ui.AplicarConfigUI();
        }

        // Quando ocorre uma mudança no texto
        private void editorDeTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            eventos.AtualizarRotulos();
            eventos.VerificarTextoModificado();
            eventos.AtualizarBarraDeTítulo();
            eventos.VerificarDesfazerRefazer();
        }

        // Quando o texto é selecionado
        private void editorDeTexto_SelectionChanged(object sender, RoutedEventArgs e) => eventos.TextoSelecionado();

        // Slider tamanho da fonte na barra de status
        private void SliderTamanhoFonte_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { if (tamanhoFonteLabel != null) menuExibir.SliderMudarFonte((int)e.NewValue); }
        private void Slider_DoubleClick(object sender, MouseButtonEventArgs e) => menuExibir.SliderDuploClick();

        // Atalhos do teclado
        private void AtalhosDoTeclado_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Menu arquivo
            if (e.Key == Key.N && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift)) { menuArquivo.NovaJanela(); e.Handled = true; }
            if (e.Key == Key.F4 && Keyboard.Modifiers == ModifierKeys.Alt) { menuArquivo.NovaJanela(); e.Handled = true; }
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control) { menuArquivo.AbrirArquivo(); e.Handled = true; }
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control) { menuArquivo.SalvarArquivo(); e.Handled = true; }
            if (e.Key == Key.S && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift)) { menuArquivo.SalvarArquivoComo(); e.Handled = true; }
            if (e.Key == Key.F4 && Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Alt)) { menuArquivo.Sair(); e.Handled = true; }
            // Menu Editar
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z) { menuEditar.Desfazer(); e.Handled = true; }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Y) { menuEditar.Refazer(); e.Handled = true; }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X) { menuEditar.Recortar(); e.Handled = true; }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.C) { menuEditar.Copiar(); e.Handled = true; }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V) { menuEditar.Colar(); e.Handled = true; }
            if (e.Key == Key.Delete) { menuEditar.Excluir(); e.Handled = true; }
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A) { menuEditar.SelecionarTudo(); e.Handled = true; }
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
        private void Desfazer_Click(object sender, RoutedEventArgs e) => menuEditar.Desfazer();
        private void Refazer_Click(object sender, RoutedEventArgs e) => menuEditar.Refazer();
        private void Recortar_Click(object sender, RoutedEventArgs e) => menuEditar.Recortar();
        private void Copiar_Click(object sender, RoutedEventArgs e) => menuEditar.Copiar();
        private void Colar_Click(object sender, RoutedEventArgs e) => menuEditar.Colar();
        private void Excluir_Click(object sender, RoutedEventArgs e) => menuEditar.Excluir();
        private void InserirHora_Click(object sender, RoutedEventArgs e) => menuEditar.InserirHoraAtual();
        private void InserirData_Click(object sender, RoutedEventArgs e) => menuEditar.InserirDataAtual();
        private void InserirDataHora_Click(object sender, RoutedEventArgs e) => menuEditar.InserirDataHoraAtual();
        private void SelecionarTudo_Click(object sender, RoutedEventArgs e) => menuEditar.SelecionarTudo();

        // Menu Exibir
        private void BarraDeStatus_Click(object sender, RoutedEventArgs e) => menuExibir.BarraDeStatus();
        private void SliderTamanhoFonteMenu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { if (tamanhoFonteLabel != null) menuExibir.SliderMudarFonteMenu((int)e.NewValue); }

        // Ferramentas barra de menu
        private void MiniBlock_Click(object sender, RoutedEventArgs e) => new MiniBloco(mainWindow, this).Show();
        private void Config_Click(object sender, RoutedEventArgs e) => mainWindow.Main.Navigate(new Configuracoes(mainWindow, this));
    }
}
