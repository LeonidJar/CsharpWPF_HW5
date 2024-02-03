using System;
using System.Windows;

namespace CsharpWPF_HW5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorExceptions calculator;
        public MainWindow()
        {
            InitializeComponent();
            calculator = new CalculatorExceptions();
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

            bool flag = float.TryParse(InputText.Text, out float value);

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
