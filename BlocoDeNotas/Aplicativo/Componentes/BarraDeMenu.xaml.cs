using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Eventos;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Menu;
using BlocoDeNotas.Menu.ItensMenuArquivo;
using BlocoDeNotas.Menu.ItensMenuEditar;
using BlocoDeNotas.Utilitarios;

namespace BlocoDeNotas.Aplicativo.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeMenu.xam
    /// </summary>
    public partial class BarraDeMenu : Page, IBarraDeMenu
    {
        private readonly IMenuArquivo _menuArquivo;
        private readonly IMenuEditar _menuEditar;
        public MenuItem FecharDocumentoMenu { get { return FecharArquivo; }}
        public MenuItem DesfazerMenu { get { return Desfazer; } }
        public MenuItem RefazerMenu { get { return Refazer; } }
        public MenuItem RecortarMenu { get { return Recortar; } }
        public MenuItem CopiarMenu { get{ return Copiar;} }
        public MenuItem ColarMenu { get { return Colar; } }
        public MenuItem ExcluirMenu { get { return Excluir; } }

        public BarraDeMenu(IMenuArquivo menuArquivo, IMenuEditar menuEditar)
        {
            InitializeComponent();
            _menuArquivo = menuArquivo;
            _menuEditar = menuEditar;
        }

        // Menu Arquivo
        private void NovaJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.NovaJanela();
        private void FecharJanela_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharJanela();
        private void AbrirArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.AbrirArquivo();
        private void SalvarArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivo();
        private void SalvarArquivoComo_Click(object sender, RoutedEventArgs e) => _menuArquivo.SalvarArquivoComo();
        private void FecharArquivo_Click(object sender, RoutedEventArgs e) => _menuArquivo.FecharArquivo();
        private void Sair_Click(object sender, RoutedEventArgs e) => _menuArquivo.Sair();
        // Menu Editar
        private void Desfazer_Click(object sender, RoutedEventArgs e) => _menuEditar.Desfazer();
        private void Refazer_Click(object sender, RoutedEventArgs e) => _menuEditar.Refazer();
        private void Recortar_Click(object sender, RoutedEventArgs e) => _menuEditar.Recortar();
        private void Copiar_Click(object sender, RoutedEventArgs e) => _menuEditar.Copiar();
        private void Colar_Click(object sender, RoutedEventArgs e) => _menuEditar.Colar();
        private void Excluir_Click(object sender, RoutedEventArgs e) => _menuEditar.Excluir();
        private void SelecionarTudo_Click(object sender, RoutedEventArgs e) => _menuEditar.SelecionarTudo();
        private void Hora_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirHora();
        private void Data_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirData();
        private void HoraeData_Click(object sender, RoutedEventArgs e) => _menuEditar.InserirDataHora();

        // Menu Exibir



        // Configurações

    }
}
