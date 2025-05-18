using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuExibir
{
    public interface IMenuExibir
    {
        public void ExibirBarraDeStatus(bool sender);
        public void ExibirQuebraDeLinha(bool sender);
    }
}
