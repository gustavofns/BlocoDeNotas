using BlocoDeNotas.Interfaces.Menu.MenuEditar;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuEditar
{
    public class DataEHora : IDataEHora
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public DataEHora(IEditorDeDocumentos editorDeDocumentos)
        {
            _editorDeDocumentos = editorDeDocumentos;
        }

        // Insere a data atual
        public void InserirData()
        {
            _editorDeDocumentos.DocumentoAtual 
                += DateTime.Now.ToString("dd/MM/yyyy");
            PosicaoCursor();
        }

        // Insere a hora atual
        public void InserirHora()
        {
            _editorDeDocumentos.DocumentoAtual
                += DateTime.Now.ToString("HH:mm:ss");
            PosicaoCursor();
        }

        // Insere a data e hora atual
        public void InserirDataHora()
        {
            InserirHora();
            _editorDeDocumentos.DocumentoAtual += " ";
            InserirData();
        }

        // Define a posição do cursor no documento
        private void PosicaoCursor()
        {
            _editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
        }
    }
}
