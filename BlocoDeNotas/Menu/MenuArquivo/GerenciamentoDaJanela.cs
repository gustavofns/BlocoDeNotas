using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.UI;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Menu.MenuArquivo
{
    public class GerenciamentoDaJanela : IGerenciamentoDaJanela
    {
        private IJanela _janela;
        private IEditorDeDocumentos _editorDeDocumentos;
        private ICaixaDeMensagem _caixaDeMensagem;
        private IGravacaoDeArquivos _gravacaoDeArquivos;

        public GerenciamentoDaJanela(IJanela janela, IEditorDeDocumentos editorDeDocumentos,
            ICaixaDeMensagem caixaDeMensagem, IGravacaoDeArquivos gravacaoDeArquivos)
        {
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
            _caixaDeMensagem = caixaDeMensagem;
            _gravacaoDeArquivos = gravacaoDeArquivos;
        }

        // Abre uma nova janela
        public void AbrirNovaJanela()
        {
            throw new NotImplementedException();
        }

        // Fecha a janela atual
        public void FecharJanela()
        {
            _janela.FecharJanela();
        }

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
            if (!string.IsNullOrEmpty(_editorDeDocumentos.DocumentoAtual) || !string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
            {
                if (_editorDeDocumentos.DocumentoAtual != _editorDeDocumentos.DocumentoOriginal)
                    if (_caixaDeMensagem.MostrarPergunta("Deseja salvar o documento antes de sair?"))
                        _gravacaoDeArquivos.Salvar(_editorDeDocumentos);
            }

            if (!_caixaDeMensagem.MostrarPergunta("Tem certeza que deseja sair?"))
                return;
           Application.Current.Shutdown();
        }
    }
}
