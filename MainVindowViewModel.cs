using StreamHelper.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;


namespace StreamHelper
{
    class MainVindowViewModel : INotifyPropertyChanged
    {
        private int win { get; set; }
        private int lose { get; set; }
        private double eqValue { get; set; }
        private double totalProfitValue { get; set; }
        private double addProfitValue { get; set; }
        private string winLoseTextFormat { get; set; }
        private string winLoseOutputPath { get; set; }
        private string eqOutputPath { get; set; }
        private string eqTextFormat { get; set; }
        private string profitOutputPath { get; set; }
        private string profitTextFormat { get; set; }

        public int Win
        {
            get
            {
                return win;
            }
            set
            {
                if (win != value)
                {
                    win = value;
                    RaisePropertyChanged(nameof(Win));
                    RaisePropertyChanged("AddWinButtonContent");
                    WriteResultToFile();
                }
            }
        }
        public int Lose
        {
            get
            {
                return lose;
            }
            set
            {
                if (lose != value)
                {
                    lose = value;
                    RaisePropertyChanged(nameof(Lose));
                    RaisePropertyChanged("AddLoseButtonContent");
                    WriteResultToFile();
                }
            }
        }
        public double EQValue
        {
            get
            {
                return eqValue;
            }
            set
            {
                if(value != eqValue)
                {
                    eqValue = value;
                    RaisePropertyChanged("EQValue");
                    WriteEQValueToFile();
                }
            }
        }
        public double TotalProfitValue
        {
            get
            {
                return totalProfitValue;
            }
            set
            {
                if(totalProfitValue != value)
                {
                    totalProfitValue = value;
                    RaisePropertyChanged("TotalProfitValue");
                    WriteTotalProfitToFile();
                }
            }
        }
        public double AddProfitValue
        {
            get
            {
                return addProfitValue;
            }
            set
            {
                if(addProfitValue != value)
                {
                    addProfitValue = value;
                    RaisePropertyChanged("AddProfitValue");
                    WriteTotalProfitToFile();
                }
            }
        }
        public string AddWinButtonContent
        {
            get
            {
                return "Add Win\rWins:" + Win.ToString();
            }
        }
        public string AddLoseButtonContent
        {
            get
            {
                return "Add Lose\rLoses:" + Lose.ToString();
            }
        }        
        public string WinLoseTextFormat
        {
            get
            {
                return winLoseTextFormat;
            }
            set
            {
                if (winLoseTextFormat != value)
                {
                    winLoseTextFormat = value;
                    RaisePropertyChanged("TextContent");
                    WriteResultToFile();
                }
            }
        }
        public string WinLoseOutputPath
        {
            get
            {
                return winLoseOutputPath;
            }
            set
            {
                if(value!= winLoseOutputPath)
                {
                    winLoseOutputPath = value;
                    RaisePropertyChanged("WinLoseOutputPath");
                    WriteResultToFile();
                }
            }
        }
        public string EQOutputPath
        {
            get
            {
                return eqOutputPath;
            }
            set
            {
                if(eqOutputPath != value)
                {
                    eqOutputPath = value;
                    RaisePropertyChanged("EQOutputPath");
                    WriteEQValueToFile();
                }
            }
        }
        public string EQTextFormat
        {
            get
            {
                return eqTextFormat;
            }
            set
            {
                if (eqTextFormat != value) 
                { 
                    eqTextFormat = value;
                    RaisePropertyChanged("EQTextFormat");
                    WriteEQValueToFile();
                }
            }
        }
        public string ProfitOutputPath
        {
            get
            {
                return profitOutputPath;
            }
            set
            {
                if (value != profitOutputPath)
                {
                    profitOutputPath = value;
                    RaisePropertyChanged("ProfitOutputPath");
                    WriteTotalProfitToFile();
                }
            }
        }
        public string ProfitTextFormat
        {
            get
            {
                return profitTextFormat;
            }
            set
            {
                if(value != profitTextFormat)
                {
                    profitTextFormat = value;
                    RaisePropertyChanged("ProfitTextFormat");
                    WriteTotalProfitToFile();
                }
            }
        }

        public CommandBase AddWinCommand { get; set; }
        public CommandBase AddLoseCommand { get; set; }
        public CommandBase SubtractWinCommand { get; set; }
        public CommandBase SubtractLoseCommand { get; set; }
        public CommandBase ResetCommand { get; set; }
        public CommandBase AddProfitCommand { get; set; }
        public CommandBase SubtractProfitCommand { get; set; }

        public CommandBase WinLoseOutputPathCommand { get; set; }
        public CommandBase EQOutputPathCommand { get; set; }
        public CommandBase ProfitOutputPathCommand { get; set; }

