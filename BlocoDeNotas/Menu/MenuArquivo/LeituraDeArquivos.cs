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
    public class LeituraDeArquivos(ICaixaDeDialogoArquivos caixaDeDialogoArquivos, IExcecoes excecoes) : ILeituraDeArquivos
    {
        // Seleciona um arquivo para abrir
        public void AbrirArquivo(IEditorDeDocumentos editorDeDocumentos)
        {
            string arquivo = caixaDeDialogoArquivos.MostrarCaixaDeDialogo(
                new OpenFileDialog(),
                "Selecione um arquivo para abrir"
            );
            if (string.IsNullOrEmpty(arquivo))
                return;
            else LerArquivo(editorDeDocumentos, arquivo);
        }

        // Faz leitura do arquivo
        private void LerArquivo(IEditorDeDocumentos editorDeDocumentos, string arquivo)
        {
            try
            {
                using(var sr = new StreamReader(arquivo))
                {
                    var documento = sr.ReadToEnd();
                    editorDeDocumentos.DocumentoOriginal = documento;
                    editorDeDocumentos.DocumentoAtual = documento;
                    editorDeDocumentos.Arquivo = arquivo;
                    editorDeDocumentos.DefinirPosicaoDoCursorDeTexto();
                }
            }
            catch (Exception ex)
            {
                excecoes.ExibirMensagemExcecao(ex);
            }
            finally
            {
                editorDeDocumentos.AtualizarTitulo();
            }
        }
    }
}
