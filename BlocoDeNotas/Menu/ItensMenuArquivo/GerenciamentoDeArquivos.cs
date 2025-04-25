using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Utilitarios;
using Microsoft.Win32;

namespace BlocoDeNotas.Menu.ItensMenuArquivo
{
    public class GerenciamentoDeArquivos : IGerenciamentoDeArquivos
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly ICaixaDeDialogodeArquivos _caixaDeDialogodeArquivos;
        private readonly IOperacoesComArquivos _operacoesComArquivo;

        public GerenciamentoDeArquivos(IEditorDeDocumentos editorDeDocumentos, 
            ICaixaDeDialogodeArquivos caixaDeDialogodeArquivos, IOperacoesComArquivos operacoesComArquivo)
        {
            _editorDeDocumentos = editorDeDocumentos;
            _caixaDeDialogodeArquivos = caixaDeDialogodeArquivos;
            _operacoesComArquivo = operacoesComArquivo;
        }

        public void AbrirArquivo()
        {
            string arquivo = _caixaDeDialogodeArquivos.CaixaDeDialogo
                (new OpenFileDialog(), "Selecione um documento para abrir");

            if (!string.IsNullOrEmpty(arquivo))
            {
                LimparEditor();
                _operacoesComArquivo.LerArquivo(arquivo);
            }
        }

        public void FecharArquivo() { LimparEditor(); }

        public void SalvarArquivo()
        {
            if (!string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
                _operacoesComArquivo.GravarArquivo(_editorDeDocumentos.Arquivo);
            else SalvarArquivoComo();
        }

        public void SalvarArquivoComo()
        {
            string arquivo = _caixaDeDialogodeArquivos.CaixaDeDialogo
                (new SaveFileDialog(), "Selecione um local para salvar o documento");

            if (!string.IsNullOrEmpty(arquivo))
                _operacoesComArquivo.GravarArquivo(arquivo);
        }

        private void LimparEditor()
        {
            _editorDeDocumentos.Documento.Clear();
            _editorDeDocumentos.DocumentoOriginal.Clear();
            _editorDeDocumentos.Arquivo = string.Empty;
        }
    }
}