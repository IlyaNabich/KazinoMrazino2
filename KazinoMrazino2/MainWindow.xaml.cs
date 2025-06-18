using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;


namespace KazinoMrazino2;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly SoundPlayer _spinSound = new(@"Resources\Sounds\spin_sound.wav");
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
        List<Image> midImageControls = [ImageMid1, ImageMid2, ImageMid3];
        List<Image> topImageControls = [ImageTop1, ImageTop2, ImageTop3];
        List<Image> botImageControls = [ImageBot1, ImageBot2, ImageBot3];
        var defaultPlayer = new DataSourse
        {
            Balance = 30000,
            Deposit = 1000,
            WinBalance = 0,
        };
        balance_label.Content = ($"Balance {defaultPlayer.Balance}");
        dep_TextBox.Text = defaultPlayer.Deposit.ToString();
        MainAlgorithm.SetAlgorithmComponent(midImageControls, topImageControls, botImageControls, dep_TextBox.Text, defaultPlayer.Balance, defaultPlayer.WinBalance);
        MainAlgorithm.DefaultSlot();
        Debug.WriteLine(defaultPlayer.Deposit);
    }
    private async void Spin_Button_Click(object sender, RoutedEventArgs e)
    {
        _spinSound.Play();
        Spin_Button.IsEnabled = false;             
        for(int i = 0; i < 10; i++)
        {
            MainAlgorithm.DefaultSlot();
            await Task.Delay(200);
        }            
        balance_label.Content = $"Balance {MainAlgorithm.WinCalculator()}";
        Spin_Button.IsEnabled = true;
    }
    private void Dep_button_1_click(object sender, RoutedEventArgs e)
    {       
        MainAlgorithm.SetDeposit(((TextBlock)dep_button_1.Content)?.Text!);
        dep_TextBox.Text = MainAlgorithm.GetDeposit().ToString(); // 🔄 Обновление UI
        balance_label.Content = $"Balance {MainAlgorithm.GetBalance()}"; // 🔄 Обновление баланса
    }
    
    private void Dep_button_2_click(object sender, RoutedEventArgs e)
    {        
        MainAlgorithm.SetDeposit(((TextBlock)dep_button_2.Content)?.Text!);
        dep_TextBox.Text = MainAlgorithm.GetDeposit().ToString(); // 🔄 Обновление UI
        balance_label.Content = $"Balance {MainAlgorithm.GetBalance()}"; // 🔄 Обновление баланса
    }

    private void Dep_button_3_click(object sender, RoutedEventArgs e)
    {        
        MainAlgorithm.SetDeposit(((TextBlock)dep_button_3.Content)?.Text!);
        dep_TextBox.Text = MainAlgorithm.GetDeposit().ToString(); // 🔄 Обновление UI
        balance_label.Content = $"Balance {MainAlgorithm.GetBalance()}"; // 🔄 Обновление баланса
    }

    private void Dep_button_4_click(object sender, RoutedEventArgs e)
    {        
        MainAlgorithm.SetDeposit(((TextBlock)dep_button_4.Content)?.Text!);
        dep_TextBox.Text = MainAlgorithm.GetDeposit().ToString(); // 🔄 Обновление UI
        balance_label.Content = $"Balance {MainAlgorithm.GetBalance()}"; // 🔄 Обновление баланса
    }

    private void Dep_button_5_click(object sender, RoutedEventArgs e)
    {
        MainAlgorithm.SetDeposit(((TextBlock)dep_button_5.Content)?.Text!);
        dep_TextBox.Text = MainAlgorithm.GetDeposit().ToString(); // 🔄 Обновление UI
        balance_label.Content = $"Balance {MainAlgorithm.GetBalance()}"; // 🔄 Обновление баланса
    }
}