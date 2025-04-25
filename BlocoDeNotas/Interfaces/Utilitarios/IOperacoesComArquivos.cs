namespace BlocoDeNotas.Interfaces.Utilitarios
{
    public interface IOperacoesComArquivos
    {
        void LerArquivo(string caminho);
        void GravarArquivo(string caminho);
    }
}
