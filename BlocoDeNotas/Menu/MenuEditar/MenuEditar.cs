using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuEditar
{
    public class MenuEditar : IMenuEditar
    {
        private readonly IAcoesDoDocumento _acoesDoDocumento;
        private readonly IAreaDeTransferencia _areaDeTransferencia;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IDataEHora _dataEHora;

        public MenuEditar(IAcoesDoDocumento acoesDoDocumento, IAreaDeTransferencia areaDeTransferencia, 
            IEditorDeDocumentos editorDeDocumentos, IDataEHora dataEHora)
        {
            _acoesDoDocumento = acoesDoDocumento;
            _areaDeTransferencia = areaDeTransferencia;
            _editorDeDocumentos = editorDeDocumentos;
            _dataEHora = dataEHora;
        }

        public void Desfazer() => _acoesDoDocumento.Desfazer(_editorDeDocumentos);
        public void Refazer() => _acoesDoDocumento.Refazer(_editorDeDocumentos);
        public void Excluir() => _acoesDoDocumento.Excluir(_editorDeDocumentos);
        public void Colar() => _areaDeTransferencia.Colar(_editorDeDocumentos);
        public void Copiar() => _areaDeTransferencia.Copiar(_editorDeDocumentos);
        public void Recortar () => _areaDeTransferencia.Recortar(_editorDeDocumentos);
        public void SelecionarTudo() => _acoesDoDocumento.SelecionarTudo(_editorDeDocumentos);
        public void HoraAtual() => _dataEHora.InserirHora();
        public void DataAtual() => _dataEHora.InserirData();
        public void DataEHoraAtual() => _dataEHora.InserirDataHora();
    }
}
