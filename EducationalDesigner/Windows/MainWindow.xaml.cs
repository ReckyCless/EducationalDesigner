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

namespace EducationalProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object frameContent = null;
        public MainWindow()
        {
            InitializeComponent();
            frameMain.Navigate(new Pages.LoginPage());
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frameMain.CanGoBack && MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                frameMain.GoBack();
        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (frameMain.Content != frameContent)
            {
                if (App.CurrentUser != null)
                    tbkUsername.Text = App.CurrentUser.Surname + "\n" + App.CurrentUser.Name + "\n" + App.CurrentUser.Patronymic;
                else tbkUsername.Text = "Гость";
            }
            else
            {
                tbkUsername.Text = String.Empty;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frameContent = frameMain.Content;
        }
    }
}
