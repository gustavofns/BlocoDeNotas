using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Windows.Graphics.Printing;

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
        private DefinirConfig.Personalizacao personalizacao;
        private DefinirConfig.SalvarConfig salvarConfig;

        public Tema(Editor editor)
        {
            InitializeComponent();
            this.editor = editor;
            personalizacao = new DefinirConfig.Personalizacao(editor);
            salvarConfig = new DefinirConfig.SalvarConfig();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            radioButtomCkecked(Properties.Settings.Default.Tema);
            CorUIChecked(Properties.Settings.Default.UsarUIColorida);
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
            salvarConfig.UsarUIColorida(true);
            personalizacao.UsarUIColorida(true);
        }

        private void CorUI_UnChecked(object sender, RoutedEventArgs e)
        {
            salvarConfig.UsarUIColorida(false);
            personalizacao.UsarUIColorida(false);
        }

        private void CorUIChecked(bool Checked)
        { 
            corUI.IsChecked = Checked;
        }
    }
}
