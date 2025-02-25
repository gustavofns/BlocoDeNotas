using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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
            InitializeComponent();
            Main.Navigate(new Editor(this));
        }

        // Move a janela do aplicativo
        public void MoverJanela(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /* 
         * Verifica a versão do sistema operacional:
         * - Removido o suporte para Windows 11 21H2
         */
        public void VerificarOS()
        {
            if (!(Environment.OSVersion.Version.Build >= 22621))
            {
                MessageBox.Show("Este aplicativo não é compatível com esta versão do Windows.\n" +
                    "Por favor atualize para Windows 11 22H2 ou superior.",
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
                Close();
            }
            return;
        }
    }
}