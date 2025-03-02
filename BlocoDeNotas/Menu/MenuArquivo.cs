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
        private OperacoesComArquivos operacoesComArquivos;

        // Construtores da classe
        public MenuArquivo() { }

        public MenuArquivo(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            operacoesComArquivos = new OperacoesComArquivos(mainWindow, editor);
        }

        // Cria uma nova janela
        public void NovaJanela()
        {
            var novaJanela = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
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
                string arquivo = await operacoesComArquivos.SelecionarArquivoTask();
                if (!string.IsNullOrEmpty(arquivo))
                {
                    await operacoesComArquivos.AbrirArquivoAsync(arquivo);
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
                    await operacoesComArquivos.SalvarArquivoAsync("Selecione um local para salvar o documento");
                    return;
                }
                if (mainWindow.TextoModificado) await operacoesComArquivos.GravarArquivoAsync();
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
                await operacoesComArquivos.SalvarArquivoAsync("Selecione como deseja salvar o arquivo...");
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
            editor.fecharArquivo.IsEnabled = false;
            mainWindow.Title = "Bloco de notas";
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
