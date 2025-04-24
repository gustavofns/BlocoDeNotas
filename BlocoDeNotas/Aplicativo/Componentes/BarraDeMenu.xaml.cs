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
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Interfaces.Utilitarios;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeMenu.xam
    /// </summary>
    public partial class BarraDeMenu : Page, IBarraDeMenu
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IMenuArquivo _menuArquivo;

        public BarraDeMenu(IJanela janela, IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
            _menuArquivo = InicializarMenuArquivo();
        }

        private IMenuArquivo InicializarMenuArquivo()
        {
            return new MenuArquivo(
                new GerenciamentoDeArquivos(_janela, _editorDeDocumentos, new CaixaDeDialogodeArquivos(), new Excecoes(), this),
                new GerenciamentoDeJanelas(_janela)
            );
        }

        // Menu Arquivo
        private void NovaJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.NovaJanela();
        private void FecharJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharJanela();
        private void AbrirArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.AbrirArquivo();
        private void SalvarArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivo();
        private void SalvarArquivoComo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivoComo();
        private void FecharArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharArquivo();
        private void Sair_Click(object sender, RoutedEventArgs e) => _menuArquivo.Sair();

        public void HabilitarFecharArquivo(bool fecharArquivo)
        {
            if(fecharArquivo)
            {
                FecharArquivo.IsEnabled = true;
            }
            else
            {
                FecharArquivo.IsEnabled = false;
            }
        }

        // Menu Editar

        // Menu Exibir
    }
}
