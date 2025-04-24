using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;

namespace BlocoDeNotas.Eventos
{
    public class BarraDeTitulo : IBarraDeTitulo
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public BarraDeTitulo(IJanela janela, IEditorDeDocumentos editorDeDocumentos)
        {
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
        }

        public void AtualizarBarraDeTitulo()
        {
            if (_editorDeDocumentos.Arquivo == string.Empty)
            {
                if (_editorDeDocumentos.Documento.Text.Length == 0)
                {
                    _janela.TituloJanela("Bloco de notas");
                }
                else
                {
                    _janela.TituloJanela("Bloco de notas - documento não salvo");
                }
            }
            else
            {
                if(_editorDeDocumentos.Documento.Text == _editorDeDocumentos.DocumentoOriginal.ToString())
                {
                    _janela.TituloJanela($"Bloco de notas - {_editorDeDocumentos.Arquivo}");
                }
                else
                {
                    _janela.TituloJanela($"Bloco de notas - {_editorDeDocumentos.Arquivo} - documento modificado");
                }
            }
        }
    }
}
