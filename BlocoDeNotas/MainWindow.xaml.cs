using System.Text;
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
        // Atributos da classe
        private StringBuilder documento;
        private string arquivo = string.Empty;
        private bool textoModificado = false;

        // Getters e Setters
        public StringBuilder Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Arquivo
        {
            get { return arquivo; }
            set { arquivo = value; }
        }


        public bool TextoModificado
        {
            get { return textoModificado; }
            set { textoModificado = value; }
        }

        // Construtor da classe
        public MainWindow()
        {
            VerificarOS();
            InitializeComponent();
            documento = new StringBuilder();
            Main.Navigate(new Editor(this));
        }

        // Move a janela do aplicativo
        public void MoverJanela(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /* 
         * Verifica a versão do sistema operacional
         * - Removido o suporte para Windows 11 21H2 (25/02/2025)
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