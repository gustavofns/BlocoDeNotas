using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo.GerenciamentoDeArquivos;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Menu.MenuArquivo.GerenciamentoDeArquivos
{
    public class GravacaoDeArquivos : IGravacaoDeArquivos
    {
        private string _arquivo;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly ICaixaDeDialogoArquivos _caixaDeDialogoArquivos;
        private readonly IExcecoes _excecoes;

        public GravacaoDeArquivos(IEditorDeDocumentos editorDeDocumentos, 
            ICaixaDeDialogoArquivos caixaDeDialogoArquivos, IExcecoes excecoes)
        {
            _arquivo = string.Empty;
            _editorDeDocumentos = editorDeDocumentos;
            _caixaDeDialogoArquivos = caixaDeDialogoArquivos;
            _excecoes = excecoes;
        }

        public void Salvar()
        {
            _arquivo = _editorDeDocumentos.Arquivo;
            if (string.IsNullOrEmpty(_arquivo))
                SalvarComo();
            else GravarArquivo();
        }

        public void SalvarComo()
        {
            _arquivo = _caixaDeDialogoArquivos.MostrarCaixaDeDialogo(
                new SaveFileDialog(),
                "Selecione um local para salvar o documento"
            );

            if (string.IsNullOrEmpty(_arquivo))
                return;
            else GravarArquivo();
        }

        private void GravarArquivo()
        {
            try
            {
                using(var sw = new StreamWriter(_arquivo))
                {
                    string documento = _editorDeDocumentos.DocumentoAtual;
                    sw.WriteLine(documento);
                    _editorDeDocumentos.DocumentoOriginal = documento;
                    _editorDeDocumentos.Arquivo = _arquivo;
                }
            }
            catch(Exception ex)
            {
                _excecoes.ExibirMensagemExcecao(ex);
            }
            finally
            {
                _arquivo = string.Empty;
                _editorDeDocumentos.AtualizarTitulo();
            }
        }
    }
}
