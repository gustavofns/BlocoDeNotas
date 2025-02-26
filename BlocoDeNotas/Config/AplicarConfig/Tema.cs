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
            ThemeMode themeMode;

            switch (tema)
            {
                case "Claro":
                    themeMode = ThemeMode.Light;
                    break;
                case "Escuro":
                    themeMode = ThemeMode.Dark;
                    break;
                default:
                    themeMode = ThemeMode.System;
                    break;
            }

            AplicarConfigTema(themeMode);
        }

        private void AplicarConfigTema(ThemeMode themeMode)
        {
            try
            {
                Application.Current.ThemeMode = themeMode;
            }
            catch (Exception) 
            {
                MessageBox.Show("Erro ao aplicar configuração de tema!", 
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        // Salvar Configuração de tema
        public void SalvarConfiguracaoTema(string tema)
        {
            Properties.Settings.Default.Tema = tema;
            Properties.Settings.Default.Save();
        }
    }
}
