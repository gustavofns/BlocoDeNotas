using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.Janela;
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

namespace BlocoDeNotas.UI.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeMenu.xam
    /// </summary>
    public partial class BarraDeMenu : UserControl, IBarraDeMenu
    {
        private readonly IMenuArquivo _menuArquivo;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public BarraDeMenu(IMenuArquivo menuArquivo, IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _menuArquivo = menuArquivo;
            _editorDeDocumentos = editorDeDocumentos;
        }

        private void MenuArquivo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
                FecharArquivoMenu.IsEnabled = false;
            else FecharArquivoMenu.IsEnabled = true;
        }

        // Menu Arquivo
        private void AbrirArquivoMenu_Click(object sender, RoutedEventArgs e) => _menuArquivo.AbrirArquivo();
        private void SalvarArquivoMenu_Click(object sender, RoutedEventArgs e) => _menuArquivo.Salvar();
        private void SalvarComoMenu_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarComo();
        private void FecharArquivoMenu_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharArquivo();
        private void SairDoAplicativoMenu_Click(object sender, RoutedEventArgs e) => _menuArquivo.SairDoAplicativo();

    }
}
