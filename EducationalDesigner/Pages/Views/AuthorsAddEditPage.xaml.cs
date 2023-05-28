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
using Microsoft.Win32;
using System.IO;

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorsAddEditPage.xaml
    /// </summary>
    public partial class AuthorsAddEditPage : Page
    {
        private Authors currentElem = new Authors();
        private byte[] _mainImageData = null;
        public AuthorsAddEditPage(Authors elemData)
        {
            InitializeComponent();

            dpickBirthDate.DisplayDateStart = new DateTime(1900, 1, 1);
            dpickBirthDate.DisplayDateEnd = DateTime.Now;

            if (elemData != null)
            {
                Title = "Авторы. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;

            cboxDepartment.ItemsSource = App.Context.Department.ToList();
           
            if (currentElem.Photo != null)
            {
                try
                {
                    ImageService.Source = new ImageSourceConverter()
                        .ConvertFrom(currentElem.Photo) as ImageSource;
                }
                catch (Exception ex)
                {
                    ImageService.Source = new ImageSourceConverter()
                        .ConvertFrom(File.ReadAllBytes("../../Resources/default.png")) as ImageSource;
                    MessageBox.Show(ex.Message);   
                }
            }
            else
            {
                try
                {
                    ImageService.Source = new ImageSourceConverter()
                        .ConvertFrom(File.ReadAllBytes("../../Resources/default.png")) as ImageSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // Regexes
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = new ImageSourceConverter()
                    .ConvertFrom(_mainImageData) as ImageSource;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            currentElem.Photo = _mainImageData;
            // Check if textboxes is filled
            StringBuilder err = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentElem.Name))
                err.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(currentElem.Surname))
                err.AppendLine("Укажите фамилию");
            if (dpickBirthDate == null)
                err.AppendLine("Укажите дату рождения");
            if (dpickBirthDate.SelectedDate > DateTime.Now)
                err.AppendLine("Дата рождения не может быть больше сегодняшней");
            if (cboxDepartment.SelectedItem == null)
                err.AppendLine("Укажите факультет");

            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentElem.Name = currentElem.Name.Trim();
            currentElem.Surname = currentElem.Surname.Trim();
            currentElem.Patronymic = currentElem.Patronymic.Trim();

            if (currentElem.AuthorId == 0)
            {
                App.Context.Authors.Add(currentElem);
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
