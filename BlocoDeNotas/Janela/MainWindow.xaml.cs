using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using BlocoDeNotas.Janela;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Foundation.Metadata;

namespace BlocoDeNotas
{
[Obsolete("Foi substituido por JanelaPrincipal.xaml.cs")]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IJanela
    {
        private readonly INavegacao _navegacao;
        public string TituloJanela { get => Title; set => Title = value; }
        public double AlturaJanela { set => Height = value; }
        public double LarguraJanela { set => Width = value; }
        public double PosicaoXJanela { set => Left = value; }
        public double PosicaoYJanela { set => Top = value; }

        public MainWindow(INavegacao navegacao)
        {
            InitializeComponent();
            _navegacao = navegacao;
            Content = _navegacao.Frame;
        }

        public void FecharJanela() => Close();
 
        public void MostrarJanela() => Show();
        public void NavegarPara(object objeto) => _navegacao.NavegarPara(objeto);
        public void Voltar() => _navegacao.Voltar();
    }
}