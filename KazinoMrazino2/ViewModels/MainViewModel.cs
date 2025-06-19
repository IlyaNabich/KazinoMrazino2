using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KazinoMrazino2.Models;

namespace KazinoMrazino2.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public PlayerData Player { get; } = new();

    public ObservableCollection<BitmapImage> MidImages { get; } = new();

    public ICommand SpinCommand { get; }
    public ICommand AddDepositCommand { get; }

    private readonly string[] _imagePaths =
    {
        "/Resources/Strawberry.ico",
        "/Resources/Cherry.ico",
        "/Resources/Lemon.ico",
        "/Resources/Watermelon.ico",
        "/Resources/Banana.ico"
    };

    private readonly Random _rand = new();

    public MainViewModel()
    {
        Player.Balance = 30000;
        Player.Deposit = 1000;

        // Initialize with random images
        for (int i = 0; i < 3; i++)
            MidImages.Add(new BitmapImage(new Uri(_imagePaths[_rand.Next(5)], UriKind.Relative)));

        SpinCommand = new RelayCommand(Spin);
        AddDepositCommand = new RelayCommand(AddDeposit);
    }

    private void Spin()
    {
        MidImages.Clear();
        var results = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int index = _rand.Next(5);
            results.Add(index);
            MidImages.Add(new BitmapImage(new Uri(_imagePaths[index], UriKind.Relative)));
        }

        if (results[0] == results[1] && results[1] == results[2])
        {
            Player.Balance += Player.Deposit;
        }
        else
        {
            Player.Balance -= Player.Deposit;
        }
    }

    private void AddDeposit()
    {
        Player.Balance += Player.Deposit;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}