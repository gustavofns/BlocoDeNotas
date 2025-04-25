using System.Windows;
using System.Windows.Controls;
using BlocoDeNotas.Interfaces;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Aplicativo
{
    /// <summary>
    /// Lógica interna para Janela.xaml
    /// </summary>
    public partial class Janela : Window, IJanela
    {
        public string[] Args { get ; set; }
        public Frame FrameJanela { get ; set ; }
        private readonly IEditor _editorDeDocumentos;

        public Janela(String[] args)
        {
            InitializeComponent();
            Args = args;
            FrameJanela = Frame();
            _editorDeDocumentos = InicializarEditorDocumentos(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) { FrameJanela.Navigate(_editorDeDocumentos); }

        private Frame Frame() { return _FrameJanela;}
        private IEditor InicializarEditorDocumentos(IJanela janela) { return new Editor(janela); }
        public void TituloJanela(string titulo) { Title = titulo; }
        public double AlturaJanela() { return Height;}
        public double LarguraJanela() { return Width;}
        public void MostrarJanela() { Show(); }
        public void FecharJanela() { Close(); }

    }
}
