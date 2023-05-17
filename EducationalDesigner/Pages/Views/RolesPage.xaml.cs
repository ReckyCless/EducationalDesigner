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
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        List<Models.Roles> ProductCart = new List<Models.Roles>();
        public RolesPage()
        {
            InitializeComponent();
            if (App.CurrentUser == null || App.CurrentUser.Role == 2)
            {
/*                btnOrderList.Visibility = Visibility.Collapsed;
                btnAddProduct.Visibility = Visibility.Collapsed;*/
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void cbxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new RolesAddEditPage(null));
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = lViewRoles.SelectedItems.Cast<Models.Roles>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Roles.RemoveRange((IEnumerable<Models.Roles>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateProduct();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                NavigationService.Navigate(new RolesAddEditPage((sender as ListViewItem).Content as Models.Roles));
        }

        private void UpdateProduct()
        {
            var roles = App.Context.Roles.ToList();
            roles = roles.Where(p => p.RoleName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            lViewRoles.ItemsSource = null;
            lViewRoles.ItemsSource = roles;
            int countFind = lViewRoles.Items.Count;
            tbkItemCounter.Text = countFind.ToString() + " из " + App.Context.Roles.Count().ToString();
            if (countFind < 1)
                tbkItemCounter.Text += "\nПо вашему запросу ничего не найдено. Измените фильтры.";
        }
    }
}
