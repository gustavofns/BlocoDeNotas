using BlocoDeNotas.Interfaces.Janela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BlocoDeNotas.Janela
{
    public class Navegacao : INavegacao
    {
        public Frame Frame { get; }

        public Navegacao()
        {
            Frame = CriarFrame();
        }

        private Frame CriarFrame()
        {
            var frame = new Frame()
            {
                NavigationUIVisibility = NavigationUIVisibility.Hidden,
            };
            return frame;
        }

        public void NavegarPara(object objeto)
        {
            if (objeto != null)
               Frame.Navigate(objeto);
        }

        public bool Voltar()
        {
            if(Frame.CanGoBack)
            {
                Frame.GoBack();
                return true;
            }
            else return false;
        }
    }
}
