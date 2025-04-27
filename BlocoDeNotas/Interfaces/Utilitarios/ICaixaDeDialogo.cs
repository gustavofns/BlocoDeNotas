using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Interfaces.Utilitarios
{
    public interface ICaixaDeDialogo
    {
        void MostrarCaixaDeDialogo(string titulo, string mensagem , MessageBoxButton botao);
        void MostrarCaixaDeDialogo(string titulo, string mensagem , MessageBoxImage icone, MessageBoxButton botao);
        bool MostrarCaixaDeDialogoConfirmacao(string titulo, string mensagem, MessageBoxButton botao);
        bool MostrarCaixaDeDialogoConfirmacao(string titulo, string mensagem, MessageBoxImage icone, MessageBoxButton botao);
    }
}
