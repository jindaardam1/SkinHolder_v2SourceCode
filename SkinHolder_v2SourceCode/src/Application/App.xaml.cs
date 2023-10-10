using System.Windows;
using SkinHolder_v2SourceCode.Utils;

namespace SkinHolder_v2SourceCode.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            CrearRecursosNecesarios.CreacionRecursos();
        }
    }
}