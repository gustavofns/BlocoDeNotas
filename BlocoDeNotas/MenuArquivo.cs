using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using Windows.Graphics.Printing3D;
using Windows.Networking.NetworkOperators;

#pragma warning disable WPF0001

namespace BlocoDeNotas
{
    public class MenuArquivo
    {
        private MainWindow mainWindow;
        private Editor editor;
        private OperacoesComArquivos operacoesComArquivos;

        public MenuArquivo(MainWindow mainWindow, Editor editor) 
        {
            this.mainWindow = mainWindow;
            this.editor = editor;
            operacoesComArquivos = new OperacoesComArquivos(mainWindow, editor);
        }


        public void NovaJanela()
        {
            var novaJanela = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            novaJanela.Show();
        }

        public void FecharJanela()
        { 
            mainWindow.Close();
        }

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
                MessageBox.Show($"Erro ao abrir o arquivo:\n {ex.Message}", "Bloco de notas", MessageBoxButton.OK);
            }
        }

        public async void SalvarArquivo()
        {
            try 
            { 
                if (string.IsNullOrEmpty(editor.Arquivo))
                {
                    await operacoesComArquivos.SalvarArquivoAsync("Selecione um local para salvar o documento");
                    return;
                }
                if(editor.TextoModificado) await operacoesComArquivos.GravarArquivoAsync();
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo:\n {ex.Message}", "Bloco de notas", MessageBoxButton.OK);
            }

        }

        public async void SalvarArquivoComo()
        {
            try 
            { 
                await operacoesComArquivos.SalvarArquivoAsync("Selecione como deseja salvar o arquivo...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo:\n {ex.Message}", "Bloco de notas", MessageBoxButton.OK);
            }
        }

        public void FecharArquivo()
        {
            editor.Documento.Clear();
            editor.editorDeTexto.Clear();
            editor.Arquivo = string.Empty;
            editor.fecharArquivo.IsEnabled = false;
            mainWindow.Title = "Bloco de notas";
        }

        public void Sair()
        {

            if (MessageBox.Show("Tem certeza que deseja sair do aplicativo?\nTodos os documentos não salvos serão perdidos!", "Bloco de notas", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
            else return;
        }
    }
}
