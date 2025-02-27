using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Config.AplicarConfig
{
    public class Tema
    {
        private Editor editor;

        public Tema(Editor editor) 
        {
            this.editor = editor;
        }

        // Define o tema
        public void MudarTema(string tema)
        {
            ThemeMode config;

            switch (tema)
            {
                case "Claro":
                    config = ThemeMode.Light;
                    break;
                case "Escuro":
                    config = ThemeMode.Dark;
                    break;
                default:
                    config = ThemeMode.System;
                    break;
            }

            AplicarConfigTema(config);
        }

        // Aplica a configuração de tema
        private void AplicarConfigTema(ThemeMode config)
        {
            try
            {
                Application.Current.ThemeMode = config;
            }
            catch (Exception) 
            {
                MessageBox.Show("Erro ao aplicar configuração de tema!", 
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        // Salvar Configuração de tema
        public void SalvarConfiguracaoTema(string config)
        {
            Properties.Settings.Default.Tema = config;
            Properties.Settings.Default.Save();
        }
    }
}
