using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.UI.Componentes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlocoDeNotas.UI.Configuracoes
{
    /// <summary>
    /// Interação lógica para Configuracoes.xam
    /// </summary>
    public partial class Configuracoes : Page, IConfiguracoes
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public Configuracoes(IJanela janela, IEditorDeDocumentos editorDeDocumentos)
        {
            InitializeComponent();
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _janela.TituloJanela = "Configurações";
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            _janela.Voltar();
        }

        private void Fonte_Click(object sender, RoutedEventArgs e)
        {
            _editorDeDocumentos.Fonte = "Arial";
            _editorDeDocumentos.TamanhoFonte = 20;
        }
    }
}
