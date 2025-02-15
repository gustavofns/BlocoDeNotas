using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Config
{
    public class Tema
    {
        private string tema;

        public Tema(string tema)
        {
            this.tema = tema;
        }

        // Muda o tema
        public void MudarTema()
        {
            try
            {
                switch (tema)
                {
                    case "Claro":
                        Application.Current.ThemeMode = ThemeMode.Light;
                        break;
                    case "Escuro":
                        Application.Current.ThemeMode = ThemeMode.Dark;
                        break;
                    default:
                        Application.Current.ThemeMode = ThemeMode.System;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao mudar o tema!!!",
                    "Bloco de notas" , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Salva o tema
        public void SalvarTema()
        {
            try
            {
                switch (tema)
                {
                    case "Claro":
                        break;
                    case "Escuro":
                        break;
                    default:
                        break;
                }
                MudarTema();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar o tema!!!",
                    "Bloco de notas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}