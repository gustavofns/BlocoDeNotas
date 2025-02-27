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

#pragma warning disable CS8600
#pragma warning disable CS8629

namespace BlocoDeNotas.Config
{
    /// <summary>
    /// Interação lógica para Personalizacao.xam
    /// </summary>
    public partial class Personalizacao : Page
    {
        private Editor editor;
        private AplicarConfig.Tema tema;
        private AplicarConfig.UI ui;

        public Personalizacao(Editor editor)
        {
            InitializeComponent();
            this.editor = editor;
            tema = new AplicarConfig.Tema(editor);
            ui = new AplicarConfig.UI(editor);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TemaSelecionado_Checked(Properties.Settings.Default.Tema);
            IconesColoridos.IsChecked = Properties.Settings.Default.UsarUIColorida;
            FerramentasRapidas.IsChecked = Properties.Settings.Default.FerramentasRapidas;
        }

        private void MudarTema_Click(object sender, RoutedEventArgs e)
        {
            RadioButton temaSelecionado = (RadioButton)sender;
            tema.MudarTema(temaSelecionado.Content.ToString());
            tema.SalvarConfiguracaoTema(temaSelecionado.Content.ToString());
            TemaSelecionado_Checked(temaSelecionado.Content.ToString());
        }

        private void TemaSelecionado_Checked(String temaSelecionado)
        {
            switch (temaSelecionado)
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

        // Habilita ou desabilita os ícones coloridos
        private void IconesColoridos_Checked(object sender, RoutedEventArgs e)
        {
            bool iconesColoridos = IconesColoridos.IsChecked.Value;
            ui.IconesColoridos(iconesColoridos);
            ui.SalvarConfigIconesColoridos(iconesColoridos);
        }

        // Habilita ou desabilita as ferramentas rápidas
        private void FerramentasRapidas_Checked(object sender, RoutedEventArgs e)
        {
            bool ferramentasRapidas = FerramentasRapidas.IsChecked.Value;
            ui.FerramentasRapidas(ferramentasRapidas);
            ui.SalvarConfigFerramentasRapidas(ferramentasRapidas);
        }
    }
}
