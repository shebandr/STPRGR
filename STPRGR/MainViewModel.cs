using STPRGR;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace STPRGR
{
    public class MainViewModel : INotifyPropertyChanged
    {
		private double currentDouble;
		private double currentIm;
		private double memDouble;
		private double memIm;
		private string currentOperation;

		private string _inputText;
        private string _memoryLabelText;
        private string _history;
        private string _info;

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string MemoryLabelText
        {
            get { return _memoryLabelText; }
            set
            {
                _memoryLabelText = value;
                OnPropertyChanged(nameof(MemoryLabelText));
            }
        }

        public string History
        {
            get { return _history; }
            set
            {
                _history = value;
                OnPropertyChanged(nameof(History));
            }
        }

        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public ICommand ExitCommand { get; }
        public ICommand HistoryCommand { get; }
        public ICommand InfoCommand { get; }
        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            HistoryCommand = new RelayCommand(ShowHistory);
            InfoCommand = new RelayCommand(ShowInfo);
            CalculateCommand = new RelayCommand(Calculate);

            Info = "Работа выполнена\nстудентом ИП-112 \nШебановым Андреем\nГеоргиевичем";
        }

        private void Exit(object parameter)
        {
//            STPRGR.Current.Shutdown();
        }

        private void ShowHistory(object parameter)
        {
            // Логика для отображения истории
            var historyWindow = new UniversalWindow(History);
            historyWindow.ShowDialog();
        }

        private void ShowInfo(object parameter)
        {
            // Логика для отображения справки
            var infoWindow = new UniversalWindow(Info);
            infoWindow.ShowDialog();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		private RelayCommand addSymbolCommand;
		public ICommand AddSymbolCommand => addSymbolCommand ??= new RelayCommand(AddSymbol);

		private void AddSymbol(object commandParameter)
		{

            Debug.WriteLine(commandParameter.ToString());
		    switch (commandParameter.ToString()) 
            {
				case "0":
					InputText += "0";
					break;
				case "1":
					InputText += "1";
					break;
				case "2":
					InputText += "2";
					break;
				case "3":
					InputText += "3";
					break;
				case "4":
					InputText += "4";
					break;
				case "5":
					InputText += "5";
					break;
				case "6":
					InputText += "6";
					break;
				case "7":
					InputText += "7";
					break;
				case "8":
					InputText += "8";
					break;
				case "9":
					InputText += "9";
					break;
				case "i":
					if (!InputText.Contains("i"))
					{
						InputText += "i";
					}
					else
					{
						var infoWindow = new UniversalWindow("i может быть только одно");
						infoWindow.ShowDialog();
					}
					break;

				case ".":
                    if (InputText == null)
                    {
                        InputText += "0";
                    }
					if (InputText.Contains("i"))
					{
                        string[] tempSubStrings = InputText.Split("i");
                        if (tempSubStrings[1].Contains("."))
                        {
                            var infoWindow = new UniversalWindow("в мнимой части уже есть точка");
                            infoWindow.ShowDialog();
                        } else
                        {
                            InputText += ".";
                        }
                        
					}
					else
					{
						if (InputText.Contains("."))
						{
							var infoWindow = new UniversalWindow("в целой части уже есть точка");
							infoWindow.ShowDialog();
						}
						else
						{
							InputText += ".";
						}
					}
					break;

			}

		}


		private void Calculate(object commandParameter)
		{
			Debug.WriteLine(commandParameter.ToString());
			switch (commandParameter.ToString())
			{
				case "C":
					InputText = "";
					break;
				case "CE":
					currentDouble = 0;
					currentIm = 0;
					InputText = "";
					break;
				case "MClear":
					memDouble = 0;
					memIm = 0;
					MemoryLabelText = "";
					break;
				case "MIn":

					if (CheckInput(InputText))
					{
						string tempData = InputText.Replace('.', ',');
						if (tempData.Contains("i") && tempData[0] != 'i')
						{
							string[] tempSubStrings = tempData.Split("i");
							memDouble = Double.Parse(tempSubStrings[0]);
							memIm = Double.Parse(tempSubStrings[1]); ;
							MemoryLabelText = tempData;
						}
						else if (tempData.Contains("i") && tempData[0] == 'i')
						{
							string[] tempSubStrings = tempData.Split("i");
							memDouble = 0;
							memIm = Double.Parse(tempSubStrings[1]);
							MemoryLabelText = "0" + tempData;
						}
						else if (!tempData.Contains("i"))
						{
							memDouble = Double.Parse(tempData);
							MemoryLabelText = tempData + "i0";
						}
					}
					else
					{
						var infoWindow = new UniversalWindow("Некорректное число");
						infoWindow.ShowDialog();
					}
					break;
				case "MOut":
					if (MemoryLabelText != null)
					{
						InputText = MemoryLabelText;
					}
					break;
				case "Mod":
					if (CheckInput(InputText))
					{
						CNum cNum = StringToCNum(InputText);
						cNum.Mdl();
						InputText = cNum.Mdl().ToString("R", System.Globalization.CultureInfo.InvariantCulture);
						if (InputText.Contains(","))
						{
							InputText = InputText.Replace('.', ',');
						}
					}
					break;
				case "Deg":
					if (CheckInput(InputText))
					{
						CNum cNum = StringToCNum(InputText);
						cNum.Mdl();
						InputText = cNum.Deg().ToString("R", System.Globalization.CultureInfo.InvariantCulture);
						if (InputText.Contains(","))
						{
							InputText = InputText.Replace('.', ',');
						}
					}
					break;
				case "Rad":
					if (CheckInput(InputText))
					{
						CNum cNum = StringToCNum(InputText);
						cNum.Mdl();
						InputText = cNum.Rad().ToString("R", System.Globalization.CultureInfo.InvariantCulture);
						if (InputText.Contains(","))
						{
							InputText = InputText.Replace('.', ',');
						}
					}
					break;
				case "-":
					if (InputText == null || InputText.Length == 0 || InputText.Last() == 'i')
					{
						InputText += "-";
						break;
					}
					else
					{
						if (CheckInput(InputText))
						{
							if (currentOperation == null || currentOperation == "")
							{
								CNum cNum = StringToCNum(InputText);
								currentDouble = cNum.GetReal();
								currentIm = cNum.GetIm();
								InputText = "";
							}
							else
							{
								CalcLastOperation();
							}
							currentOperation = "-";
						}
					}
					break;
				case "+":
					{
						if (CheckInput(InputText))
						{
							if (currentOperation == null || currentOperation == "")
							{
								CNum cNum = StringToCNum(InputText);
								currentDouble = cNum.GetReal();
								currentIm = cNum.GetIm();
								InputText = "";
							}
							else
							{
								CalcLastOperation();
							}
							currentOperation = "+";
						}
					}
					break;
				case ".":
					{
						if (CheckInput(InputText))
						{
							if (currentOperation == null || currentOperation == "")
							{
								CNum cNum = StringToCNum(InputText);
								currentDouble = cNum.GetReal();
								currentIm = cNum.GetIm();
								InputText = "";
							}
							else
							{
								CalcLastOperation();
							}
							currentOperation = ".";
						}
					}
					break;
				case "*":
					{
						if (CheckInput(InputText))
						{
							if (currentOperation == null || currentOperation == "")
							{
								CNum cNum = StringToCNum(InputText);
								currentDouble = cNum.GetReal();
								currentIm = cNum.GetIm();
								InputText = "";
							}
							else
							{
								CalcLastOperation();
							}
							currentOperation = "*";
						}
					}
					break;


				case "=":

					Debug.WriteLine(currentOperation + " " + currentDouble + " " + currentIm);
					if (CheckInput(InputText))
					{
						if (currentOperation == null || currentOperation == "")
						{

						}
						else
						{
							CalcLastOperation();
							currentOperation = "";
							InputText = currentDouble.ToString("R", System.Globalization.CultureInfo.InvariantCulture) + "i" + currentIm.ToString("R", System.Globalization.CultureInfo.InvariantCulture) ;
						}
					}
					break;
			}
			if (InputText.Contains(","))
			{
				InputText = InputText.Replace('.', ',');
			}
		}

		private void CalcLastOperation()
		{
			CNum cNum = StringToCNum(InputText);
			CNum lastData = new CNum(currentDouble, currentIm);
			CNum newData = new CNum(0, 0);
			switch (currentOperation)
			{
				case "-":
					 newData = CNum.Sub(lastData, cNum);
					break;
				case "+":
					newData = CNum.Sum(lastData, cNum);
					break;
				case "*":
					newData = CNum.Mult(lastData, cNum);
					break;
				case "/":
					newData = CNum.Div(lastData, cNum);
					break;
			}



			currentDouble = newData.GetReal();
			currentIm = newData.GetIm();
			

		}
		private CNum StringToCNum(string str)
		{
			if (str.Contains("."))
			{
				str = str.Replace('.', ',');
			}
			double a = 0;
			double b = 0;
			if (str.Contains("i"))
			{
				string[] tempSubStrings = str.Split("i");
				if (tempSubStrings[0].Length != 0)
				{
					a = Convert.ToDouble(tempSubStrings[0]);
				}
				if (tempSubStrings[1].Length != 0)
				{
					b = Convert.ToDouble(tempSubStrings[1]);
				}
			} else
			{
				a = Convert.ToDouble(str);
			}
			Debug.WriteLine(a + " " + b);
			CNum result = new CNum(a, b);
	
			return result;


		}
		private bool CheckInput(string data)
        {
            if(data == null)
            {
                return false;
            }
            bool result = false;
            string pattern = @"^-?\d+([.,]\d+)?(i-?\d+([.,]\d+)?)?$";
			Regex regex = new Regex(pattern);

            result = regex.IsMatch(data);
			if (!result)
			{
				var infoWindow = new UniversalWindow("некорретные входные данные");
				infoWindow.ShowDialog();
			}
            return result;
        }
	}
}