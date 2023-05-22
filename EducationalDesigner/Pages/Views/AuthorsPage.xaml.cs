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
using EducationalDesigner.Models;

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 3;
        List<Authors> authors = new List<Authors>();
        public AuthorsPage()
        {
            InitializeComponent();

            var department = App.Context.Department.ToList();
            department.Insert(0, new Department
            {
                DepartmentName = "Без сортировки"
            });
            cboxOrdBy.ItemsSource = department;

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateAuthors();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAuthors();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAuthors();
        }
        private void CBoxOrdBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAuthors();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAuthors();
            UpdateComboBoxes();
        }

        // Add + Edit + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorsAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewAuthors.SelectedItems.Cast<Authors>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Authors.RemoveRange((IEnumerable<Authors>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateAuthors();
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
                NavigationService.Navigate(new AuthorsAddEditPage((sender as ListViewItem).Content as Models.Authors));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateAuthors()
        {
            var authors = App.Context.Authors.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    authors = authors.OrderBy(p => p.Name).ThenBy(p => p.Surname).ThenBy(p => p.Patronymic).ToList();
                    break;
                case 2:
                    authors = authors.OrderByDescending(p => p.Name).ThenByDescending(p => p.Surname).ThenByDescending(p => p.Patronymic).ToList();
                    break;
                default:
                    authors = authors.OrderBy(p => p.AuthorId).ToList();
                    break;
            }
            if (cboxOrdBy.SelectedIndex != 0)
            { 
                authors = authors.Where(p => p.Department1 == cboxOrdBy.SelectedValue).ToList();
            }
            authors = authors.Where(p => (p.Name + " " + p.Surname + " " + p.Patronymic).ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            tbkItemCounter.Text = authors.Count.ToString() + " из " + App.Context.Authors.Count().ToString();
            
            if (authors.Count % maxItemShow == 0)
            {
                PagesCount = authors.Count / maxItemShow;
            }
            else
            {
                PagesCount = (authors.Count / maxItemShow) + 1;
            }

            LViewAuthors.ItemsSource = authors.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (authors.Count < 1)
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
            UpdateAuthors();
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
            cboxCurrentPageSelection.SelectedIndex = 0;
        }
    }
}