using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.UI.Componentes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuArquivo
{
    public class LeituraDeArquivos : ILeituraDeArquivos
    {
        private string _arquivo;
        private readonly ICaixaDeDialogoArquivos _caixaDeDialogoArquivos;
        private readonly IExcecoes _excecoes;

        public LeituraDeArquivos(ICaixaDeDialogoArquivos caixaDeDialogoArquivos, IExcecoes excecoes)
        {
            _arquivo = string.Empty;
            _caixaDeDialogoArquivos = caixaDeDialogoArquivos;
            _excecoes = excecoes;
        }

        // Seleciona um arquivo para abrir
        public void AbrirArquivo(IEditorDeDocumentos editorDeDocumentos)
        {
            _arquivo = _caixaDeDialogoArquivos.MostrarCaixaDeDialogo(
                new OpenFileDialog(),
                "Selecione um arquivo para abrir"
            );
            if (string.IsNullOrEmpty(_arquivo))
                return;
            else LerArquivo(editorDeDocumentos);
        }

        // Faz leitura do arquivo
        private void LerArquivo(IEditorDeDocumentos editorDeDocumentos)
        {
            try
            {
                using(var sr = new StreamReader(_arquivo))
                {
                    var documento = sr.ReadToEnd();
                    editorDeDocumentos.DocumentoOriginal = documento;
                    editorDeDocumentos.DocumentoAtual = documento;
                    editorDeDocumentos.Arquivo = _arquivo;
                    editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
                }
            }
            catch (Exception ex)
            {
                _excecoes.ExibirMensagemExcecao(ex);
            }
            finally
            {
                _arquivo = string.Empty;
                editorDeDocumentos.AtualizarTitulo();
            }
        }
    }
}
