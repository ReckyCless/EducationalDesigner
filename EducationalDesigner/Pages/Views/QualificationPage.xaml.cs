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
    /// Логика взаимодействия для QualificationPage.xaml
    /// </summary>
    public partial class QualificationPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 20;
        List<Qualification> qualification = new List<Qualification>();
        public QualificationPage()
        {
            InitializeComponent();

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateQualifications();
            UpdateComboBoxes();
        }
        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateQualifications();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateQualifications();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateQualifications();
            UpdateComboBoxes();
        }

        // Add + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QualificationAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewQualifications.SelectedItems.Cast<Qualification>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Qualification.RemoveRange((IEnumerable<Qualification>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateQualifications();
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
                NavigationService.Navigate(new QualificationAddEditPage((sender as ListViewItem).Content as Qualification));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateQualifications()
        {
            var qualification = App.Context.Qualification.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    qualification = qualification.OrderBy(p => p.QualificationName).ToList();
                    break;
                case 2:
                    qualification = qualification.OrderByDescending(p => p.QualificationName).ToList();
                    break;
                default:
                    qualification = qualification.OrderBy(p => p.QualificationId).ToList();
                    break;
            }
            qualification = qualification.Where(p => p.QualificationName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            tbkItemCounter.Text = qualification.Count.ToString() + " из " + App.Context.Qualification.Count().ToString();
            if (qualification.Count % maxItemShow == 0)
            {
                PagesCount = qualification.Count / maxItemShow;
            }
            else
            {
                PagesCount = (qualification.Count / maxItemShow) + 1;
            }

            LViewQualifications.ItemsSource = qualification.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (qualification.Count < 1)
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
            UpdateQualifications();
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
