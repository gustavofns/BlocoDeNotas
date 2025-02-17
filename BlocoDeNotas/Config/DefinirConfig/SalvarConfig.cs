namespace BlocoDeNotas.Config.DefinirConfig
{
    public class SalvarConfig
    {
        // Salva o status da barra de status
        public void SalvarStatusBarraDeStatus(bool mostrarBarraDeStatus)
        {
            Properties.Settings.Default.BarraDeStatus = mostrarBarraDeStatus;
            Properties.Settings.Default.Save();
        }

        // Salva o tamanho da fonte
        public void SalvarTamanhoFonte(int tamanhoFonte)
        {
            Properties.Settings.Default.TamanhoFonte = tamanhoFonte;
            Properties.Settings.Default.Save();
        }

        // Salva o tema atual
        public void SalvarTema(string tema)
        {
            Properties.Settings.Default.Tema = tema;
            Properties.Settings.Default.Save();
        }
    }
}
