using BlocoDeNotas.IO;
using System.Text;
using System.Windows;

#pragma warning disable WPF0001
#pragma warning disable CS8618

namespace BlocoDeNotas.Menu
{
    public class MenuArquivo
    {
        // Atributos e objetos
        private MainWindow mainWindow;
        private Editor editor;
        private Eventos eventos;
        private OperacoesComArquivos operacoesComArquivos;

        // Construtores da classe
        public MenuArquivo() { }

        public MenuArquivo(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            eventos = new Eventos(mainWindow, editor);
            operacoesComArquivos = new OperacoesComArquivos();
        }

        // Copia os atributos do arquivo
        private void CopiarAtributos(string arquivo, string documento)
        {
            mainWindow.Arquivo = arquivo;
            mainWindow.Documento.Append(documento);
            editor.fecharArquivo.IsEnabled = true;
            mainWindow.TextoModificado = false;
            eventos.AtualizarBarraDeTítulo();
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

        // Abre um arquivo
        public async void AbrirArquivo()
        {
            try
            {
                string arquivo = await operacoesComArquivos.SelecionarArquivoAsync();
                if(!(string.IsNullOrEmpty(arquivo)))
                {
                    FecharArquivo();
                    CopiarAtributos(arquivo, await operacoesComArquivos.AbrirArquivoAsync(arquivo));
                    editor.editorDeTexto.Text = await operacoesComArquivos.AbrirArquivoAsync(arquivo);
                    if(editor.editorDeTexto.Text != null)
                        editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o arquivo:\n {ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        // Salva um arquivo
        public async void SalvarArquivo()
        {
            try
            {
                if (string.IsNullOrEmpty(mainWindow.Arquivo))
                {
                    string? arquivo = await operacoesComArquivos.SalvarArquivoAsync(editor.editorDeTexto.Text.ToString());
                    if (!(string.IsNullOrEmpty(arquivo)))
                        CopiarAtributos(arquivo, editor.editorDeTexto.Text.ToString());
                    else return;
                }
                if (mainWindow.TextoModificado)
                {
                    mainWindow.Documento.Clear();
                    CopiarAtributos(mainWindow.Arquivo, editor.editorDeTexto.Text.ToString());
                    await operacoesComArquivos.GravarArquivoAsync(mainWindow.Arquivo, mainWindow.Documento.ToString());
                    mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo} - O arquivo foi salvo com sucesso";
                    await Task.Delay(1000).AsAsyncAction();
                    eventos.AtualizarBarraDeTítulo();
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo:\n {ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK);
            }

        }

        // Salva um arquivo como
        public async void SalvarArquivoComo()
        {
            try
            {
                string? arquivo = await operacoesComArquivos.SalvarArquivoAsync(editor.editorDeTexto.Text.ToString());
                if (!(string.IsNullOrEmpty(arquivo)))
                    CopiarAtributos(arquivo, editor.editorDeTexto.Text.ToString());
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo:\n {ex.Message}", 
                    "Bloco de notas", MessageBoxButton.OK);
            }
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
