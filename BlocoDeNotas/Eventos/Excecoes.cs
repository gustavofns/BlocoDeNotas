using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlocoDeNotas.Interfaces.Eventos;

namespace BlocoDeNotas.Eventos
{
    public class Excecoes : IExcecoes
    {
        public void ExibirMensagemExcecao(string titulo, Exception ex)
        {
            MessageBox.Show(
                TratarExcecao(ex),
                titulo,
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }

        public string TratarExcecao(Exception ex)
        {
            switch (ex)
            {
                case ArgumentException:
                    return "O caminho do arquivo é inválido.";
                case DirectoryNotFoundException:
                    return "A pasta não foi encontrado.";
                case EndOfStreamException:
                    return "Ocorreu um erro ao ler o arquivo.";
                case FileFormatException:
                    return "O formato do arquivo não é suportado.";
                case FileLoadException:
                    return "O arquivo não pôde ser carregado.";
                case FileNotFoundException:
                    return "O arquivo não foi encontrado.";
                case NotSupportedException:
                    return "A operação de arquivo não é suportada";
                case PathTooLongException:
                    return "O caminho do arquivo é muito longo.";
                case UnauthorizedAccessException:
                    return "Você não tem permissão para acessar este arquivo.";
                case IOException:
                    return "Ocorreu um erro de leitura/gravação ao acessar o arquivo.";
                default:
                    return "Ocorreu um erro desconhecido:\n" + ex.Message;
            }
        }
    }
}
