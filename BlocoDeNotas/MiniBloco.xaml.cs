using System.Windows;
using System.Windows.Input;

namespace BlocoDeNotas
{
    /// <summary>
    /// Lógica interna para MiniBloco.xaml
    /// </summary>
    public partial class MiniBloco : Window
    {
        private MainWindow mainWindow;
        private Editor editor;

        public MiniBloco(MainWindow mainWindow, Editor editor)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.editor = editor;
        }

        private void MoverJanela_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowInTaskbar = false;
            mainWindow.Hide();
            miniEditor.Text = editor.editorDeTexto.Text;
            miniEditor.CaretIndex = miniEditor.Text.Length;
            miniEditor.Focus();
        }

        private void Editor_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowInTaskbar = true;
            mainWindow.Show();
            editor.editorDeTexto.Text = miniEditor.Text;
            editor.editorDeTexto.CaretIndex = editor.editorDeTexto.Text.Length;
            Close();
        }
    }
}
