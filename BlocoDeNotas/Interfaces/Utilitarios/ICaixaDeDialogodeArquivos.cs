using Microsoft.Win32;

namespace BlocoDeNotas.Interfaces.Utilitarios
{
    public interface ICaixaDeDialogodeArquivos
    {
        string CaixaDeDialogo(FileDialog fileDialog, string titulo);
    }
}
