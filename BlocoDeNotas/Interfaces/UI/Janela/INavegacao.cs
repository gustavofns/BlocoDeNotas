using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.UI.Janela
{
    public interface INavegacao
    {
        void NavegarPara(object objeto);
        bool Voltar();
        Frame Frame { get; }
    }
}
