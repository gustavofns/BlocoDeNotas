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
using System.Windows.Shapes;

namespace BlocoDeNotas.Utilidades
{
    /// <summary>
    /// Lógica interna para CaixadeMensagem.xaml
    /// </summary>
    public partial class CaixadeMensagem : Window
    {
        private MainWindow mainWindow;

        public CaixadeMensagem(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
    }
}
