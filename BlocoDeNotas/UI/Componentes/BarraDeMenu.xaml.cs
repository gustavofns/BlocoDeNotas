using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;
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
using System.Windows.Interop;
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
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IMenuArquivo _menuArquivo;
        private readonly IMenuEditar _menuEditar;

        public BarraDeMenu(IEditorDeDocumentos editorDeDocumentos, IMenuArquivo menuArquivo , IMenuEditar menuEditar)
        {
            InitializeComponent();
            _editorDeDocumentos = editorDeDocumentos;
            _menuArquivo = menuArquivo;
            _menuEditar = menuEditar;
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


        // Menu Editar
        private void DesfazerMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Desfazer();
        private void RefazerMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Refazer();
        private void RecortarMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Recortar();
        private void CopiarMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Copiar();
        private void ColarMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Colar();
        private void ExcluirMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.Excluir();
        private void InserirHoraAtualMenu_Click(object sender, RoutedEventArgs e) => _menuEditar.HoraAtual();
        private void InserirDataAtual_Click(object sender, RoutedEventArgs e) => _menuEditar.DataAtual();
        private void InserirDataeHoraAtual_Click(object sender, RoutedEventArgs e) => _menuEditar.DataEHoraAtual();
        private void SelecionarTudo_Click(object sender, RoutedEventArgs e) => _menuEditar.SelecionarTudo();
    }
}
