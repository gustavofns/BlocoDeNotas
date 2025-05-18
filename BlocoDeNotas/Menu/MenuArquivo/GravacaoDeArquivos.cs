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
    public class GravacaoDeArquivos : IGravacaoDeArquivos
    {
        private string _arquivo;
        private readonly ICaixaDeDialogoArquivos _caixaDeDialogoArquivos;
        private readonly IExcecoes _excecoes;

        public GravacaoDeArquivos(IEditorDeDocumentos editorDeDocumentos, 
            ICaixaDeDialogoArquivos caixaDeDialogoArquivos, IExcecoes excecoes)
        {
            _arquivo = string.Empty;
            _caixaDeDialogoArquivos = caixaDeDialogoArquivos;
            _excecoes = excecoes;
        }

        // Verifica se o arquivo possui um caminho, caso não possua pede selecionar um local para salvar e depois salva o arquivo
        public void Salvar(IEditorDeDocumentos editorDeDocumentos)
        {
            _arquivo = editorDeDocumentos.Arquivo;
            if (string.IsNullOrEmpty(_arquivo))
                SalvarComo(editorDeDocumentos);
            else GravarArquivo(editorDeDocumentos);
        }

        // Seleciona um local para salvar o arquivo e depois salva o arquivo
        public void SalvarComo(IEditorDeDocumentos editorDeDocumentos)
        {
            _arquivo = _caixaDeDialogoArquivos.MostrarCaixaDeDialogo(
                new SaveFileDialog(),
                "Selecione um local para salvar o documento"
            );

            if (string.IsNullOrEmpty(_arquivo))
                return;
            else GravarArquivo(editorDeDocumentos);
        }

        // Grava o arquivo no armazenamento
        private void GravarArquivo(IEditorDeDocumentos editorDeDocumentos)
        {
            try
            {
                using(var sw = new StreamWriter(_arquivo))
                {
                    sw.AutoFlush = true;
                    sw.Write(editorDeDocumentos.DocumentoAtual);
                    editorDeDocumentos.DocumentoOriginal = 
                        editorDeDocumentos.DocumentoAtual;
                }
            }
            catch(Exception ex)
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
