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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 20;
        List<Users> users = new List<Users>();
        public UsersPage()
        {
            InitializeComponent();

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }

            var role = App.Context.Roles.ToList();
            role.Insert(0, new Roles
            {
                RoleName = "Без сортировки"
            });
            cboxOrdBy.ItemsSource = role;

            UpdateUsers();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }
        private void CBoxOrdBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
            UpdateComboBoxes();
            cboxCurrentPageSelection.SelectedIndex = 0;
        }

        // Add + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewUsers.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Users.RemoveRange((IEnumerable<Users>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateUsers();
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
                NavigationService.Navigate(new UsersAddEditPage((sender as ListViewItem).Content as Users));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateUsers()
        {
            var users = App.Context.Users.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    users = users.OrderBy(p => p.Login).ToList();
                    break;
                case 2:
                    users = users.OrderByDescending(p => p.Login).ToList();
                    break;
                case 3:
                    users = users.OrderBy(p => p.Name).ThenBy(p => p.Surname).ThenBy(p => p.Patronymic).ToList();
                    break;
                case 4:
                    users = users.OrderByDescending(p => p.Name).ThenByDescending(p => p.Surname).ThenByDescending(p => p.Patronymic).ToList();
                    break;
                default:
                    users = users.OrderBy(p => p.UserId).ToList();
                    break;
            }
            users = users.Where
                (p => (p.Name.ToLower() + " " + p.Surname.ToLower() + " " + p.Patronymic.ToLower()).Contains(tbSearch.Text.ToLower()) ||
                p.Email.ToLower().Contains(tbSearch.Text.ToLower()) ||
                p.Login.ToLower().Contains(tbSearch.Text.ToLower()) 
                ).ToList();

            tbkItemCounter.Text = users.Count.ToString() + " из " + App.Context.Users.Count().ToString();

            if (users.Count % maxItemShow == 0)
            {
                PagesCount = users.Count / maxItemShow;
            }
            else
            {
                PagesCount = (users.Count / maxItemShow) + 1;
            }

            if (cboxOrdBy.SelectedIndex != 0)
            {
                users = users.Where(p => p.Roles == cboxOrdBy.SelectedValue).ToList();
            }
            LViewUsers.ItemsSource = users.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();

            if (users.Count < 1)
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
            UpdateUsers();
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