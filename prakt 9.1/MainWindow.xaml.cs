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

namespace prakt_9._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student[] student = new Student[10];
        string[,] matrix = new string[10,6];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillTable(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outPosition.Text, out int position) && position <= 10 && position > 0 && outName.Text != string.Empty &&
                outSername.Text != string.Empty && outPatronymic.Text != string.Empty && outStreet.Text != string.Empty && int.TryParse(outHouse.Text, out int house) &&
                int.TryParse(outRoom.Text, out int room))
            {
               student[position-1] = new Student(outName.Text, outSername.Text, outPatronymic.Text, outStreet.Text, house, room);
               matrix[position - 1, 0] = student[position-1].Sername;
               matrix[position - 1, 1] = student[position-1].Name;
               matrix[position - 1, 2] = student[position-1].Patronymic;
               matrix[position - 1, 3] = student[position-1].Street;
               matrix[position - 1, 4] = student[position-1].House.ToString();
               matrix[position - 1, 5] = student[position-1].Room.ToString();
               dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
               dataGrid.Columns[0].Header = "Фамилия";
               dataGrid.Columns[1].Header = "Имя";
               dataGrid.Columns[2].Header = "Отчество";
               dataGrid.Columns[3].Header = "Улица";
               dataGrid.Columns[4].Header = "Номер дома";
               dataGrid.Columns[5].Header = "Номер квартиры";
            }
            else
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            outAmount.Clear();
        }

        private void DeleteLine(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outPosition.Text, out int position) && position > 0 && position <= 10)
            {
                student[position - 1] = new Student();
                for (int i = 0; i <= 5; i++)
                {
                    matrix[position - 1, i] = string.Empty;
                }
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "Фамилия";
                dataGrid.Columns[1].Header = "Имя";
                dataGrid.Columns[2].Header = "Отчество";
                dataGrid.Columns[3].Header = "Улица";
                dataGrid.Columns[4].Header = "Номер дома";
                dataGrid.Columns[5].Header = "Номер квартиры";
            }
            else
            {
                MessageBox.Show("Номер строки не выбран  или выбран неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            outAmount.Clear();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            if (searchStreet.Text != string.Empty)
            {
                for(int i = 0; i < 10; i++)
                {
                    if (matrix[i,3] == null)
                    {
                        continue;
                    }
                    if (matrix[i, 3] == searchStreet.Text)
                    {
                        amount++;
                    }
                }
                outAmount.Text = amount.ToString();
            }
            else
            {
                MessageBox.Show("Введите нужную улицу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void searchStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            outAmount.Clear();
        }

        private void outPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            outSername.Clear();
            outName.Clear();
            outPatronymic.Clear();
            outStreet.Clear();
            outHouse.Clear();
            outRoom.Clear();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №9\nОписать, используя структуру, данные на учеников (фамилия, улица, дом, квартира). Вывести результат на экран. Вывести информацию, сколько учеников живет на заданной улице.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
