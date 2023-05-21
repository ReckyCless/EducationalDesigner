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
    /// Логика взаимодействия для EducationalProgramAddEditPage.xaml
    /// </summary>
    public partial class EducationalProgramAddEditPage : Page
    {
        private Models.EducationalProgram currentElem = new Models.EducationalProgram();
        public EducationalProgramAddEditPage(Models.EducationalProgram elemData)
        {
            InitializeComponent();
            if (elemData != null)
            {
                Title = "ОП. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;
            cboxStudyField.ItemsSource = App.Context.StudyField.ToList();
            cboxQualification.ItemsSource = App.Context.Qualification.ToList();
            cboxAuthors.ItemsSource = App.Context.Authors.ToList();
        }
        // Regexes
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Check if textboxes is filled
            StringBuilder err = new StringBuilder();
            if (cboxStudyField.SelectedItem == null)
                err.AppendLine("Укажите направление");
            if (cboxQualification.SelectedItem == null)
                err.AppendLine("Укажите квалификацию");
            if (string.IsNullOrWhiteSpace(currentElem.ProgramName))
                err.AppendLine("Укажите название программы");
            if (dpickCreationDate == null)
                err.AppendLine("Укажите дату создания");
            if (cboxAuthors.SelectedItem == null)
                err.AppendLine("Укажите автора");

            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            if (currentElem.EducationalProgramId == 0)
            {
                App.Context.EducationalProgram.Add(currentElem);
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
