using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuEditar
{
    public class MenuEditar(IAcoesDoDocumento acoesDoDocumento, IAreaDeTransferencia areaDeTransferencia, 
        IEditorDeDocumentos editorDeDocumentos, IDataEHora dataEHora) : IMenuEditar
    {
        public void Desfazer() => acoesDoDocumento.Desfazer(editorDeDocumentos);
        public void Refazer() => acoesDoDocumento.Refazer(editorDeDocumentos);
        public void Excluir() => acoesDoDocumento.Excluir(editorDeDocumentos);
        public void Colar() => areaDeTransferencia.Colar(editorDeDocumentos);
        public void Copiar() => areaDeTransferencia.Copiar(editorDeDocumentos);
        public void Recortar () => areaDeTransferencia.Recortar(editorDeDocumentos);
        public void SelecionarTudo() => acoesDoDocumento.SelecionarTudo(editorDeDocumentos);
        public void HoraAtual() => dataEHora.InserirHora();
        public void DataAtual() => dataEHora.InserirData();
        public void DataEHoraAtual() => dataEHora.InserirDataHora();
    }
}
