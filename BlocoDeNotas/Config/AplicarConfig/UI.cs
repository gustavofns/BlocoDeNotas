﻿using BlocoDeNotas.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace BlocoDeNotas.Config.AplicarConfig
{
    public class UI
    {
        private Editor editor;

        public UI(Editor editor) 
        { 
            this.editor = editor;
        }

        // Usar icones coloridos
        public void IconesColoridos(bool config)
        {
            var ui = (Brush)Application.Current.Resources[""];

            if (config) ui = (Brush)Application.Current.Resources["AccentTextFillColorTertiaryBrush"];
            else ui = (Brush)Application.Current.Resources["TextFillColorPrimaryBrush"];

            // Aplica a cor ao menu principal
            editor.iconeMenuArquivo.Foreground = ui;
            editor.iconeMenuEditar.Foreground = ui;
            editor.iconeMenuExibir.Foreground = ui;
            editor.iconeMenuFerramentas.Foreground = ui;

            // Aplica a cor as ferramentas rápidas
            editor.abrirConfigRapidas.Foreground = ui;
            editor.salvarConfigRapidas.Foreground = ui;
            editor.salvarComoConfigRapidas.Foreground = ui;
            editor.recortarConfigRapidas.Foreground = ui;
            editor.copiarConfigRapidas.Foreground = ui;
            editor.colarConfigRapidas.Foreground = ui;
            editor.excluirConfigRapidas.Foreground = ui;

            // Aplica cor aos ícones do menu direito
            editor.iconeMenuAbrirNovaJanela.Foreground = ui;
            editor.iconeMenuMiniBloco.Foreground = ui;
            editor.iconeMenuConfig.Foreground = ui;
        }

        // Habilita ou desabilta as ferramentas rápidas
        public void FerramentasRapidas(bool config)
        {
            if (config) editor.MenuFerramentasRapidas.Visibility = Visibility.Visible;
            else editor.MenuFerramentasRapidas.Visibility = Visibility.Hidden;
        }

        // Salvar configuração de ícones coloridos
        public void SalvarConfigIconesColoridos(bool config)
        {
            Properties.Settings.Default.UsarUIColorida = config;
            Properties.Settings.Default.Save();
        }

        // Salvar configuração das ferramentas rápidas
        public void SalvarConfigFerramentasRapidas(bool config)
        {
            Properties.Settings.Default.FerramentasRapidas = config;
            Properties.Settings.Default.Save();
        }

        // Aplicar configurações de UI
        public void AplicarConfigUI()
        {
            Personalizacao personalizacao = new Personalizacao(editor);

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += new EventHandler((sender, e) =>
            {
                IconesColoridos(Properties.Settings.Default.UsarUIColorida);
                FerramentasRapidas(Properties.Settings.Default.FerramentasRapidas);
                new MenuExibir(editor).CarregarBarraDeStatus(Properties.Settings.Default.BarraDeStatus);
            });

            dispatcherTimer.Start();
        }
    }
}
