using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BlocoDeNotas.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlocoDeNotas.Aplicativo.Dependencias
{
    public class ContainerDeDependencias
    {
        public ContainerDeDependencias()
        {
        }

        public static void RegistarDependencias(String[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IJanela>(provider => new Janela(args));
            var serviceProvider = services.BuildServiceProvider();
            var janela = serviceProvider.GetService<IJanela>();

            if (janela == null)
            {
                throw new InvalidOperationException("O serviço IJanela não foi registrado corretamente.");
            }

            var editor = new Editor(janela);
            janela.MostrarJanela(editor);
        }
    }
}
