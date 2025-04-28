using System.ComponentModel;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Config.Tema;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Properties;
using Microsoft.Extensions.DependencyInjection;

namespace BlocoDeNotas
{
    /// <summary>  
    /// Interaction logic for App.xaml  
    /// </summary>  
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Tema.AplicarTema();
            VerificarCompatibilidade();
            IniciarApp(e.Args);
        }

        private void IniciarApp(string[] args)
        {
            var provider = Programa.Dependencias(args);
            var app = provider.GetRequiredService<IJanela>();
            app.MostrarJanela(provider.GetRequiredService<IEditor>());
        }

        private void VerificarCompatibilidade()
        {
            if (Environment.OSVersion.Version.Build < 19041)
            {
                Environment.Exit(0);
            }
            else if (Environment.OSVersion.Version.Build < 22621)
            {
                var resultado = MessageBox.Show(
                    "Este programa não foi projetado para esta versão do Windows. Tem certeza que deseja iniciar?",
                    "Problema de compatibilidade",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (resultado == MessageBoxResult.Yes) return;
                else Environment.Exit(0);
            }
            else return;
        }
    }
}
