using BlocoDeNotas.Interfaces.Ferramentas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Ferramentas
{
    public class CaixaDeDialogoDeArquivos : ICaixaDeDialogoArquivos
    {
        private const string ArquivosPadrao = "Documentos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";

        public string MostrarCaixaDeDialogo(FileDialog fileDialog, string titulo)
        {
            return MostrarCaixaDeDialogoDeArquivos(fileDialog, titulo, ArquivosPadrao);
        }

        public string MostrarCaixaDeDialogo(FileDialog fileDialog, string titulo, string filtro)
        {
            return MostrarCaixaDeDialogoDeArquivos(fileDialog, titulo, filtro);
        }

        private string MostrarCaixaDeDialogoDeArquivos(FileDialog fileDialog, string titulo, string filtro)
        {
            fileDialog.Title = titulo;
            fileDialog.Filter = filtro;
            if (fileDialog.ShowDialog() == true)
                return fileDialog.FileName;
            else return string.Empty;
        }
    }
}
