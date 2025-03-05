using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable CS8603

namespace BlocoDeNotas.IO
{
    public class OperacoesComArquivos
    {
        // Atributos da classe
        private const string tiposDeArquivo =
            "Documentos de texto (*.txt)|*.txt|" +
            "Todos os arquivos (*.*)|*.*";

        // Selecionar um arquivo
        public Task<string> SelecionarArquivoAsync()
        {
            try
            {
                var fileDialog = new OpenFileDialog()
                {
                    Title = "Selecione um arquivo para abrir",
                    Filter = tiposDeArquivo
                };
                if (fileDialog.ShowDialog() == true)
                    return Task.FromResult(fileDialog.FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível abrir o arquivo:\n{e.Message}",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            return Task.FromResult(String.Empty);
        }

        // Abre um arquivo
        public async Task<string?> AbrirArquivoAsync(string arquivo)
        {
            try
            { 
                using (var streamReader = new StreamReader(arquivo))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível abrir o arquivo:\n{e.Message}", 
                    "Bloco de notas", MessageBoxButton.OK);
                return null;
            }
        }

        // Seleciona o local para salvar um arquivo e grava o arquivo
        public async Task<string?> SalvarArquivoAsync(string texto)
        {
            try
            {
                var fileDialog = new SaveFileDialog()
                {
                    Title = "Selecione onde deseja salvar o arquivo",
                    Filter = tiposDeArquivo,
                };

                if (fileDialog.ShowDialog() == true)
                {
                    await GravarArquivoAsync(fileDialog.FileName, texto);
                    return fileDialog.FileName;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi salvar o arquivo:\n{e.Message}",
                    "Bloco de notas", MessageBoxButton.OK);
            }
            return string.Empty;
        }

        // Grava um arquivo
        public async Task GravarArquivoAsync(string arquivo, string texto)
        {
            try
            {
                using (var streamWriter = new StreamWriter(arquivo))
                {
                    await streamWriter.WriteAsync(texto);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível salvar o arquivo:\n{e.Message}",
                    "Bloco de notas", MessageBoxButton.OK);
            }
        }
    }
}
