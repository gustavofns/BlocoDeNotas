using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#pragma warning disable WPF0001
#pragma warning disable CS8600

namespace BlocoDeNotas.Config.Frames
{
    /// <summary>
    /// Interação lógica para Tema.xam
    /// </summary>
    public partial class Tema : Page
    {
        private Editor editor;

        public Tema(Editor editor)
        {
            InitializeComponent();
            this.editor = editor;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            radioButtomCkecked(Properties.Settings.Default.Tema);
            corUI.IsChecked = Properties.Settings.Default.CorUI;
        }

        private void MudarTema_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string tema = radioButton.Content.ToString();
            new DefinirConfig.SalvarConfig().SalvarTema(tema);
            new DefinirConfig.Personalizacao(editor).MudarTema(tema);
            radioButtomCkecked(tema);
        }

        private void radioButtomCkecked(string tema)
        {
            switch (tema)
            {
                case "Claro":
                    TemaClaro_Checked.IsChecked = true;
                    break;
                case "Escuro":
                    TemaEscuro_Checked.IsChecked = true;
                    break;
                default:
                    TemaSistema_Checked.IsChecked = true;
                    break;
            }
        }

        private void CorUI_Checked(object sender, RoutedEventArgs e)
        { 

        }
    }
}
