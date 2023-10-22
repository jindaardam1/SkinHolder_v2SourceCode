using System;
using System.Windows;
using System.Windows.Threading;
using SkinHolder_v2SourceCode.Controllers;
using SkinHolder_v2SourceCode.Utils;

namespace SkinHolder_v2SourceCode.Views;

public partial class MenuPrincipal
{
    private DispatcherTimer _timer = null!;
    
    public MenuPrincipal()
    {
        InitializeComponent();
    }

    private void GridValorEnSteam_OnLoaded(object sender, RoutedEventArgs e)
    {
        
    }

    private void GridValorEnBuff_OnLoaded(object sender, RoutedEventArgs e)
    {
        
    }

    private void GridCambioYuanes_OnLoaded(object sender, RoutedEventArgs e)
    {
        YuanesAEuros.Text = "1 Yuan = " + MenuPrincipalController.GetYuanesAEuros() + " euros";
        EurosAYuanes.Text = "1 Euro = " + MenuPrincipalController.GetEurosAYuanes() + " yuanes";
    }

    private void TextBlockPing_OnLoaded(object sender, RoutedEventArgs e)
    {
        TextBlockPing.Text = "Ping: " + MenuPrincipalController.GetPing("www.xe.com");
        
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(7)
        };
        _timer.Tick += Timer_Tick;

        _timer.Start();
    }
    
    private void Timer_Tick(object? sender, EventArgs e)
    {
        TextBlockPing.Text = "Ping: " + MenuPrincipalController.GetPing("www.xe.com");
    }
}