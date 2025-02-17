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
        private MainWindow mainWindow;
        private Editor editor;
        private Config.Frames.Tema tema;

        public Configuracoes(MainWindow mainWindow, Editor editor)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.editor = editor;
            tema = new Config.Frames.Tema(editor);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.Title = "Configurações";
            frameConfig.NavigationService.Navigate(tema);
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(editor);
            mainWindow.Title = "Bloco de Notas";
        }

        private void Config_Selection(object sender, SelectionChangedEventArgs e)
        {
            string config = string.Empty;

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

            switch (config)
            {
                case "Tema":
                    frameConfig.NavigationService.Navigate(tema);
                    break;
                case "Sobre":
                    frameConfig.NavigationService.Navigate(new Config.Frames.Sobre());
                    break;
            }
        }
    }
}
