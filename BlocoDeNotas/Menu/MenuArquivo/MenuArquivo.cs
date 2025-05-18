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
        private readonly ILeituraDeArquivos _leituraDeArquivos;
        private readonly IGravacaoDeArquivos _gravacaoDeArquivos;
        private readonly IGerenciamentoDaJanela _gerenciamentoDaJanela;

        public MenuArquivo(ILeituraDeArquivos leituraDeArquivos, IGravacaoDeArquivos gravacaoDeArquivos, 
            IGerenciamentoDaJanela gerenciamentoDaJanela) 
        {
            _leituraDeArquivos = leituraDeArquivos;
            _gravacaoDeArquivos = gravacaoDeArquivos;
            _gerenciamentoDaJanela = gerenciamentoDaJanela;
        }


        public void AbrirNovaJanela() => _gerenciamentoDaJanela.AbrirNovaJanela();
        public void FecharJanela() => _gerenciamentoDaJanela.FecharJanela();
        public void AbrirArquivo() => _leituraDeArquivos.AbrirArquivo();
        public void Salvar() => _gravacaoDeArquivos.Salvar();
        public void SalvarComo() => _gravacaoDeArquivos.SalvarComo();
        public void FecharArquivo() => _gerenciamentoDaJanela.FecharArquivo();
        public void SairDoAplicativo() => _gerenciamentoDaJanela.SairDoAplicativo();
    }
}
