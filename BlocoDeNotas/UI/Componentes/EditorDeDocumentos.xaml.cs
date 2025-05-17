using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.CodeDom;
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
    /// Interação lógica para EditorDeDocumentos.xam
    /// </summary>
    public partial class EditorDeDocumentos : UserControl, IEditorDeDocumentos
    {
        private readonly IAtualizarTituloJanela _atualizarTituloJanela;
        public string Arquivo { get; set; }
        public string DocumentoOriginal { get; set; }

        // Obtém ou define o texto do documento atual
        public string DocumentoAtual 
        {
            get { return Documento.Text; }
            set { Documento.Text = value;}
        }

        // Obtém ou define a fonte do documento atual
        public string Fonte 
        {
            get { return Documento.FontFamily.ToString(); }
            set { Documento.FontFamily = new FontFamily(value); }
        }
        // Obtém o número de linhas do documento atual
        public int Linhas
        { 
            get { return Documento.LineCount; }
        }

        // Obtém ou define se o documento atual deve quebrar linhas
        public bool QuebraDeLinha
        {
            get { return Documento.TextWrapping == TextWrapping.Wrap; }
            set
            {
                if (value) Documento.TextWrapping = TextWrapping.Wrap;
                else Documento.TextWrapping = TextWrapping.NoWrap;
            }
        }

        // Obtém ou define o tamanho da fonte do documento atual
        public double TamanhoFonte
        { 
            get { return Documento.FontSize; }
            set { Documento.FontSize = value; }
        }

        // Obtém o texto selecionado no documento atual
        public string TextoSelecionado
        {
            get
            {
                if(Documento.SelectedText.Length > 0) return Documento.SelectedText;
                else return string.Empty;
            }
        }

        // Verifica se é possível desfazer a última ação
        public bool PossivelDesfazer
        {
            get { return Documento.CanUndo; }
        }

        // Verifica se é possível refazer a última ação
        public bool PossivelRefazer
        {
            get { return Documento.CanRedo; }
        }

        // Construtor da classe
        public EditorDeDocumentos(IAtualizarTituloJanela atualizarTituloJanela)
        {
            InitializeComponent();
            Arquivo = string.Empty;
            DocumentoOriginal = string.Empty;
            _atualizarTituloJanela = atualizarTituloJanela;
        }

        // Evento de carregamento do controle
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(Documento.Focusable)
            {
                Documento.Focus();
                Documento.CaretIndex = Documento.Text.Length;
            }
            AtualizarTitulo();
        }

        // Métodos para manipulação do documento
        public void Desfazer() => Documento.Undo();
        public void Refazer() => Documento.Redo();
        public void SelecionarTudo() => Documento.SelectAll();
        private void AtualizarTitulo() => _atualizarTituloJanela.AtualizarTitulo(Arquivo, DocumentoAtual, DocumentoOriginal);

        // Evento para atualizar o título quando o texto do documento é alterado
        private void Documento_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarTitulo();
        }
    }
}
