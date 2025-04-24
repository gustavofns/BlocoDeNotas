using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface IGerenciamentoDeArquivos
    {
        void AbrirArquivo();
        void SalvarArquivo();
        void SalvarArquivoComo();
        void FecharArquivo();
    }
}
