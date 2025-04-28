using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces
{
    public interface IJanela
    {
        public Frame FrameJanela { get; }
        void MostrarJanela(IEditor editor);
        void TituloJanela(string titulo);
        double AlturaJanela();
        double LarguraJanela();
        void FecharJanela();
    }
}
