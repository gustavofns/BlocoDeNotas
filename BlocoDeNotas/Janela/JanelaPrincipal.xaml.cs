using BlocoDeNotas.Interfaces.Config.Janela;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Janela
{
    /// <summary>
    /// Lógica interna para JanelaPrincipal.xaml
    /// </summary>
    public partial class JanelaPrincipal : Window, IJanela
    {
        private readonly INavegacao _navegacao;
        private readonly IConfiguracoesDaJanela _configuracoesDaJanela;

        public string TituloJanela 
        { 
            get => Title; 
            set => Title = value; 
        }

        public JanelaPrincipal(INavegacao navegacao, IConfiguracoesDaJanela configuracoesDaJanela)
        {
            InitializeComponent();
            _navegacao = navegacao;
            _configuracoesDaJanela = configuracoesDaJanela;
            CarregarConfiguracoesDaJanela();
        }

        public void FecharJanela() => Close();
        public void MostrarJanela() => Show();
        public void NavegarPara(object objeto) => _navegacao.NavegarPara(objeto);
        public void Voltar() => _navegacao.Voltar();

        private void CarregarConfiguracoesDaJanela()
        { 
            var tamanho = _configuracoesDaJanela.CarregarTamanhoJanela();
            var posicao = _configuracoesDaJanela.CarregarPosicaoJanela();
            var estado = _configuracoesDaJanela.CarregarEstadoJanela();
            Height = tamanho.altura;
            Width = tamanho.largura;
            Left = posicao.posicaoX;
            Top = posicao.posicaoY;
            WindowState = estado;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Content = _navegacao.Frame;
            ThemeMode = ThemeMode.System;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(WindowState == WindowState.Normal)
                _configuracoesDaJanela.SalvarTamanhoJanela(Height, Width);
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if(WindowState == WindowState.Normal)
                _configuracoesDaJanela.SalvarPosicaoJanela(Left, Top);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            _configuracoesDaJanela.SalvarEstadoJanela(WindowState);
        }
    }
}
