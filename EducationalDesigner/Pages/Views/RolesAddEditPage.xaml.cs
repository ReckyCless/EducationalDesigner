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

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditRolesPage.xaml
    /// </summary>
    public partial class RolesAddEditPage : Page
    {
        private Models.Roles currentElem = new Models.Roles();
        public RolesAddEditPage(Models.Roles elemData)
        {
            InitializeComponent();
            if (elemData != null)
            {
                Title = "Роли. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder err = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentElem.RoleName))
                err.AppendLine("Укажите название");
            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }
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
