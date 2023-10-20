using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SkinHolder_v2SourceCode.Views;

public partial class MenuPrincipal : UserControl
{
    public MenuPrincipal()
    {
        InitializeComponent();
    }
    
    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        var grid = (Grid)sender;
        
        var window = Window.GetWindow(grid);

        if (window != null)
        {
            grid.Width = window.ActualWidth / 1.3;
            grid.Height = window.ActualHeight / 1.3;
        }
    }
}