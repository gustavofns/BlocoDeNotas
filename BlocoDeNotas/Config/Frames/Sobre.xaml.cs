using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static System.Net.WebRequestMethods;

#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8603

namespace BlocoDeNotas.Config.Frames
{
    /// <summary>
    /// Interação lógica para Sobre.xam
    /// </summary>
    public partial class Sobre : Page
    {
        // Construtor da classe
        public Sobre()
        {
            InitializeComponent();
        }

        // Eventos de carregamento da página
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            versaoProduto.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            devNome.Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            osNome.Text = ObterOS();
            osVersao.Text = ObterVersao();
            osBuild.Text = ObterBuild();
            netVersion.Text = Environment.Version.ToString();
        }

        // Obtém o nome do sistema operacional
        private string ObterOS()
        {
            string os = string.Empty;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                os = key.GetValue("ProductName").ToString();
            }

            if (Environment.OSVersion.Version.Build >= 22000)
            {
                os = os.Replace(os.Substring(0, 10), "Windows 11");
            }

            return os;
        }

        // Obtém a versão do sistema operacional
        private string ObterVersao()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                return key.GetValue("DisplayVersion").ToString();
            }
        }

        // Obtém a build do sistema operacional
        private string ObterBuild()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                return key.GetValue("LCUVer").ToString().Remove(0, 5);
            }
        }

        // Navega até o link do GitHub do projeto
        private void Github_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var link = sender as Hyperlink;
            var abrirLink = link.NavigateUri.ToString();

            Process.Start(new ProcessStartInfo(abrirLink)
            {
                UseShellExecute = true
            });

            e.Handled = true;
        }

        private void sobreSoftwareExpander_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
   
            bool isExpanded = (sender as Expander).IsExpanded;
            if (isExpanded) 
            {
                sobreSoftwareRow.Height = new GridLength(180);
            }
        }

        private void sobreSoftwareExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            bool isCollapsed = !(sender as Expander).IsExpanded;
            if (isCollapsed)
            {
                sobreSoftwareRow.Height = new GridLength(56);
            }
        }

        private void GitHub_Click(object sender, RoutedEventArgs e)
        {
            var link = "https://github.com/gustavofns/BlocoDeNotas";
            Process.Start(new ProcessStartInfo(link)
            {
                UseShellExecute = true
            });
        }
    }
}
