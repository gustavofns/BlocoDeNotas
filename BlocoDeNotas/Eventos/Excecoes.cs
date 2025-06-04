using BlocoDeNotas.Interfaces.Eventos;
using BlocoDeNotas.Interfaces.Ferramentas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlocoDeNotas.Eventos
{
    public class Excecoes(ICaixaDeMensagem caixaDeMensagem) : IExcecoes
    {
        // exibi uma messagem de erro
        public void ExibirMensagemExcecao(Exception ex)
        {
            caixaDeMensagem.MostrarMensagem(
                MessageBoxImage.Error,
                TratarExcecao(ex)
            );
        }

        // Retorna uma mensagem de erro de acordo com o tipo de exceção
        private string TratarExcecao(Exception ex)
        {
            switch (ex)
            {
                case DirectoryNotFoundException:
                    return "A pasta ou o arquivo não foi encontrado.";
                case EndOfStreamException:
                    return "Ocorreu um erro ao ler o arquivo.";
                case FileFormatException:
                    return "O formato do arquivo não é suportado.";
                case FileLoadException:
                    return "O arquivo não pôde ser lido.";
                case FileNotFoundException:
                    return "O arquivo não foi encontrado.";
                case PathTooLongException:
                    return "O caminho do arquivo é muito longo.";
                case UnauthorizedAccessException:
                    return "Você não tem permissão para acessar esse arquivo.";
                case IOException:
                    return "Ocorreu um erro de leitura/gravação no arquivo";
                default:
                    return "Ocorreu um erro desconhecido:\n" + ex.Message;
            }
        }
    }
}
