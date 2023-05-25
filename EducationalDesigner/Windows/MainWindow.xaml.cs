using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using EducationalDesigner.Models;
using EducationalDesigner.Pages.Views;
using EducationalDesigner.Pages;

namespace EducationalDesigner
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
            frameMain.Navigate(new LoginPage());
        }
        public void RejectChanges()
        {
            foreach (var entry in App.Context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены, что хотите вернуться?\nНесохраненные данные могут быть утеряны",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                RejectChanges();
                frameMain.GoBack();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frameContent = frameMain.Content;
        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (frameMain.CanGoBack && App.CurrentUser != null)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }

        }

        // Menu Control
        private void AuthorsTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new AuthorsPage());
        }
        private void EducationalProgramTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new EducationalProgramPage());
        }
        private void CurriculumTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new CurriculumPage());
        }
        private void UsersTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new UsersPage());
        }
        private void RolesTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new RolesPage());
        }
        private void DepartmentTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new DepartmentPage());
        }
        private void StudyFieldsTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new StudyFieldPage());
        }
        private void QualificationTable_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new QualificationPage());
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            btnBack.Visibility = Visibility.Hidden;
            frameMain.Navigate(new LoginPage());
        }
        private void CabinetGo_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new CabinetPage());
        }
    }
}
