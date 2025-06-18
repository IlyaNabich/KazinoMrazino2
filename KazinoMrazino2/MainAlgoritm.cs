using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KazinoMrazino2
{
    class MainAlgoritm
    {
        public static List<Image>? MidImages;
        public static List<Image>? TopImages;
        public static List<Image>? BotImages;
        public static int deposit;
        public static int balance;
        public static int winBalance;

        public static void SetAlgoritmComponent(List<Image> mid, List<Image> top, List<Image> bot, string depString, int balString, int winString)
        {
            deposit = int.Parse(depString);
            balance = balString;
            winBalance = winString;
            MidImages = mid;
            TopImages = top;
            BotImages = bot;
        }
        private static List<int> _generator()
        {
            var Random = new Random();
            var result = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(Random.Next(0, 4));
            }
            Debug.WriteLine("Пошла круточка");
            foreach (int i in result)
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
            foreach (var tuple in MidImages.Select((img, index) => new { img, index }))
            {
                tuple.img.Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index]], UriKind.Relative));
                TopImages[tuple.index].Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index] == 0 ? 4 : defaultSlot[tuple.index] - 1], UriKind.Relative));
                BotImages[tuple.index].Source = new BitmapImage(new Uri(imageList[defaultSlot[tuple.index] == 4 ? 0 : defaultSlot[tuple.index] + 1], UriKind.Relative));
            }
        }
        public static int WinCalculator()
        {
            if (MidImages[0].Source.ToString() == MidImages[1].Source.ToString() && MidImages[0].Source.ToString() == MidImages[2].Source.ToString())
            {
                Debug.WriteLine("MAX WIN");
                return balance + deposit;
            }
            else
            {
                return balance - deposit;
            }

        }
        public static void SetDeposit(string depInput)
        {
            int.TryParse(depInput, out int depOut);
            deposit = depOut == 0 ? 0 : deposit += depOut;
            Debug.WriteLine(deposit);
            //return deposit.ToString();
        }
    }
}
