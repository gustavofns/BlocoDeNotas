using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;

namespace BlocoDeNotas.Interfaces.Menu
{
    public interface IMenuEditar : IAcoesDoDocumento, ITextoSelecionado, IAreaDeTransferencia, IDataEHora
    {

    }
}
