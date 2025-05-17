using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Interfaces.Ferramentas
{
    public interface ICaixaDeMensagem
    {
        void MostrarMensagem(string mensagem);
        bool MostrarPergunta(string mensagem);
        void MostrarMensagem(MessageBoxImage icone, string mensagem);
        bool MostrarPergunta(MessageBoxImage icone, string mensagem);
    }
}
