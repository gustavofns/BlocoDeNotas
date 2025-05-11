using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Janela;
using BlocoDeNotas.Interfaces.UI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BlocoDeNotas.Eventos
{
    public class AtualizarTituloDaJanela : IAtualizarTituloJanela
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public AtualizarTituloDaJanela(IJanela janela, IEditorDeDocumentos editorDeDocumentos)
        {
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
            Disparador();
        }

        private void Disparador()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += AtualizarTitulo;
            timer.Start();

        }
        
        private void AtualizarTitulo(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
            {
                if (_editorDeDocumentos.DocumentoAtual.Length != 0)
                {
                    _janela.TituloJanela = "Bloco de notas - documento não salvo";
                }
                else
                {
                    _janela.TituloJanela = "Bloco de notas";
                }
            
            }
            else
            {
                if (_editorDeDocumentos.DocumentoOriginal == _editorDeDocumentos.DocumentoAtual)
                {
                    _janela.TituloJanela = $"Bloco de notas - {_editorDeDocumentos.Arquivo}";
                }
                else
                {
                    _janela.TituloJanela = $"Bloco de notas - {_editorDeDocumentos.Arquivo} - documento modificado";
                }
            }
        }
    }
}
