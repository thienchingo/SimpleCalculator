using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    class CalculatorViewModel : BaseViewModel
    {
        private string txtBox1;
        private string txtBox2;
        private bool check;
        private string pheptinh;
        private Double Vvalue;
        private bool oN_OFF;

        public bool ON_OFF { get => oN_OFF; set { SetProperty(ref oN_OFF, value); } }
        public Double Value { get => Vvalue; set { SetProperty(ref this.Vvalue, value); } }
        public string Pheptinh { get => pheptinh; set { SetProperty(ref pheptinh, value); } }

        public bool Check { get => check; set { SetProperty(ref check, value); } }
        public string TXTBOX1 { get => txtBox1; set { SetProperty(ref txtBox1, value); } }
        public string TXTBOX2 { get => txtBox2; set { SetProperty(ref txtBox2, value); } }
        public ICommand AddNumber { private set; get; }
        public ICommand Operator { private set; get; }
        public ICommand DelAllValue { private set; get; }
        public ICommand ReturnValue { private set; get; }
        public CalculatorViewModel()
        {
            ON_OFF = false;
            TXTBOX1 = "";
            TXTBOX2 = "0";
            Value = 0;
            Check = false;
            Pheptinh = "";
            AddNumber = new Command(AddNumber1);
            DelAllValue = new Command(DelAllValue1);
            Operator = new Command(Operator1);

            ReturnValue = new Command(ReturnValue1);
        }

        private async void ReturnValue1(object obj)
        {
            if (ON_OFF == true)
            {
                switch (Pheptinh)
                {
                    case "+":
                        if (TXTBOX1 != "")
                            TXTBOX2 = (Value + Double.Parse(TXTBOX1)).ToString();
                        break;
                    case "-":
                        if (TXTBOX1 != "")
                            TXTBOX2 = (Value - Double.Parse(TXTBOX1)).ToString();
                        break;
                    case "*":
                        if (TXTBOX1 != "")
                            TXTBOX2 = (Value * Double.Parse(TXTBOX1)).ToString();
                        break;
                    case "/":
                        if (TXTBOX1 != "")
                            TXTBOX2 = (Value / Double.Parse(TXTBOX1)).ToString();
                        break;
                    default:
                        TXTBOX2 = TXTBOX1;
                        break;
                }
                Check = false;
                Value = Double.Parse(TXTBOX2);
                TXTBOX1 = "0";
            }

            else
            {
                TXTBOX2 = "Vui lòng bật máy";
                await Task.Delay(2000);
                TXTBOX2 = "0";
            }
        }

        private async void Operator1(object obj)
        {
            if (ON_OFF == true)
            {
                if (TXTBOX1 != "")
                {
                    if (Check == false)
                    {
                        Pheptinh = (string)obj;
                        if (Value != 0)
                        {
                            switch (Pheptinh)
                            {
                                case "+":
                                    Value += Double.Parse(TXTBOX1);
                                    break;
                                case "-":
                                    Value -= Double.Parse(TXTBOX1);
                                    break;
                                case "*":
                                    if (Double.Parse(TXTBOX1) > 0)
                                        Value *= Double.Parse(TXTBOX1);
                                    break;
                                case "/":
                                    if (Double.Parse(TXTBOX1) > 0)
                                        Value /= Double.Parse(TXTBOX1);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            Value = Double.Parse(TXTBOX1);
                        Check = true;
                        TXTBOX2 = Value + " " + Pheptinh;
                        TXTBOX1 = "";
                    }
                }
            }
            else
            {
                TXTBOX2 = "Vui lòng bật máy";
                await Task.Delay(2000);
                TXTBOX2 = "0";
            }


        }

        private async void DelAllValue1(object obj)
        {
            if (ON_OFF == true)
            {
                TXTBOX1 = "Cancel";
                await Task.Delay(2000);
                Value = 0;
                TXTBOX1 = "";
                TXTBOX2 = "0";
                Check = false;
            }
            else
            {
                TXTBOX2 = "Vui lòng bật máy";
                await Task.Delay(2000);
                TXTBOX2 = "0";
            }

        }

        private async void AddNumber1(object obj)
        {
            if (ON_OFF == true)
            {
                if (TXTBOX1 == "0") TXTBOX1 = (string)obj;
                else
                    TXTBOX1 += (string)obj;
            }
            else
            {
                TXTBOX2 = "Vui lòng bật máy";
                await Task.Delay(2000);
                TXTBOX2 = "0";
            }
        }
    }
}
