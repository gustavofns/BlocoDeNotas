using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces
{
    public interface IJanela
    {
        public string[] Args { get; set; }
        public Frame FrameJanela { get; }
        void TituloJanela(string titulo);
        void MostrarJanela(IEditor editor);
        double AlturaJanela();
        double LarguraJanela();
        void FecharJanela();
    }
}
