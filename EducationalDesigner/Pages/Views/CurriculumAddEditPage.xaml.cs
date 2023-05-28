using EducationalProgram;
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
using System.Text.RegularExpressions;
using EducationalDesigner.Models;

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для CurriculumAddEditPage.xaml
    /// </summary>
    public partial class CurriculumAddEditPage : Page
    {
        private Curriculum currentElem = new Curriculum();
        public CurriculumAddEditPage(Curriculum elemData)
        {
            InitializeComponent();

            dpickStartDate.DisplayDateStart = new DateTime(1900, 1, 1);
            dpickStartDate.DisplayDateEnd = DateTime.Now.AddYears(2);

            if (elemData != null)
            {
                Title = "УП. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;
            cboxEducationalProgram.ItemsSource = App.Context.EducationalProgram.ToList();
        }
        // Regexes
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Check if textboxes is filled
            StringBuilder err = new StringBuilder();
            if (cboxEducationalProgram.SelectedItem == null)
                err.AppendLine("Укажите образовательную программу");
            if (currentElem.HourInYear == 0 || currentElem.HoursInWeek.ToString().Contains(" ")) 
            {
                err.AppendLine("Укажите кол-во часов в году");
            }
            else if (currentElem.HourInYear < currentElem.HoursInWeek)
                err.AppendLine("Число часов в году не может быть меньше, часов в неделю");
            if (currentElem.HoursInWeek == 0 || currentElem.HoursInWeek.ToString().Contains(" "))
                err.AppendLine("Укажите кол-во часов в неделю");
            if (dpickStartDate == null)
                err.AppendLine("Укажите дату начала");
            if (dpickStartDate.SelectedDate > DateTime.Now.AddYears(2))
                err.AppendLine("Дата начала может быть более сегодняшней максимум на 2 года");
            if (currentElem.MinScore == 0 || currentElem.HoursInWeek.ToString().Contains(" "))
                err.AppendLine("Укажите минимальный балл");

            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentElem.СurriculumId == 0)
            {
                App.Context.Curriculum.Add(currentElem);
            }

            try
            {
                App.Context.SaveChanges();
                MessageBox.Show("Данные сохранены");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

