using BlocoDeNotas.Menu.MenuEditar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;

namespace BlocoDeNotas.Interfaces.Menu.MenuEditar
{
    public interface IMenuEditar
    {
        void Desfazer();
        void Refazer();
        void Excluir();
        void Colar();
        void Copiar();
        void Recortar();
        void SelecionarTudo();
        void HoraAtual();
        void DataAtual();
        void DataEHoraAtual();
    }
}
