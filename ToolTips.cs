using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamHelper
{
    internal class ToolTips
    {
        public string EQValue { get; set; }
        public string TotalProfil { get; set; }
        public string AddProfit { get; set; }
        public string Path { get; set; }
        public string WinLoseFormat { get; set; }
        public string ProfitFormat { get; set; }
        public ToolTips()
        {
            EQValue = string.Empty;
            TotalProfil = string.Empty;
            AddProfit = string.Empty;
            Path = string.Empty;
            WinLoseFormat = string.Empty;
            ProfitFormat = string.Empty;
        }
    }
}
