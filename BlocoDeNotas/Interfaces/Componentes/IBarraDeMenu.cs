using System.Windows.Controls;

namespace BlocoDeNotas.Interfaces.Componentes
{
    public interface IBarraDeMenu
    {
        MenuItem FecharDocumentoMenu { get; set; }
        MenuItem DesfazerMenu { get; set; }
        MenuItem RefazerMenu { get; set; }
        MenuItem RecortarMenu { get; set; }
        MenuItem CopiarMenu { get; set; }
        MenuItem ColarMenu { get; set; }
        MenuItem ExcluirMenu { get; set; }
    }
}
