using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BlocoDeNotas.Interfaces.Componentes;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Aplicativo.Componentes
{
    /// <summary>
    /// Interação lógica para BarraDeStatus.xam
    /// </summary>
    public partial class BarraDeStatus : Page, IBarraDeStatus
    {
        private readonly TextBox _documento;

        public BarraDeStatus(TextBox documento)
        {
            InitializeComponent();
            _documento = documento;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) { BarraDeStatusGrid.Background = Brushes.WhiteSmoke; }
    }
}
