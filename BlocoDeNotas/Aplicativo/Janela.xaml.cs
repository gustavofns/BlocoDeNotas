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
        public Frame FrameJanela { get { return _FrameJanela; } }

        public Janela(String[] args)
        {
            InitializeComponent();
            Args = args;
        }

        public void TituloJanela(string titulo) { Title = titulo; }
        public double AlturaJanela() { return Height;}
        public double LarguraJanela() { return Width;}
        public void FecharJanela() { Close(); }
        public void MostrarJanela(IEditor editor)
        {
            _FrameJanela.Navigate(editor);
            Show();
        }
    }
}
