using Microsoft.Win32;
using System.Diagnostics;
using System.Management;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
            var os = string.Empty;

            ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject managementObject in managementClass.GetInstances())
            {
                os = managementObject["Caption"].ToString();
                break;
            }
            return os.ToString();
        }

        // Obtém a versão do sistema operacional
        private string ObterVersao()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                return key.GetValue("DisplayVersion").ToString();
            }
        }

        // Obtém a build do sistema operacional
        private string ObterBuild()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion"))
            {
                return key.GetValue("LCUVer").ToString().Remove(0,5);
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
    }
}
