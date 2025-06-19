using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;


namespace KazinoMrazino2;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }
    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    public MainWindow()
    {
        InitializeComponent();
    }
}