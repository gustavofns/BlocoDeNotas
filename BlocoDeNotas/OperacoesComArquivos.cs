using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace BlocoDeNotas
{
    public class OperacoesComArquivos
    {
        // Atributos da classe
        private MainWindow mainWindow;
        private Editor editor;
        private const string tiposDeArquivo =
            "Documentos de texto (*.txt)|*.txt|" +
            "Todos os arquivos (*.*)|*.*";

        // Construtor da classe
        public OperacoesComArquivos(MainWindow mainWindow, Editor editor)
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
        }

        // Selecionar um arquivo
        public Task<string> SelecionarArquivoTask()
        {
            var fileDialog = new OpenFileDialog()
            {
                Title = "Selecione um arquivo para abrir",
                Filter = tiposDeArquivo
            };

            if (fileDialog.ShowDialog() == true)
            {
                return Task.FromResult(fileDialog.FileName);
            }
            return Task.FromResult(String.Empty);
        }

        // Abre um arquivo
        public async Task AbrirArquivoAsync(string arquivo)
        {
            try
            {

                using (var streamReader = new StreamReader(arquivo))
                {
                    mainWindow.Arquivo = arquivo;
                    mainWindow.Documento.Clear();
                    editor.editorDeTexto.Clear();
                    mainWindow.Documento.Append(await streamReader.ReadToEndAsync());
                    editor.editorDeTexto.AppendText(mainWindow.Documento.ToString());
                    editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
                    editor.fecharArquivo.IsEnabled = true;
                    mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo}";
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Caminho inválido ou dispositivo desconectado da rede ou do dispositivo.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("O arquivo não foi encontrado!" +
                    "\nEle pode ter sido excluído ou movido durante a leitura.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (IOException)
            {
                MessageBox.Show("Não foi possível abrir o arquivo!" +
                    "\nO arquivo pode estar sendo utilizado por outro programa.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Você não tem permissão para abrir o arquivo!" +
                    "\nTente usar outra conta de usuário",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro desconhecido: {ex.Message}" +
                    $"\nPor favor reporte este erro na página do Github",
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        // Salva arquivo com
        public async Task SalvarArquivoAsync(string salvar)
        {
            var fileDialog = new SaveFileDialog()
            {
                Title = salvar,
                Filter = tiposDeArquivo
            };

            if (fileDialog.ShowDialog() == true)
            {
                mainWindow.Arquivo = fileDialog.FileName;
                editor.fecharArquivo.IsEnabled = true;
                mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo}";
                await GravarArquivoAsync();
            }
        }

        // Salvar arquivo
        public async Task GravarArquivoAsync()
        {
            try
            {
                using (var streamWriter = new StreamWriter(mainWindow.Arquivo))
                {
                    mainWindow.Documento.Clear();
                    mainWindow.Documento.Append(editor.editorDeTexto.Text);
                    await streamWriter.WriteAsync(editor.editorDeTexto.Text);
                }
                mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo} - O arquivo foi salvo com sucesso";
                await Task.Delay(1000).AsAsyncAction();
                mainWindow.Title = $"Bloco de notas - {mainWindow.Arquivo}";
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Caminho inválido ou dispositivo desconectado da rede ou do dispositivo.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (IOException)
            {
                MessageBox.Show("Não foi possível salvar o arquivo!" +
                    "\nO arquivo pode estar sendo utilizado por outro programa.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Você não tem permissão para salvar o arquivo!" +
                    "\nTente usar outra conta de usuário ou salvar em outro local.",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro desconhecido: {ex.Message}" +
                    $"\nPor favor reporte este erro na página do Github",
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }

        public Task<bool> RenomearArquivoAsync(string arquivo)
        {
            if (File.Exists(arquivo))
            {
                return Task.FromResult(false);
            }
            else
            {
                return Task.FromResult(true);
            }
        }
    }
}