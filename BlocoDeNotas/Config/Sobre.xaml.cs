using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8603

namespace BlocoDeNotas.Config
{
    /// <summary>
    /// Interação lógica para Sobre.xam
    /// </summary>
    public partial class Sobre : Page
    {
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
            try
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

                return $"Microsoft {os}";
            }
            catch (Exception)
            {
                return "Informação indisponível";
            }
        }

        // Obtém a versão do sistema operacional
        private string ObterVersao()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    return key.GetValue("DisplayVersion").ToString();
                }
            }
            catch (Exception)
            {
                return "Informação indisponível";
            }
        }

        // Obtém a build do sistema operacional
        private string ObterBuild()
        {
            try
            { 
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    return key.GetValue("LCUVer").ToString().Remove(0, 5);
                }
            }
            catch (Exception)
            {
                return "Informação indisponível";
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
