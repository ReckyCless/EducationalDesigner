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

namespace EducationalDesigner.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private Users currentElem = new Users();
        public RegisterPage(Users elemData)
        {
            InitializeComponent();
            if (elemData != null)
            {
                Title = "Профиль. Редактирование";
                currentElem = elemData;
            }

            if (App.CurrentUser != null)
            {
                btnRegister.Content = "Сохранить";
                btnToLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnRegister.Content = "Зарегистрировать";
                btnToLogin.Visibility = Visibility.Visible;
            }

            DataContext = currentElem;
        }
        // Regexes
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]");
            e.Handled = !regex.IsMatch(e.Text);
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
                btnRegister.IsEnabled = false;
            }
            else if (regex.IsMatch(tbEmail.Text))
            {
                EmailValidationErr.Visibility = Visibility.Collapsed;
                EmailValidationErr.Text = "";
                btnRegister.IsEnabled = true;
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

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
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
            
            if (App.CurrentUser == null)
            {
                currentElem.Role = 2; // Grant User 'User' status (Role = 2)
            }

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

        private void BtnToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
