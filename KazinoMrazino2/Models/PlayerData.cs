using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KazinoMrazino2.Models;

public class PlayerData : INotifyPropertyChanged
{
    private int _balance;
    public int Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged();
        }
    }
    private int _deposit;
    public int Deposit
    {
        get => _deposit;
        set
        {
            _deposit = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}