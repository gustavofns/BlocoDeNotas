using System.Windows;
using System.Windows.Threading;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;

namespace BlocoDeNotas.Eventos
{
    public class EventosDoAplicativo
    {
        private string _tituloAtual = string.Empty;
        private readonly IJanela _janela;
        private readonly IBarraDeMenu _barraDeMenu;
        private readonly IEditorDeDocumentos _editorDeDocumentos;

        public EventosDoAplicativo(IJanela  janela, IEditorDeDocumentos editorDeDocumentos, IBarraDeMenu barraDeMenu)
        {
            _janela = janela;
            _barraDeMenu = barraDeMenu;
            _editorDeDocumentos = editorDeDocumentos;
            Disparador();
        }

        private void Disparador()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += VerificarAreaDeTransferencia;
            timer.Tick += HabilitarMenuFechar;
            timer.Tick += AtualizarBarraDeTitulo;
            timer.Start();
        }

        private void VerificarAreaDeTransferencia(object? sender, EventArgs e)
        {
            bool areaDeTransferencia = Clipboard.ContainsText();
            _barraDeMenu.ColarMenu.IsEnabled = areaDeTransferencia;
        }

        private void HabilitarMenuFechar(object? sender, EventArgs e)
        {
            bool documentoVazio = string.IsNullOrEmpty(_editorDeDocumentos.Arquivo);
            _barraDeMenu.FecharDocumentoMenu.IsEnabled = !documentoVazio;
        }

        private void AtualizarBarraDeTitulo(object? sender, EventArgs e)
        {
            string tituloAtualizado;

            if (string.IsNullOrEmpty(_editorDeDocumentos.Arquivo))
            {
                if (_editorDeDocumentos.Documento.Text.Length == 0)
                    tituloAtualizado = "Bloco de notas";
                else tituloAtualizado = "Bloco de notas - documento não salvo";
            }
            else
            {
                if (_editorDeDocumentos.Documento.Text == _editorDeDocumentos.DocumentoOriginal.ToString())
                    tituloAtualizado = $"Bloco de notas - {_editorDeDocumentos.Arquivo}";
                else tituloAtualizado = $"Bloco de notas - {_editorDeDocumentos.Arquivo} - documento modificado";
            }

            if (_tituloAtual != tituloAtualizado)
                _janela.TituloJanela(tituloAtualizado);
        }
    }
}
