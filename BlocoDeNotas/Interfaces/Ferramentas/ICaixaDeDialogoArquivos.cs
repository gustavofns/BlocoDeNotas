using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BlocoDeNotas.Interfaces.Ferramentas
{
    public interface ICaixaDeDialogoArquivos
    {
        string MostrarCaixaDeDialogo(FileDialog fileDialog, string titulo);
        string MostrarCaixaDeDialogo(FileDialog fileDialog, string titulo, string filtro);
    }
}
