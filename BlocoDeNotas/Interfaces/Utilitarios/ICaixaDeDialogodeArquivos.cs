using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BlocoDeNotas.Interfaces.Utilitarios
{
    public interface ICaixaDeDialogodeArquivos
    {
        string CaixaDeDialogo(FileDialog fileDialog, string titulo);
    }
}
