﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Interfaces.Menu.MenuArquivo
{
    public interface IMenuArquivo
    {
        void AbrirNovaJanela();
        void FecharJanela();
        void AbrirArquivo();
        void Salvar();
        void SalvarComo();
        void FecharArquivo();
        void SairDoAplicativo();
    }
}
