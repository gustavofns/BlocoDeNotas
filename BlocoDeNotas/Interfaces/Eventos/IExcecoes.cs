using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Eventos
{
    public interface IExcecoes
    {
        void ExibirMensagemExcecao(string titulo, Exception ex);
    }
}
