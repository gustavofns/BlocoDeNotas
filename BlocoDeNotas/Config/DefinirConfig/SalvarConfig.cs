namespace BlocoDeNotas.Config.DefinirConfig
{
    public class SalvarConfig
    {
        // Salvar o status da barra de status
        public void SalvarStatusBarraDeStatus(bool mostrarBarraDeStatus)
        {
            Properties.Settings.Default.BarraDeStatus = mostrarBarraDeStatus;
            Properties.Settings.Default.Save();
        }

        // Salvar o tamanho da fonte
        public void SalvarTamanhoFonte(int tamanhoFonte)
        {
            Properties.Settings.Default.TamanhoFonte = tamanhoFonte;
            Properties.Settings.Default.Save();
        }

        // Salvar o tema atual
        public void SalvarTema(string tema)
        {
            Properties.Settings.Default.Tema = tema;
            Properties.Settings.Default.Save();
        }

        // Habilita cor na UI
        public void UsarUIColorida(bool cor)
        {
            Properties.Settings.Default.UsarUIColorida = cor;
            Properties.Settings.Default.Save();
        }
    }
}
