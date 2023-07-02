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

namespace WpfApp5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
            private string currentNumber = "";
            private string selectedOperator = "";
            private double result = 0;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void Number_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
                string number = button.Content.ToString();
                currentNumber += number;
                resultTextBox.Text = currentNumber;
            }

            private void Operator_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
                selectedOperator = button.Content.ToString();

                if (selectedOperator == "√")
                {
                    result = CalculateSquareRoot();
                    currentNumber = "";
                    resultTextBox.Text = result.ToString();
                }
                else
                {
                    result = Convert.ToDouble(currentNumber);
                    currentNumber = "";
                    resultTextBox.Text = "";
                }
            }

            private void Equals_Click(object sender, RoutedEventArgs e)
            {
                double secondNumber = Convert.ToDouble(currentNumber);
                double result = 0;

                switch (selectedOperator)
                {
                    case "+":
                        result = AddNumbers(result, secondNumber);
                        break;
                    case "-":
                        result = SubtractNumbers(result, secondNumber);
                        break;
                    case "*":
                        result = MultiplyNumbers(result, secondNumber);
                        break;
                    case "/":
                        result = DivideNumbers(result, secondNumber);
                        break;
                    case "^":
                        result = PowerNumbers(result, secondNumber);
                        break;
                }

                currentNumber = "";
                resultTextBox.Text = result.ToString();
            }

            private double AddNumbers(double firstNumber, double secondNumber)
            {
                return firstNumber + secondNumber;
            }

            private double SubtractNumbers(double firstNumber, double secondNumber)
            {
                return firstNumber - secondNumber;
            }

            private double MultiplyNumbers(double firstNumber, double secondNumber)
            {
                return firstNumber * secondNumber;
            }

            private double DivideNumbers(double firstNumber, double secondNumber)
            {
                if (secondNumber == 0)
                {
                    MessageBox.Show("Nie można dzielić przez zero!");
                    return 0;
                }

                return firstNumber / secondNumber;
            }

            private double PowerNumbers(double baseNumber, double exponent)
            {
                return Math.Pow(baseNumber, exponent);
            }

            private double CalculateSquareRoot()
            {
                if (double.TryParse(currentNumber, out double number))
                {
                    if (number < 0)
                    {
                        MessageBox.Show("Nie można obliczyć pierwiastka z liczby ujemnej!");
                        return 0;
                    }

                    return Math.Sqrt(number);
                }

                return 0;
            }
        }
    }