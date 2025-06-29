﻿using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KazinoMrazino2
{
    internal static class MainAlgorithm
    {
        private static List<Image>? _midImages;
        private static List<Image>? _topImages;
        private static List<Image>? _botImages;
        private static int _deposit;
        private static int _balance;
        private static int _winBalance;
        public static int GetDeposit() => _deposit;
        public static int GetBalance() => _balance;

        public static void SetAlgorithmComponent(List<Image> mid, List<Image> top, List<Image> bot, string depString, int balString, int winString)
        {
            _deposit = int.Parse(depString);
            _balance = balString;
            _winBalance = winString;
            _midImages = mid;
            _topImages = top;
            _botImages = bot;
        }
        private static List<int> _generator()
        {
            var rand = new Random();
            var result = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(rand.Next(0, 4));
            }
            Debug.WriteLine("Пошла круточка");
            foreach (var i in result)
            {
                Debug.WriteLine(i);
            }
            return result;
        }
        public static void DefaultSlot()
        {
            var imageList = new List<string>
            {
            "/Resources/Strawberry.ico",
            "/Resources/Cherry.ico",
            "/Resources/Lemon.ico",
            "/Resources/Watermelon.ico",
            "/Resources/Banana.ico"
            };
            var defaultSlot = _generator();
            foreach (var tuple in _midImages!.Select((img, index) => new { img, index }))
            {
                tuple.img.Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index]], UriKind.Relative));
                _topImages![tuple.index].Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index] == 0 ? 4 : defaultSlot[tuple.index] - 1], UriKind.Relative));
                _botImages![tuple.index].Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index] == 4 ? 0 : defaultSlot[tuple.index] + 1], UriKind.Relative));
            }
        }
        public static int WinCalculator()
        {
            if (_midImages![0].Source.ToString() == _midImages[1].Source.ToString() && _midImages[0].Source.ToString() == _midImages[2].Source.ToString())
            {
                Debug.WriteLine("MAX WIN");
                _balance -= _deposit;
                return _balance + _deposit;
            }
            else
            {
                _balance -= _deposit;
                return _balance - _deposit;
            }
        }
        public static void SetDeposit(string depInput)
        {
            int.TryParse(depInput, out int depOut);
            _deposit = depOut ==0 ? 0 : _deposit += depOut;
            _deposit = _deposit < 0 ? 0 : _deposit;
            Debug.WriteLine(_deposit);
            //return _deposit.ToString();
        }
    }
}
