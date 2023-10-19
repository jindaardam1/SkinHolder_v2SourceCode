using System;
using System.Windows;
using System.Windows.Threading;
using SkinHolder_v2SourceCode.Utils;
using SkinHolder_v2SourceCode.Views;

namespace SkinHolder_v2SourceCode.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CrearRecursosNecesarios.CreacionRecursos();
            base.OnStartup(e);
        }
    }
}