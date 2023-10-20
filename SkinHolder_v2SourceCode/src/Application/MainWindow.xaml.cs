using System;
using System.Windows;
using System.Windows.Input;
using SkinHolder_v2SourceCode.Views;

namespace SkinHolder_v2SourceCode.Application;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MostrarSplashScreen();
    }
        
    private void MostrarSplashScreen()
    {
        var pi = new PantallaInicio();
        MainContent.Content = pi;

        var timer = new System.Windows.Threading.DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1.2)
        };
        timer.Tick += (sender, e) =>
        {
            timer.Stop();
            MostrarMenuPrincipal();
        };
        timer.Start();
    }
        
    private void MostrarMenuPrincipal()
    {
        var menuPrincipalView = new MenuPrincipal();
        MainContent.Content = menuPrincipalView;
    }
    
    private void CerrarConEscape(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}