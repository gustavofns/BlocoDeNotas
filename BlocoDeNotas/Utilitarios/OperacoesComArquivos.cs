using System.IO;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Utilitarios;

namespace BlocoDeNotas.Utilitarios
{
    public class OperacoesComArquivos : IOperacoesComArquivos
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly IExcecoes _excecoes;

        public OperacoesComArquivos(IEditorDeDocumentos editorDeDocumentos, IExcecoes excecoes) 
        {
            _editorDeDocumentos = editorDeDocumentos;
            _excecoes = excecoes;
        }

        public void LerArquivo(string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                return;
            LeituraDoArquivo(arquivo);
        }

        public void GravarArquivo(string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                return;
            GravacaoDoArquivo(arquivo);
        }

        private void LeituraDoArquivo(string arquivo)
        {   
            try
            {
                using (var sr = new StreamReader(arquivo))
                {
                    _editorDeDocumentos.DocumentoOriginal.Append(sr.ReadToEnd());
                    _editorDeDocumentos.Documento.AppendText(_editorDeDocumentos.DocumentoOriginal.ToString());
                    _editorDeDocumentos.Documento.CaretIndex = _editorDeDocumentos.Documento.Text.Length;
                    _editorDeDocumentos.Arquivo = arquivo;
                }
            }
            catch (Exception ex)
            {
                _excecoes.ExibirMensagemExcecao(
                    "Não foi possível abrir o documento", ex);
            }
        }

        private void GravacaoDoArquivo(string arquivo)
        {   
            try
            {
                using (var sw = new StreamWriter(arquivo))
                {
                    _editorDeDocumentos.DocumentoOriginal.Clear();
                    _editorDeDocumentos.DocumentoOriginal.Append(_editorDeDocumentos.Documento.Text);
                    sw.Write(_editorDeDocumentos.DocumentoOriginal);
                    _editorDeDocumentos.Arquivo = arquivo;
                }
            }
            catch (Exception ex)
            {
                _excecoes.ExibirMensagemExcecao(
                    "Não foi possível salvar o documento", ex);
            }
        }
    }
}
