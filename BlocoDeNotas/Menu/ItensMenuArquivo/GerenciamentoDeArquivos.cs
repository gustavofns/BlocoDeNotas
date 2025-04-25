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
using BlocoDeNotas.Utilitarios;
using Microsoft.Win32;

namespace BlocoDeNotas.Menu.ItensMenuArquivo
{
    public class GerenciamentoDeArquivos : IGerenciamentoDeArquivos
    {
        private readonly IEditorDeDocumentos _editorDeDocumentos;
        private readonly ICaixaDeDialogodeArquivos _caixaDeDialogodeArquivos;
        private readonly OperacoesComArquivos _operacoesComArquivo;

        public GerenciamentoDeArquivos(IEditorDeDocumentos editorDeDocumentos, 
            ICaixaDeDialogodeArquivos caixaDeDialogodeArquivos, OperacoesComArquivos operacoesComArquivo)
        {
            _editorDeDocumentos = editorDeDocumentos;
            _caixaDeDialogodeArquivos = caixaDeDialogodeArquivos;
            _operacoesComArquivo = operacoesComArquivo;
        }

        public void AbrirArquivo()
        {
            string arquivo = _caixaDeDialogodeArquivos.CaixaDeDialogo
                (new OpenFileDialog(), "Selecione um documento para abrir");
            if (arquivo != string.Empty)
            {
                LimparEditor();
                _operacoesComArquivo.LerArquivo(arquivo);
            }
        }

        public void FecharArquivo()
        {
            LimparEditor();
        }

        public void SalvarArquivo()
        {
            if (_editorDeDocumentos.Arquivo != string.Empty)
                _operacoesComArquivo.GravarArquivo(_editorDeDocumentos.Arquivo);
            else SalvarArquivoComo();
        }

        public void SalvarArquivoComo()
        {
            string arquivo = _caixaDeDialogodeArquivos.CaixaDeDialogo
                (new SaveFileDialog(), "Selecione um local para salvar o documento");
            if (arquivo != string.Empty)
                _operacoesComArquivo.GravarArquivo(arquivo);
        }

        private void LimparEditor()
        {
            _editorDeDocumentos.Documento.Clear();
            _editorDeDocumentos.DocumentoOriginal.Clear();
            _editorDeDocumentos.Arquivo = string.Empty;
        }
    }
}