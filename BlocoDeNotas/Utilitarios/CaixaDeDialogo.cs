using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlocoDeNotas.Interfaces.Utilitarios;

namespace BlocoDeNotas.Utilitarios
{
    class CaixaDeDialogo : ICaixaDeDialogo
    {
        public void MostrarCaixaDeDialogo(string titulo, string mensagem, MessageBoxButton botao)
        {
            MessageBox.Show(mensagem, titulo, botao);
        }

        public void MostrarCaixaDeDialogo(string titulo, string mensagem, MessageBoxImage icone, MessageBoxButton botao)
        {
            MessageBox.Show(mensagem, titulo, botao, icone);
        }

        public bool MostrarCaixaDeDialogoConfirmacao(string titulo, string mensagem, MessageBoxButton botao)
        {
            var resultado = MessageBox.Show(mensagem, titulo, botao);
            return ResultadoCaixaDeDialogo(resultado);
        }

        public bool MostrarCaixaDeDialogoConfirmacao(string titulo, string mensagem, MessageBoxImage icone, MessageBoxButton botao)
        {
            var resultado = MessageBox.Show(mensagem, titulo, botao, icone);
            return ResultadoCaixaDeDialogo(resultado);
        }

        private bool ResultadoCaixaDeDialogo(MessageBoxResult resultado)
        {
            if (resultado == MessageBoxResult.Yes || resultado == MessageBoxResult.OK)
                return true;
            else return false;
        }
    }
}
