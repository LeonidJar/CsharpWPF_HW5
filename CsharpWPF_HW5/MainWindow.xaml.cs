using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CsharpWPF_HW5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.Result += Calculator_Result;
        }

        private void Calculator_Result(object sender, CalculatorArgs e)
        {
            Answer.Content = e.answer;
        } 

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text == string.Empty)
                Environment.Exit(0);

            bool flag = int.TryParse(InputText.Text, out int value);

            string name = (e.Source as FrameworkElement).Name;

            if (!flag) {
                MessageBox.Show("Неверно ввели данные");
                InputText.Text = string.Empty;
            }

            switch (name)
            {
                case "Add":
                    calculator.Add(value);
                    break;
                case "Sub":
                    calculator.Sub(value);
                    break;
                case "Mult":
                    calculator.Mult(value);
                    break;
                case "Div":
                    calculator.Div(value);
                    break;
                case "Cancel":
                    calculator.Cancel();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    MessageBox.Show("Ошибка");
                    InputText.Text = string.Empty;
                    break;
            }
        }
    }
}
