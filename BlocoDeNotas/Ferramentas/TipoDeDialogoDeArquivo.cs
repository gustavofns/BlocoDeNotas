using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoDeNotas.Ferramentas
{
    public abstract class TipoDeDialogoDeArquivo
    {
        public const string ArquivosPadrao = "Documentos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
        abstract public FileDialog DialogoDeArquivo();
    }

    public class DialogoDeArquivoAbrir : TipoDeDialogoDeArquivo
    {
        public override FileDialog DialogoDeArquivo()
        {
            return new OpenFileDialog
            {
                Title = "Selecione um documento para abrir",
                Filter = ArquivosPadrao,
            };
        }
    }

    public class DialogoDeArquivoSalvar : TipoDeDialogoDeArquivo
    {
        public override FileDialog DialogoDeArquivo()
        {
            return new SaveFileDialog()
            {
                Title = "Selecione um local para salvar o documento",
                Filter = ArquivosPadrao,
            };
        }
    }
}
