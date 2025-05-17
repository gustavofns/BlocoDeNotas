using BlocoDeNotas.Interfaces.Ferramentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Ferramentas
{
    public class CaixaDeMensagem : ICaixaDeMensagem
    {
        // Exibe um caixa de mensagem com um botão de OK sem ícone
        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(
                mensagem, 
                "Bloco de notas", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information
            );
        }

        // Exibe um caixa de mensagem com um botão de OK com ícone
        public void MostrarMensagem(MessageBoxImage icone, string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "Bloco de notas",
                MessageBoxButton.OK,
                icone
            );
        }

        // Exibe uma caixa de menssagem com uma pergunta sem ícone
        public bool MostrarPergunta(string mensagem)
        {
            var resposta = MessageBox.Show(
                mensagem,
                "Bloco de notas",
                MessageBoxButton.YesNo
            );

            if (resposta == MessageBoxResult.Yes)
                return true;
            else return false;
        }

        // Exibe uma caixa de menssagem com uma pergunta com ícone
        public bool MostrarPergunta(MessageBoxImage icone, string mensagem)
        {
            var responsa = MessageBox.Show(
                mensagem,
                "Bloco de notas",
                MessageBoxButton.YesNo,
                icone
            );

            if(responsa == MessageBoxResult.Yes) 
                return true;
            else return false;
        }
    }
}
