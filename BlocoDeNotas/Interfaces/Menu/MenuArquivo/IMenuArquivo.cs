using BlocoDeNotas.Interfaces.Menu.MenuArquivo.GerenciamentoDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface IMenuArquivo : ILeituraDeArquivos, IGravacaoDeArquivos
    {
        void AbrirNovaJanela();
        void FecharJanela();
        void FecharArquivo();
        void SairDoAplicativo();
    }
}
