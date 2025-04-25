using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces
{
    public interface IJanela
    {
        public string[] Args { get; set; }
        public Frame FrameJanela { get; set; }
        void TituloJanela(string titulo);
        void MostrarJanela();
        double AlturaJanela();
        double LarguraJanela();
        void FecharJanela();
    }
}
