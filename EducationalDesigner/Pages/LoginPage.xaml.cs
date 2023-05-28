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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.Users.Where(p => p.Login == tbLogin.Text && p.Password == tbPassword.Password)
                .AsEnumerable()
                .FirstOrDefault(p => p.Login == tbLogin.Text && p.Password == tbPassword.Password);
            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                var currentWindow = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(window => window is MainWindow) as MainWindow;
                // Controls Visibility
                if (currentUser.Role == 1 || currentUser.Role == 3)
                {
                    currentWindow.AdminSidePanel.Visibility = Visibility.Visible;
                    currentWindow.UserSidePanel.Visibility = Visibility.Visible;
                    currentWindow.CabinetMenu.Visibility = Visibility.Visible;
                }
                else if (currentUser.Role == 2)
                {
                    currentWindow.UserSidePanel.Visibility = Visibility.Visible;
                    currentWindow.CabinetMenu.Visibility = Visibility.Visible;
                }

                // Totaly must chan
                NavigationService.Navigate(new Views.EducationalProgramPage());
                
            }
            else
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = null;
            tbLogin.Text = String.Empty;
            var currentWindow = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;
            currentWindow.AdminSidePanel.Visibility = Visibility.Collapsed;
            currentWindow.UserSidePanel.Visibility = Visibility.Collapsed;
            currentWindow.CabinetMenu.Visibility = Visibility.Collapsed;
        }

        private void BtnToRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage(null));
        }
    }
}
