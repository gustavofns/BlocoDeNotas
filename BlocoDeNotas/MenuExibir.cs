using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Application = System.Windows.Application;

namespace BlocoDeNotas
{
    public class MenuExibir
    {
        MainWindow mainWindow;
        Editor editor;

        public MenuExibir(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
        }

        public void BarraDeStatus()
        {
            if (editor.textoBarraStatusMenu.Text.ToString() == "Ocultar a barra de status")
            {
                editor.fonteMenu.Visibility = Visibility.Visible;
                editor.separadorFonte.Visibility = Visibility.Visible;
                editor.iconeBarraStatusMenu.FontFamily = new FontFamily("Segoe Fluent Icons");
                editor.iconeBarraStatusMenu.Text = "\uE90E";
                editor.textoBarraStatusMenu.Text = "Mostrar a barra de status";
                editor.barraStatus.Height = new GridLength(0);
            }
            else
            {
                editor.fonteMenu.Visibility = Visibility.Collapsed;
                editor.separadorFonte.Visibility = Visibility.Collapsed;
                editor.iconeBarraStatusMenu.FontFamily = new FontFamily("Segoe Fluent Icons");
                editor.iconeBarraStatusMenu.Text = "\uE90E";
                editor.textoBarraStatusMenu.Text = "Ocultar a barra de status";
                editor.barraStatus.Height = new GridLength(36);
            }
        }
    }
}
