using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI;
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
        private readonly IAreaDeTransferencia _areaDeTransferencia;
        private readonly IAcoesDoDocumento _acoesDoDocumento;
        private readonly IAtualizarTituloJanela _atualizarTituloJanela;
        private readonly ILeituraDeArquivos _leituraDeArquivos;
        private readonly IGravacaoDeArquivos _gravacaoDeArquivos;
        private readonly IGerenciamentoDaJanela _gerenciamentoDaJanela;
        public string Arquivo { get; set; }
        public string DocumentoOriginal { get; set; }

        // Obtém ou define o texto do documento atual
        public string DocumentoAtual
        {
            get { return Documento.Text; }
            set { Documento.Text = value; }
        }

        // Obtém ou define a fonte do documento atual
        public string Fonte
        {
            get { return Documento.FontFamily.ToString(); }
            set { Documento.FontFamily = new FontFamily(value); }
        }
        // Obtém o número de linhas do documento atual
        public int Linhas { get { return Documento.LineCount; } }

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
                if (Documento.SelectedText.Length > 0) return Documento.SelectedText;
                else return string.Empty;
            }
        }

        // Verifica se é possível desfazer a última ação
        public bool PossivelDesfazer { get { return Documento.CanUndo; } }

        // Verifica se é possível refazer a última ação
        public bool PossivelRefazer { get { return Documento.CanRedo; } }

        // Construtor da classe
        public EditorDeDocumentos(IAreaDeTransferencia areaDeTransferencia, IAcoesDoDocumento acoesDoDocumento,
            IAtualizarTituloJanela atualizarTituloJanela, ILeituraDeArquivos leituraDeArquivos, 
            IGravacaoDeArquivos gravacaoDeArquivos, IGerenciamentoDaJanela gerenciamentoDaJanela)
        {
            InitializeComponent();
            Arquivo = string.Empty;
            DocumentoOriginal = string.Empty;
            _areaDeTransferencia = areaDeTransferencia;
            _acoesDoDocumento = acoesDoDocumento;
            _atualizarTituloJanela = atualizarTituloJanela;
            _leituraDeArquivos = leituraDeArquivos;
            _gravacaoDeArquivos = gravacaoDeArquivos;
            _gerenciamentoDaJanela = gerenciamentoDaJanela;
        }

        // Evento de carregamento do frame
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        { 
            AtualizarTitulo(); 
            DefinirPosicaoDoCursorDeTexto();
            Focus();
        }


        // Métodos para manipulação do documento
        public void AtualizarTitulo() => _atualizarTituloJanela.AtualizarTitulo(Arquivo, DocumentoAtual, DocumentoOriginal);
        public void Desfazer() => Documento.Undo();
        public void ExcluirTexto() { if(Documento.SelectedText != null) Documento.SelectedText = "";}
        public void Refazer() => Documento.Redo();
        public void SelecionarTudo() => Documento.SelectAll();
        public void DefinirPosicaoDoCursorDeTexto() => Documento.CaretIndex = Documento.Text.Length;

        // Evento para atualizar o título quando o texto do documento é alterado
        private void Documento_TextChanged(object sender, TextChangedEventArgs e) => AtualizarTitulo();

        // Menu de Contexto
        private void RecortarMenuDeContexto_Click(object sender, RoutedEventArgs e) => _areaDeTransferencia.Recortar(this);
        private void CopiarMenuDeContexto_Click(object sender, RoutedEventArgs e) => _areaDeTransferencia.Copiar(this);
        private void ColarMenuDeContexto_Click(object sender, RoutedEventArgs e) => _areaDeTransferencia.Colar(this);
        private void ExcluirMenuDeContexto_Click(object sender, RoutedEventArgs e) => _acoesDoDocumento.Excluir(this);
        private void SelecionarTudoMenuContexto_Click(object sender, RoutedEventArgs e) => _acoesDoDocumento.SelecionarTudo(this);


        // Atalhos do teclado
        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if(Keyboard.Modifiers == ModifierKeys.Control) 
            {
                switch(e.Key)
                {
                    case Key.A:
                        _acoesDoDocumento.SelecionarTudo(this);
                        e.Handled = true;
                        break;
                    case Key.C:
                        _areaDeTransferencia.Copiar(this);
                        e.Handled = true;
                        break;
                    case Key.O:
                        _leituraDeArquivos.AbrirArquivo(this);
                        e.Handled = true;
                        break;
                    case Key.S:
                        if (e.Key == Key.S)
                        { _gravacaoDeArquivos.Salvar(this); e.Handled = true; }
                        break;
                    case Key.V:
                        _areaDeTransferencia.Colar(this);
                        e.Handled = true;
                        break;
                    case Key.X:
                        _areaDeTransferencia.Recortar(this);
                        e.Handled = true;
                        break;
                    case Key.Z:
                        _acoesDoDocumento.Desfazer(this);
                        e.Handled = true;
                        break;
                    case Key.Y:
                        _acoesDoDocumento.Refazer(this);
                        e.Handled = true;
                        break;
                }
            }

            if (Keyboard.Modifiers == (ModifierKeys.Control | ModifierKeys.Shift) && e.Key == Key.S)
            {
                if (e.Key == Key.S)
                { _gravacaoDeArquivos.SalvarComo(this); e.Handled = true; }
            }

            if(Keyboard.Modifiers == ModifierKeys.Alt)
            {
                switch(e.Key)
                {
                    case Key.F4:
                        _gerenciamentoDaJanela.SairDoAplicativo(this);
                        e.Handled = true;
                        break;
                    case Key.X:
                        _gerenciamentoDaJanela.FecharArquivo(this);
                        e.Handled = true;
                        break;
                }
            }

            if(e.Key == Key.Delete)
            {
                _acoesDoDocumento.Excluir(this);
                e.Handled = true;
            }
        }
    }
}
