using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace BlocoDeNotas.Menu
{
    /// <summary>
    /// Interação lógica para Configuracoes.xam
    /// </summary>
    public partial class Configuracoes : Page
    {
        // Atributos e objetos
        private MainWindow mainWindow;
        private Editor editor;
        private Config.Frames.Tema tema;

        // Construtor da classe
        public Configuracoes(MainWindow mainWindow, Editor editor)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.editor = editor;
            tema = new Config.Frames.Tema(editor);
        }

        //  Eventos de carragamento da página de configurações
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.Title = "Configurações";
            frameConfig.NavigationService.Navigate(tema);
        }

        // Voltar para o editor
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(editor);
            mainWindow.Title = "Bloco de Notas";
        }

        // Evento de seleção de configuração
        private void Config_Selection(object sender, SelectionChangedEventArgs e)
        {
            int itemSelecionado = ConfigListeview.SelectedIndex;

            // Navega para a página de configuração selecionada
            switch (itemSelecionado)
            {
                case 0:
                    frameConfig.NavigationService.Navigate(tema);
                    break;
                case 1:
                    frameConfig.NavigationService.Navigate(new Config.Frames.Sobre());
                    break;
                default:
                    break;
            }
        }
    }
}
