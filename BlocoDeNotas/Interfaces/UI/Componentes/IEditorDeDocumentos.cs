using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.UI.Componentes
{
    public interface IEditorDeDocumentos
    {
        // Propriedades
        string Arquivo { get; set; }
        string DocumentoAtual { get; set; }
        string DocumentoOriginal { get; set; }
        string Fonte { get; set; }
        int Linhas { get;}
        bool QuebraDeLinha { get; set; }
        bool PossivelDesfazer { get; }
        bool PossivelRefazer { get; }
        double TamanhoFonte { get; set; }
        string TextoSelecionado { get; }

        // Métodos
        void Desfazer();
        void Refazer();
        void SelecionarTudo();
    }
}
