using BlocoDeNotas.Interfaces.Utilitarios;
using Microsoft.Win32;

namespace BlocoDeNotas.Utilitarios
{
    public class CaixaDeDialogodeArquivos : ICaixaDeDialogodeArquivos
    {
        private string _tiposDeArquivos = "Documentos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";

        public CaixaDeDialogodeArquivos() { }

        public string CaixaDeDialogo(FileDialog fileDialog, string titulo)
        {
            fileDialog.Title = titulo;
            fileDialog.Filter = _tiposDeArquivos;
            if (fileDialog.ShowDialog() == true)
                return fileDialog.FileName;
            else return string.Empty;
        }
    }
}
