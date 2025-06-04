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
    public class GerenciamentoDaJanela(IJanela janela, ICaixaDeMensagem caixaDeMensagem, 
        IGravacaoDeArquivos gravacaoDeArquivos) : IGerenciamentoDaJanela
    {
        // Abre uma nova janela
        public void AbrirNovaJanela()
        {
            throw new NotImplementedException();
        }

        // Fecha a janela atual
        public void FecharJanela()
        {
            janela.FecharJanela();
        }

        // Fecha o arquivo atual
        public void FecharArquivo(IEditorDeDocumentos editorDeDocumentos)
        {
            editorDeDocumentos.Arquivo = string.Empty;
            editorDeDocumentos.DocumentoAtual = string.Empty;
            editorDeDocumentos.DocumentoOriginal = string.Empty;
        }

        // Sai do aplicativo
        public void SairDoAplicativo(IEditorDeDocumentos editorDeDocumentos)
        {
            if (!string.IsNullOrEmpty(editorDeDocumentos.DocumentoAtual) || !string.IsNullOrEmpty(editorDeDocumentos.Arquivo))
            {
                if (editorDeDocumentos.DocumentoAtual != editorDeDocumentos.DocumentoOriginal)
                    if (caixaDeMensagem.MostrarPergunta("Deseja salvar o documento antes de sair?"))
                        gravacaoDeArquivos.Salvar(editorDeDocumentos);
            }

            if (!caixaDeMensagem.MostrarPergunta("Tem certeza que deseja sair?"))
                return;
           Application.Current.Shutdown();
        }
    }
}
