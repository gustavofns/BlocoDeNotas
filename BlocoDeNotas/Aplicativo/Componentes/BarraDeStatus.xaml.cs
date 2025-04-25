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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.ThemeMode == ThemeMode.None)
            {
                BarraDeStatusGrid.Background = Brushes.WhiteSmoke;
            }
        }
    }
}
