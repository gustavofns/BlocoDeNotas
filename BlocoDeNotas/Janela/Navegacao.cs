using BlocoDeNotas.Interfaces.Navegacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlocoDeNotas.Janela
{
    public class Navegacao : INavegacao
    {
        private readonly Frame _frame;

        public Navegacao(Frame frame)
        {
            _frame = frame;
        }

        public void NavegarPara(object objeto)
        {
            if (objeto != null)
               _frame.Navigate(objeto);
        }

        public bool Voltar()
        {
            if(_frame.CanGoBack)
            {
                _frame.GoBack();
                return true;
            }
            else return false;
        }
    }
}
