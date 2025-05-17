using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo.GerenciamentoDeArquivos;
using BlocoDeNotas.Interfaces.UI.Componentes;
using BlocoDeNotas.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Menu.MenuArquivo
{
    public class MenuArquivo : IMenuArquivo
    {
        private readonly ILeituraDeArquivos _leituraDeArquivos;
        private readonly IGravacaoDeArquivos _gravacaoDeArquivos;
        private readonly ICaixaDeMensagem _caixaDeMensagem;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public MenuArquivo(ILeituraDeArquivos leituraDeArquivos, IGravacaoDeArquivos gravacaoDeArquivos, 
            ICaixaDeMensagem caixaDeMensagem, IEditorDeDocumentos editorDeDocumentos) 
        {
            _leituraDeArquivos = leituraDeArquivos;
            _gravacaoDeArquivos = gravacaoDeArquivos;
            _caixaDeMensagem = caixaDeMensagem;
            _editorDeDocumentos = editorDeDocumentos;
        }


        public void AbrirNovaJanela() { throw new NotImplementedException(); }
        public void FecharJanela() { throw new NotImplementedException(); }
        public void AbrirArquivo() => _leituraDeArquivos.AbrirArquivo();
        public void Salvar() => _gravacaoDeArquivos.Salvar();
        public void SalvarComo() => _gravacaoDeArquivos.SalvarComo();

        // Fecha o arquivo atual
        public void FecharArquivo()
        {
            _editorDeDocumentos.Arquivo = string.Empty;
            _editorDeDocumentos.DocumentoAtual = string.Empty;
            _editorDeDocumentos.DocumentoOriginal = string.Empty;
        }

        // Sai do aplicativo
        public void SairDoAplicativo()
        {
            if (!_caixaDeMensagem.MostrarPergunta("Tem certeza que deseja sair?"))
                return;

            if (!string.IsNullOrEmpty(_editorDeDocumentos.DocumentoAtual) || !string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
            {
                if (_editorDeDocumentos.DocumentoAtual != _editorDeDocumentos.DocumentoOriginal)
                    if (_caixaDeMensagem.MostrarPergunta("Deseja salvar o documento antes de sair?"))
                        Salvar();
            }

            Application.Current.Shutdown();
        }
    }
}
