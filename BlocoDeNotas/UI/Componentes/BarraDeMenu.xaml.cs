using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Janela;
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
        private readonly IConfiguracoes _configuracoes;
        private readonly IJanela _janela;

        public BarraDeMenu(IConfiguracoes configuracoes, IJanela janela)
        {
            InitializeComponent();
            _configuracoes = configuracoes;
            _janela = janela;
        }

        private void Avancar_Click(object sender, RoutedEventArgs e)
        {
            _janela.NavegarPara(_configuracoes);
        }
    }
}
