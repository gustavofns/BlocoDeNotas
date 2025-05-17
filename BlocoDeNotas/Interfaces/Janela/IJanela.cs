using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Configuracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace BlocoDeNotas.Interfaces.Janela
{
    public interface IJanela
    {
        string TituloJanela { get;  set; }

        void Voltar();
        void MostrarJanela();
        void NavegarPara(object objeto);
        void FecharJanela();
    }
}
