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
            string config = string.Empty;
            // Percorre a lista de configurações
            foreach (StackPanel stackPanel in ConfigListeview.Items)
            {
                if (stackPanel == ConfigListeview.SelectedItem)
                {
                    foreach (var item in stackPanel.Children)
                    {
                        if (item is TextBlock textBlock)
                        {
                            config = textBlock.Text;
                            break;
                        }
                    }
                }
            }
            // Navega para a página de configuração selecionada
            switch (config)
            {
                case "Tema":
                    frameConfig.NavigationService.Navigate(tema);
                    break;
                case "Sobre":
                    frameConfig.NavigationService.Navigate(new Config.Frames.Sobre());
                    break;
                default:
                    MessageBox.Show("Configuração não implementada",
                        "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