        public CommandBase ResetProfitCommand { get; set; }
        public CommandBase AboutWindowCommand { get; set; }
        public MainVindowViewModel()
        {
            WinLoseOutputPath = string.Empty;
            WinLoseTextFormat = string.Empty;
            EQOutputPath = string.Empty;
            EQTextFormat = string.Empty;
            ProfitOutputPath = string.Empty;
            ProfitTextFormat = string.Empty;
            LoadSave();
            AddWinCommand = new CommandBase(AddWin);
            AddLoseCommand = new CommandBase(AddLose);
            SubtractWinCommand = new CommandBase(SubtractWin);
            SubtractLoseCommand = new CommandBase(SubtractLose);
            ResetCommand = new CommandBase(Reset);

            WinLoseOutputPathCommand = new CommandBase(WinLoseOutputPathFileSelect);
            EQOutputPathCommand = new CommandBase(EQOutputPathFileSelect);
            ProfitOutputPathCommand = new CommandBase(ProfitOutputPathFileSelect);

            AddProfitCommand = new CommandBase(AddProfit);
            SubtractProfitCommand = new CommandBase(SubtractProfit);
            ResetProfitCommand = new CommandBase(ResetProfit);
            AboutWindowCommand = new CommandBase(AboutWindow);
        }

        private void AddWin()
        {
            Win += 1;
        }
        private void AddLose()
        {
            Lose += 1;
        }
        private void SubtractWin()
        {
            Win -= 1;
        }
        private void SubtractLose()
        {
            Lose -= 1;
        }
        private void Reset()
        {
            Win = 0;
            Lose = 0;
        }

        private void AddProfit()
        {
            TotalProfitValue += AddProfitValue;
            AddProfitValue = 0;
        }
        private void SubtractProfit()
        {
            TotalProfitValue -= AddProfitValue;
            AddProfitValue = 0;
        }
        private void ResetProfit()
        {
            TotalProfitValue = 0;
            AddProfitValue = 0;
        }

        private void WriteResultToFile()
        {
            if(string.IsNullOrWhiteSpace(WinLoseOutputPath)is false && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(WinLoseOutputPath)))
                System.IO.File.WriteAllText(WinLoseOutputPath, $"{WinLoseTextFormat.Replace("{1}", Win.ToString()).Replace("{2}", Lose.ToString())}");
        }
        private void WriteEQValueToFile()
        {
            if(string.IsNullOrWhiteSpace(EQOutputPath)is false && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(EQOutputPath)))
                System.IO.File.WriteAllText(EQOutputPath, $"{EQTextFormat.Replace("{1}", EQValue.ToString())}");
        }
        private void WriteTotalProfitToFile()
        {
            if (string.IsNullOrWhiteSpace(ProfitOutputPath) is false && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(ProfitOutputPath)))
                System.IO.File.WriteAllText(ProfitOutputPath, $"{ProfitTextFormat.Replace("{1}", TotalProfitValue.ToString())}");
        }

        private void WinLoseOutputPathFileSelect()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
                WinLoseOutputPath = dlg.FileName;
        }
        private void EQOutputPathFileSelect()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
                EQOutputPath = dlg.FileName;
        }
        private void ProfitOutputPathFileSelect()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
                ProfitOutputPath = dlg.FileName;
        }

        private void LoadSave()
        {
            if (System.IO.File.Exists("Save.txt"))
            {
                var tmp = System.IO.File.ReadAllLines("Save.txt");
                if (tmp.Length >= 10)
                {
                    WinLoseOutputPath = tmp[0];
                    WinLoseTextFormat = tmp[1];
                    int w, l;
                    if (int.TryParse(tmp[2], out w)) Win = w;
                    if (int.TryParse(tmp[3], out l)) Lose = l;          
                    EQOutputPath = tmp[4];
                    EQTextFormat = tmp[5];
                    ProfitOutputPath = tmp[6];
                    ProfitTextFormat = tmp[7];
                    double eqV, tPV;
                    if(double.TryParse(tmp[8], out eqV)) EQValue = eqV;
                    if (double.TryParse(tmp[9], out tPV)) TotalProfitValue = tPV;
                }
            }
        }
        public void SaveState()
        {
            System.IO.File.WriteAllText("Save.txt", $"{WinLoseOutputPath}\r\n{WinLoseTextFormat}\r\n{Win}\r\n{Lose}\r\n" +
                $"{EQOutputPath}\r\n{EQTextFormat}\r\n{ProfitOutputPath}\r\n{ProfitTextFormat}\r\n" +
                $"{EQValue}\r\n{TotalProfitValue}");
        }

        public void AboutWindow()
        {
            AboutWindow aboutWindow = new AboutWindow("StreamHelper", "20250218 v0.2.1", "Program do nauki słówek.")
            { Top = App.Current.MainWindow.Top, Left = App.Current.MainWindow.Left };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
