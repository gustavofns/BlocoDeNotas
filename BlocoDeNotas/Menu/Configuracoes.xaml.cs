﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace BlocoDeNotas.Menu
{
    /// <summary>
    /// Interação lógica para Configuracoes.xam
    /// </summary>
    public partial class Configuracoes : Page
    {
        // Atributos e objetos
        private MainWindow mainWindow;
        private Editor editor;
        private Config.Personalizacao personalizacao;
        private Config.Sobre sobre;

        // Construtor da classe
        public Configuracoes(MainWindow mainWindow, Editor editor)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.editor = editor;
            personalizacao = new Config.Personalizacao(editor);
            sobre = new Config.Sobre();
        }

        //  Eventos de carragamento da página de configurações
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.Title = Title;
            Config.Navigate(personalizacao);
        }

        // Voltar para o editor
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            new Eventos(mainWindow, editor).AtualizarBarraDeTítulo();
            mainWindow.Main.Navigate(editor);
        }

        // Evento de seleção de configuração
        private void Config_Selection(object sender, SelectionChangedEventArgs e)
        {
            int itemSelecionado = ConfigListeview.SelectedIndex;

            // Navega para a página de configuração selecionada
            switch (itemSelecionado)
            {
                case 0:
                    Config.NavigationService.Navigate(personalizacao);
                    break;
                case 1:
                    Config.NavigationService.Navigate(sobre);
                    break;
                default:
                    break;
            }
        }
    }
}
