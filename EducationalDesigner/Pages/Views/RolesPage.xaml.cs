using EducationalProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для RolesPage.xaml
    /// </summary>
    public partial class RolesPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 20;
        List<Roles> roles = new List<Roles>();
        public RolesPage()
        {
            InitializeComponent();

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateRoles();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRoles();    
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRoles();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRoles();
            UpdateComboBoxes();
            cboxCurrentPageSelection.SelectedIndex = 0;
        }

        // Add + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new RolesAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewRoles.SelectedItems.Cast<Roles>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Roles.RemoveRange((IEnumerable<Roles>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateRoles();
                    UpdateComboBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        // Edit by double click on record
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                NavigationService.Navigate(new RolesAddEditPage((sender as ListViewItem).Content as Roles));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateRoles()
        {
            var roles = App.Context.Roles.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    roles = roles.OrderBy(p => p.RoleName).ToList();
                    break;
                case 2:
                    roles = roles.OrderByDescending(p => p.RoleName).ToList();
                    break;
                default:
                    roles = roles.OrderBy(p => p.RoleId).ToList();
                    break;
            }
            roles = roles.Where(p => p.RoleName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            int countFind = LViewRoles.Items.Count;
            tbkItemCounter.Text = roles.Count.ToString() + " из " + App.Context.Roles.Count().ToString();
            if (roles.Count % maxItemShow == 0)
            {
                PagesCount = roles.Count / maxItemShow;
            }
            else
            {
                PagesCount = (roles.Count / maxItemShow) + 1;
            }

            LViewRoles.ItemsSource = roles.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (roles.Count < 1)
                tbkItemCounter.Text += "\nПо вашему запросу ничего не найдено. Измените фильтры.";
        }

        // Paging controls buttons
        private void BtnPagePrev_Click(object sender, RoutedEventArgs e)
        {
            NumberOfPage--;
            cboxCurrentPageSelection.Text = (NumberOfPage + 1).ToString();
        }
        private void BtnPageNext_Click(object sender, RoutedEventArgs e)
        {
            NumberOfPage++;
            cboxCurrentPageSelection.Text = (NumberOfPage + 1).ToString();
        }
        private void CBoxCurrentPageSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NumberOfPage = cboxCurrentPageSelection.SelectedIndex;
            UpdateRoles();
        }

        // Turning ON/OFF paging controls
        private void CheckPages()
        {
            if (NumberOfPage > 0)
            {
                btnPagePrev.Visibility = Visibility.Visible;
            }
            else
            {
                btnPagePrev.Visibility = Visibility.Hidden;
            }
            if (NumberOfPage < PagesCount - 1)
            {
                btnPageNext.Visibility = Visibility.Visible;
            }
            else
            {
                btnPageNext.Visibility = Visibility.Hidden;
            }
        }
        private void UpdateComboBoxes()
        {
            cboxCurrentPageSelection.Items.Clear();
            for (int i = 1; i <= PagesCount; i++)
            {
                cboxCurrentPageSelection.Items.Add(i.ToString());
            }
        }
    }
}
