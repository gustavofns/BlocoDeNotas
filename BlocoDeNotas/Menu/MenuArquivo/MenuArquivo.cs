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
    public class MenuArquivo(IEditorDeDocumentos editorDeDocumentos, ILeituraDeArquivos leituraDeArquivos,
        IGravacaoDeArquivos gravacaoDeArquivos, IGerenciamentoDaJanela gerenciamentoDaJanela) : IMenuArquivo
    {

        public void AbrirNovaJanela() => gerenciamentoDaJanela.AbrirNovaJanela();
        public void FecharJanela() => gerenciamentoDaJanela.FecharJanela();
        public void AbrirArquivo() => leituraDeArquivos.AbrirArquivo(editorDeDocumentos);
        public void Salvar() => gravacaoDeArquivos.Salvar(editorDeDocumentos);
        public void SalvarComo() => gravacaoDeArquivos.SalvarComo(editorDeDocumentos);
        public void FecharArquivo() => gerenciamentoDaJanela.FecharArquivo(editorDeDocumentos);
        public void SairDoAplicativo() => gerenciamentoDaJanela.SairDoAplicativo(editorDeDocumentos);
    }
}
