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
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersAddEditPage.xaml
    /// </summary>
    public partial class UsersAddEditPage : Page
    {
        private Users currentElem = new Users();
        public UsersAddEditPage(Users elemData)
        {
            InitializeComponent();
            if (elemData != null)
            {
                Title = "Пользователи. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;
            cboxRoles.ItemsSource = App.Context.Roles.ToList();
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
        private void LoginValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z@0-9!@#\$%\^\&*\)\(+=._-]");
            e.Handled = !regex.IsMatch(e.Text);
            if (!regex.IsMatch(e.Text))
            {     
                LoginValidationErr.Visibility = Visibility.Visible;
                LoginValidationErr.Text = "Только латиница, числа и спец. символы (!, _, $...)";
            }
            else if (regex.IsMatch(e.Text))
            {
                LoginValidationErr.Visibility = Visibility.Collapsed;
                LoginValidationErr.Text = "";
            }
        }

        private void EmailValidationTextBox(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$");
            if (!regex.IsMatch(tbEmail.Text))
            {
                EmailValidationErr.Visibility = Visibility.Visible;
                EmailValidationErr.Text = "Этот Email - некорректен";
                btnSave.IsEnabled = false;
            }
            else if (regex.IsMatch(tbEmail.Text))
            {
                EmailValidationErr.Visibility = Visibility.Collapsed;
                EmailValidationErr.Text = "";
                btnSave.IsEnabled = true;
            }
        }
        private void PasswordValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9!@#\$%\^\&*\)\(+=._-]");
            e.Handled = !regex.IsMatch(e.Text);
            if (!regex.IsMatch(e.Text))
            {
                PasswordValidationErr.Visibility = Visibility.Visible;
                PasswordValidationErr.Text = "Только латиница, числа и спец. символы (!, _, $...)";
            }
            else if (regex.IsMatch(e.Text))
            {
                PasswordValidationErr.Visibility = Visibility.Collapsed;
                PasswordValidationErr.Text = "";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Check if textboxes is filled
            StringBuilder err = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentElem.Login))
                err.AppendLine("Укажите логин");
            if (string.IsNullOrWhiteSpace(currentElem.Password))
                err.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(currentElem.Name))
                err.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(currentElem.Surname))
                err.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(currentElem.Email))
                err.AppendLine("Укажите почту");
            if (cboxRoles.SelectedItem == null)
                err.AppendLine("Укажите роль");
            // Check if login and email is unique
            var emailIsFound = App.Context.Users.FirstOrDefault(p => p.Email == currentElem.Email && p.UserId != currentElem.UserId);
            if (emailIsFound != null)
                err.AppendLine("Эта почта уже используется");
            var loginIsFound = App.Context.Users.FirstOrDefault(p => p.Login == currentElem.Login && p.UserId != currentElem.UserId);
            if (loginIsFound != null)
                err.AppendLine("Эта логин уже используется");

            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            currentElem.Login = currentElem.Login.Trim();
            currentElem.Password = currentElem.Password.Trim();
            currentElem.Name = currentElem.Name.Trim();
            currentElem.Surname = currentElem.Surname.Trim();
            currentElem.Patronymic = currentElem.Patronymic.Trim();
            currentElem.Email = currentElem.Email.Trim();

            if (currentElem.UserId == 0)
            {
                App.Context.Users.Add(currentElem);
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

