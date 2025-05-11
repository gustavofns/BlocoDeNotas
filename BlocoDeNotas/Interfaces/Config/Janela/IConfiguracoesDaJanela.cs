using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Interfaces.Config.Janela
{
    public interface IConfiguracoesDaJanela
    {
        (double altura, double largura) CarregarTamanhoJanela();
        (double posicaoX, double posicaoY) CarregarPosicaoJanela();
        void SalvarEstadoJanela(WindowState estado);
        void SalvarTamanhoJanela(double altura, double largura);
        void SalvarPosicaoJanela(double posicaoX, double posicaoY);
        WindowState CarregarEstadoJanela();
    }
}
