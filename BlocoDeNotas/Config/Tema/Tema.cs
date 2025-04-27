using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlocoDeNotas.Properties;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Config.Tema
{
    public class Tema
    {
        public static void AplicarTema()
        {
            switch (Settings.Default.tema)
            {
                case "Claro": // Não implementado
                case "Escuro": // Não implementado
                case "Sistema": //Não implementado
                default:
                    Application.Current.ThemeMode = ThemeMode.None;
                    break;
            }
        }

        public static void SalvarTema(string tema)
        {
            //Settings.Default.tema = tema;
            //Settings.Default.Save();
            AplicarTema();
        }
    }
}
