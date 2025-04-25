using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Utilitarios
{
    public interface IOperacoesComArquivos
    {
        void LerArquivo(string caminho);
        void GravarArquivo(string caminho);
    }
}
