using BlocoDeNotas.Interfaces.Ferramentas;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
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
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly ILeituraDeArquivos _leituraDeArquivos;
        private readonly IGravacaoDeArquivos _gravacaoDeArquivos;
        private readonly IGerenciamentoDaJanela _gerenciamentoDaJanela;

        public MenuArquivo(IEditorDeDocumentos editorDeDocumentos, ILeituraDeArquivos leituraDeArquivos, IGravacaoDeArquivos gravacaoDeArquivos, 
            IGerenciamentoDaJanela gerenciamentoDaJanela) 
        {
            _editorDeDocumentos = editorDeDocumentos;
            _leituraDeArquivos = leituraDeArquivos;
            _gravacaoDeArquivos = gravacaoDeArquivos;
            _gerenciamentoDaJanela = gerenciamentoDaJanela;
        }


        public void AbrirNovaJanela() => _gerenciamentoDaJanela.AbrirNovaJanela();
        public void FecharJanela() => _gerenciamentoDaJanela.FecharJanela();
        public void AbrirArquivo() => _leituraDeArquivos.AbrirArquivo(_editorDeDocumentos);
        public void Salvar() => _gravacaoDeArquivos.Salvar(_editorDeDocumentos);
        public void SalvarComo() => _gravacaoDeArquivos.SalvarComo(_editorDeDocumentos);
        public void FecharArquivo() => _gerenciamentoDaJanela.FecharArquivo(_editorDeDocumentos);
        public void SairDoAplicativo() => _gerenciamentoDaJanela.SairDoAplicativo(_editorDeDocumentos);
    }
}
