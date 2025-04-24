using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Menu;
using BlocoDeNotas.Interfaces.Menu.MenuEditar;

namespace BlocoDeNotas.Menu
{
    public class MenuEditar : IMenuEditar
    {
        private readonly IAcoesDoDocumento _acoesDoDocumento;
        private readonly ITextoSelecionado _textoSelecionado;
        private readonly IAreaDeTransferencia _areaDeTransferencia;
        private readonly IDataEHora _dataEHora;

        public MenuEditar(IAcoesDoDocumento acoesDoDocumento, ITextoSelecionado textoSelecionado, IAreaDeTransferencia areaDeTransferencia, IDataEHora dataEHora)
        {
            _acoesDoDocumento = acoesDoDocumento;
            _textoSelecionado = textoSelecionado;
            _areaDeTransferencia = areaDeTransferencia;
            _dataEHora = dataEHora;
        }

        public string Colar() => _areaDeTransferencia.Colar();
        public void Copiar() => _areaDeTransferencia.Copiar();
        public void Desfazer() => _acoesDoDocumento.Desfazer();
        public void Excluir() => _textoSelecionado.Excluir();
        public void InserirData() => _dataEHora.InserirData();
        public void InserirDataHora() => _dataEHora.InserirDataHora();
        public void InserirHora() => _dataEHora.InserirHora();
        public void InverterSelecao() => _textoSelecionado.InverterSelecao();
        public void Recortar() => _areaDeTransferencia.Recortar();
        public void Refazer() => _acoesDoDocumento.Refazer();
        public void SelecionarTudo() => _textoSelecionado.SelecionarTudo();
    }
}
