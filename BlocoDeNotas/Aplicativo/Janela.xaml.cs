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
            Args = args;
            InitializeComponent();
            FrameJanela = Frame();
            _editorDeDocumentos = InicializarEditorDocumentos(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FrameJanela.Navigate(_editorDeDocumentos);
        }

        private Frame Frame() { return _FrameJanela;}
        private IEditor InicializarEditorDocumentos(IJanela janela) { return new Editor(janela); }
        public void TituloJanela(string titulo) { Title = titulo; }
        public double AlturaJanela() { return Height;}
        public double LarguraJanela() { return Width;}
        public void MostrarJanela() { Show(); }
        public void FecharJanela() { Close(); }

    }
}
