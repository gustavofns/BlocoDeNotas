using System;
using System.Collections.Generic;
using System.Linq;
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

#pragma warning disable WPF0001

namespace BlocoDeNotas
{
    /// <summary>
    /// Interação lógica para Configuracoes.xam
    /// </summary>
    public partial class Configuracoes : Page
    {
        private MainWindow mainWindow;
        private Editor editor;

        public Configuracoes(MainWindow mainWindow, Editor editor)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.editor = editor;
            mainWindow.Title = "Configurações";
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(editor);
            mainWindow.Title = "Bloco de Notas";
        }
    }
}
