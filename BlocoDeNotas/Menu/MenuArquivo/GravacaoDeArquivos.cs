using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.UI;
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
    public class GravacaoDeArquivos(ICaixaDeDialogoArquivos caixaDeDialogoArquivos, IExcecoes excecoes) : IGravacaoDeArquivos
    {
        // Verifica se o arquivo possui um caminho, caso não possua pede selecionar um local para salvar e depois salva o arquivo
        public void Salvar(IEditorDeDocumentos editorDeDocumentos)
        {
            string arquivo = editorDeDocumentos.Arquivo;
            if (string.IsNullOrEmpty(arquivo))
                SalvarComo(editorDeDocumentos);
            else GravarArquivo(editorDeDocumentos, arquivo);
        }

        // Seleciona um local para salvar o arquivo e depois salva o arquivo
        public void SalvarComo(IEditorDeDocumentos editorDeDocumentos)
        {
            string arquivo = caixaDeDialogoArquivos.MostrarCaixaDeDialogo(
                new SaveFileDialog(),
                "Selecione um local para salvar o documento"
            );

            if (string.IsNullOrEmpty(arquivo))
                return;
            else GravarArquivo(editorDeDocumentos, arquivo);
        }

        // Grava o arquivo no armazenamento
        private void GravarArquivo(IEditorDeDocumentos editorDeDocumentos, string arquivo)
        {
            try
            {
                using(var sw = new StreamWriter(arquivo))
                {
                    sw.AutoFlush = true;
                    sw.Write(editorDeDocumentos.DocumentoAtual);
                    editorDeDocumentos.DocumentoOriginal = 
                        editorDeDocumentos.DocumentoAtual;
                    editorDeDocumentos.Arquivo = arquivo;
                }
            }
            catch(Exception ex)
            {
                excecoes.ExibirMensagemExcecao(ex);
            }
            finally
            {
                arquivo = string.Empty;
                editorDeDocumentos.AtualizarTitulo();
            }
        }
    }
}
