using BlocoDeNotas.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable WPF0001

namespace BlocoDeNotas.Menu
{
    public class MenuArquivo
    {
        // Atributos e objetos
        private MainWindow mainWindow;
        private Editor editor;
        private Eventos eventos;
        private OperacoesComArquivos operacoesComArquivos;

        public MenuArquivo(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            eventos = new Eventos(mainWindow, editor);
            operacoesComArquivos = new OperacoesComArquivos();
        }

        // Cria uma nova janela
        public void NovaJanela()
        {
            var novaJanela = new MainWindow();
            novaJanela.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            novaJanela.Show();
        }

        // Fecha a janela
        public void FecharJanela()
        {
            mainWindow.Close();
        }

        // Copia os atributos do arquivo
        private async Task CopiarAtributos()
        {
            mainWindow.Documento.Append(await operacoesComArquivos.AbrirArquivoAsync(mainWindow.Arquivo));
            editor.fecharArquivo.IsEnabled = true;
            mainWindow.TextoModificado = false;
            eventos.AtualizarBarraDeTítulo();
        }

        // Abre um arquivo
        public async void AbrirArquivo()
        {
            string? arquivo = await operacoesComArquivos.SelecionarArquivoAsync();
            if (!(string.IsNullOrEmpty(arquivo)))
            {
                FecharArquivo();
                editor.editorDeTexto.Text = await operacoesComArquivos.AbrirArquivoAsync(arquivo);
                if(editor.editorDeTexto.Text != null)
                    editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                mainWindow.Arquivo = arquivo;
                await CopiarAtributos();
            }
            else return;
        }

        // Salva um arquivo
        public async void SalvarArquivo()
        {
            if (string.IsNullOrEmpty(mainWindow.Arquivo))
            {
                string? arquivo = await operacoesComArquivos.SalvarArquivoAsync(editor.editorDeTexto.Text);
                if (!(string.IsNullOrEmpty(arquivo)))
                {
                    mainWindow.Arquivo = arquivo;
                    await CopiarAtributos();
                }
                else return;
            }
            if (mainWindow.TextoModificado)
            {
                mainWindow.Documento.Clear();
                await operacoesComArquivos.GravarArquivoAsync(mainWindow.Arquivo, editor.editorDeTexto.Text);
                mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo} - O arquivo foi salvo com sucesso";
                await Task.Delay(1000).AsAsyncAction();
                await CopiarAtributos();
            }
            else return;
        }

        // Salva um arquivo como
        public async void SalvarArquivoComo()
        {
            string? arquivo = await operacoesComArquivos.SalvarArquivoAsync(editor.editorDeTexto.Text);
            if (!(string.IsNullOrEmpty(arquivo)))
            {
                mainWindow.Arquivo = arquivo;
                await CopiarAtributos();
            }
            else return;
        }

        // Fecha um arquivo
        public void FecharArquivo()
        {
            mainWindow.Documento.Clear();
            editor.editorDeTexto.Clear();
            mainWindow.Arquivo = string.Empty;
            mainWindow.TextoModificado = false;
            editor.fecharArquivo.IsEnabled = false;
            eventos.AtualizarBarraDeTítulo();
        }

        // Sair do aplicativo
        public void Sair()
        {

            if (MessageBox.Show("Tem certeza que deseja sair do aplicativo?\n" +
                "Todos os documentos não salvos serão perdidos!", 
                "Bloco de notas", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
            else return;
        }
    }
}
