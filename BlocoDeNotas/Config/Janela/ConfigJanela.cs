using BlocoDeNotas.Interfaces.Config.Janela;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace BlocoDeNotas.Config.Janela
{
    public class ConfigJanela : IConfiguracoesDaJanela
    {
        public WindowState CarregarEstadoJanela()
        {
            if(Properties.Settings.Default.JanelaMaximada)
                return WindowState.Maximized;
            else
                return WindowState.Normal;
        }

        public (double posicaoX, double posicaoY) CarregarPosicaoJanela()
        {
            double posicaoX = Properties.Settings.Default.PosicaoXJanela;
            double posicaoY = Properties.Settings.Default.PosicaoYJanela;
            return (posicaoX, posicaoY);
        }

        public (double altura, double largura) CarregarTamanhoJanela()
        {
            double altura = Properties.Settings.Default.AlturaJanela;
            double largura = Properties.Settings.Default.LarguraJanela;
            return (altura, largura);
        }

        public void SalvarEstadoJanela(WindowState estado)
        {
            bool estadoDaJanela;
            if (estado == WindowState.Maximized)
                estadoDaJanela = true;
            else 
                estadoDaJanela = false;
            SalvarConfiguracao("JanelaMaximada", estadoDaJanela);
        }

        public void SalvarPosicaoJanela(double posicaoX, double posicaoY)
        {
            SalvarConfiguracao("PosicaoXJanela", posicaoX);
            SalvarConfiguracao("PosicaoYJanela", posicaoY);
        }

        public void SalvarTamanhoJanela(double altura, double largura)
        {
            SalvarConfiguracao("AlturaJanela", altura);
            SalvarConfiguracao("LarguraJanela", largura);
        }

        private void SalvarConfiguracao<T>(string atributo, T valor)
        {
            Properties.Settings.Default[atributo] = valor;
            Properties.Settings.Default.Save();
        }
    }
}
