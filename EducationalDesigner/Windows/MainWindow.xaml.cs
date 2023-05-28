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
                btnBack.Visibility = Visibility.Collapsed;
            }
        }

        // Menu Control
        private void BtnEducationalProgram_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new EducationalProgramPage());
        }
        private void BtnCurriculum_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new CurriculumPage());
        }
        private void BtnAuthors_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new AuthorsPage());
        }
        private void BtnUsers_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new UsersPage());
        }
        private void BtnDepartment_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new DepartmentPage());
        }
        private void BtnStudyField_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new StudyFieldPage());
        }
        private void BtnQualification_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new QualificationPage());
        }
        private void BtnRoles_Clicked(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new RolesPage());
        }


        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            /*btnBack.Visibility = Visibility.Collapsed;*/
            frameMain.Navigate(new LoginPage());
        }
        private void CabinetGo_Click(object sender, RoutedEventArgs e)
        {
            RejectChanges();
            frameMain.Navigate(new CabinetPage());
        }
    }
}
