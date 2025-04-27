using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.Componentes
{
    public interface IBarraDeMenu
    {
        MenuItem FecharDocumentoMenu { get; }
        MenuItem DesfazerMenu { get; }
        MenuItem RefazerMenu { get; }
        MenuItem RecortarMenu { get; }
        MenuItem CopiarMenu { get; }
        MenuItem ColarMenu { get; }
        MenuItem ExcluirMenu { get; }
    }
}
