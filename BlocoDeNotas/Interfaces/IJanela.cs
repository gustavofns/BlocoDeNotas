using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
