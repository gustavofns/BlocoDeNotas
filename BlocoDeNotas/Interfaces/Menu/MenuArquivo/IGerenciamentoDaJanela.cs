﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface IGerenciamentoDaJanela
    {
        void AbrirNovaJanela();
        void FecharJanela();
        void FecharArquivo();
        void SairDoAplicativo();
    }
}
