using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

#pragma warning disable WPF0001

namespace BlocoDeNotas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Construtor da classe
        public MainWindow()
        {
            VerificarOS();
            CarregarTema();
            InitializeComponent();
            MudarTela(new Editor(this));
        }

        // Verifica a versão do sistema operacional
        public void VerificarOS()
        {
            if (Environment.OSVersion.Version.Build < 20000)
            {
                MessageBox.Show("Este aplicativo não é compatível com a versão do seu sistema operacional.",
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            return;
        }

        // Muda a tela do aplicativo
        public void MudarTela(Page page)
        {
            frame.Navigate(page);
        }

        // Move a janela do aplicativo
        public void MoverJanela(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // Carregar Tema
        public void CarregarTema()
        {
            Config.Tema tema = new Config.Tema("Sistema");
            tema.MudarTema();
        }
    }
}