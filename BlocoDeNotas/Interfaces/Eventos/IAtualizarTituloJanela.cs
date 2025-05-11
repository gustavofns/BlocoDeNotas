using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Eventos
{
    public interface IAtualizarTituloJanela
    {
        public void AtualizarTitulo(string arquivo, string documentoAtual, string documentoOriginal);
    }
}
