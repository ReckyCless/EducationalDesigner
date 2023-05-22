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

namespace EducationalDesigner.Pages
{
    /// <summary>
    /// Логика взаимодействия для CabinetPage.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        public CabinetPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var currentUser = App.CurrentUser;

            tbLogin.Text = App.CurrentUser.Login;
            tbPassword.Text = App.CurrentUser.Password;
            tbName.Text = App.CurrentUser.Name;
            tbSurname.Text = App.CurrentUser.Surname;
            tbPatronymic.Text = App.CurrentUser.Patronymic;
            tbEmail.Text = App.CurrentUser.Email;
            tbRole.Text = App.CurrentUser.Roles.RoleName;
        }
        private void BtnGoEdit_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new RegisterPage(App.CurrentUser));
        }
    }
}
