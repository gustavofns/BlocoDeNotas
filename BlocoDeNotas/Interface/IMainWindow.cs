using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Interface
{
    public interface IMainWindow
    {
        public void AvancarFrame(Frame frame);
        public void VoltarFrame();
        public void DefinirTituloJanela(string titulo);
        public void FecharJanela();
    }
}
