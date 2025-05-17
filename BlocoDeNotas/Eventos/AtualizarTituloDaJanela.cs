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

        public AtualizarTituloDaJanela(IJanela janela)
        {
            _janela = janela;
        }

        public void AtualizarTitulo(string arquivo, string documentoAtual, string documentoOriginal)
        {
            string novoTitulo = NovoTitulo(arquivo, documentoAtual, documentoOriginal);

            if (_janela.TituloJanela != novoTitulo)
                _janela.TituloJanela = novoTitulo;
        }

        private string NovoTitulo(string arquivo, string documentoAtual, string documentoOriginal)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                if (documentoAtual.Length != 0)
                    return "Bloco de notas - documento não salvo";
                else return "Bloco de notas";

            }
            else
            {
                if (documentoOriginal == documentoAtual)
                    return $"Bloco de notas - {arquivo}";
                else return $"Bloco de notas - {arquivo} - documento modificado";
            }
        }
    }
}
