using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazinoMrazino2
{
    public record DataSourse
    {
        public int Balance { get; set; }
        public int Deposit {  get; set; }
        public int WinBalance { get; set; }

    }
}
