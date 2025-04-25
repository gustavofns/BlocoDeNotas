using BlocoDeNotas.Interfaces.Menu.MenuArquivo;

namespace BlocoDeNotas.Menu
{
    public sealed class MenuArquivo : IGerenciamentoDeArquivos, IGerenciamentoDeJanelas
    {
        private IGerenciamentoDeArquivos _gerenciamentoDeArquivos;
        private IGerenciamentoDeJanelas _gerenciamentoDeJanelas;

        public MenuArquivo(IGerenciamentoDeArquivos gerenciamentoDeArquivos, IGerenciamentoDeJanelas gerenciamentoDeJanelas)
        {
            _gerenciamentoDeArquivos = gerenciamentoDeArquivos;
            _gerenciamentoDeJanelas = gerenciamentoDeJanelas;
        }

        public void AbrirArquivo() => _gerenciamentoDeArquivos.AbrirArquivo();
        public void NovaJanela() => _gerenciamentoDeJanelas.NovaJanela();
        public void FecharArquivo() => _gerenciamentoDeArquivos.FecharArquivo();
        public void FecharJanela() => _gerenciamentoDeJanelas.FecharJanela();
        public void Sair() => _gerenciamentoDeJanelas.Sair();
        public void SalvarArquivo() => _gerenciamentoDeArquivos.SalvarArquivo();
        public void SalvarArquivoComo() => _gerenciamentoDeArquivos.SalvarArquivoComo();
    }
}
