using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlocoDeNotas.Aplicativo;
using BlocoDeNotas.Interfaces;
using BlocoDeNotas.Interfaces.Componentes;
using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Menu.MenuArquivo;
using BlocoDeNotas.Interfaces.Utilitarios;
using Microsoft.Win32;

namespace BlocoDeNotas.Menu.ItensMenuArquivo
{
    public class GerenciamentoDeArquivos : IGerenciamentoDeArquivos
    {
        private readonly IJanela _janela;
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly ICaixaDeDialogodeArquivos _caixaDeDialogodeArquivos;
        private readonly IExcecoes _excecoes;
        private readonly IBarraDeMenu _barraDeMenu;

        public GerenciamentoDeArquivos(IJanela janela, IEditorDeDocumentos editorDeDocumentos,
            ICaixaDeDialogodeArquivos caixaDeDialogodeArquivos, IExcecoes excecoes, IBarraDeMenu barraDeMenu)
        {
            _janela = janela;
            _editorDeDocumentos = editorDeDocumentos;
            _caixaDeDialogodeArquivos = caixaDeDialogodeArquivos;
            _excecoes = excecoes;
            _barraDeMenu = barraDeMenu;
        }

        public void AbrirArquivo()
        {
            LerArquivo(_caixaDeDialogodeArquivos.CaixaDeDialogo
                (new OpenFileDialog(), "Selecione um documento para abrir"));
        }

        public void FecharArquivo()
        {
            _barraDeMenu.HabilitarFecharArquivo(false);
            _editorDeDocumentos.Arquivo = string.Empty;
            _editorDeDocumentos.Documento.Clear();
            _editorDeDocumentos.DocumentoOriginal.Clear();
            _janela.TituloJanela("Bloco de notas");
        }

        public void SalvarArquivo()
        {
            if (_editorDeDocumentos.Arquivo != string.Empty)
            {
                GravarArquivo(_editorDeDocumentos.Arquivo);
            }
            else
            {
                SalvarArquivoComo();
            }
        }

        public void SalvarArquivoComo()
        {
            GravarArquivo(_caixaDeDialogodeArquivos.CaixaDeDialogo
                (new SaveFileDialog(), "Selecione um local para salvar o documento"));
        }

        private void LerArquivo(string arquivo)
        {
            if (arquivo == string.Empty) 
            {
                return;
            }

            try
            {
                using (var sr = new StreamReader(arquivo))
                {
                    _editorDeDocumentos.Documento.AppendText(sr.ReadToEnd());
                    _editorDeDocumentos.Documento.CaretIndex = _editorDeDocumentos.Documento.Text.Length;
                }
                CopiarAtributos(arquivo);
                _barraDeMenu.HabilitarFecharArquivo(true);
            }
            catch (Exception ex)
            {
                _excecoes.ExibirMensagemExcecao("Não foi possível abrir o documento", ex);
                _editorDeDocumentos.Arquivo = string.Empty;
            }
        }

        private void GravarArquivo(string arquivo)
        {
            if (arquivo == string.Empty)
            {
                return;
            }

            try
            {
                using(var sw = new StreamWriter(arquivo))
                {
                    sw.Write(_editorDeDocumentos.Documento.Text);
                    _editorDeDocumentos.Arquivo = arquivo;
                }
                CopiarAtributos(arquivo);
            }
            catch (Exception ex)
            {
                _excecoes.ExibirMensagemExcecao("Não foi possível salvar o documento", ex);
            }
        }

        private void CopiarAtributos(string arquivo)
        {
            _editorDeDocumentos.Arquivo = arquivo;
            _editorDeDocumentos.DocumentoOriginal.Clear();
            using (var sr = new StreamReader(arquivo))
            {
                _editorDeDocumentos.DocumentoOriginal.Append(sr.ReadToEnd());
            }
            _janela.TituloJanela($"Bloco de notas - {_editorDeDocumentos.Arquivo}");
        }
    }
}
