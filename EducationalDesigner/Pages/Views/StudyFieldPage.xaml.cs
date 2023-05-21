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
    /// Логика взаимодействия для StudyFieldPage.xaml
    /// </summary>
    public partial class StudyFieldPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 20;
        List<StudyField> studyfield = new List<StudyField>();
        public StudyFieldPage()
        {
            InitializeComponent();

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }

            var department = App.Context.Department.ToList();
            department.Insert(0, new Department
            {
                DepartmentName = "Без сортировки"
            });
            cboxOrdBy.ItemsSource = department;

            UpdateStudyFields();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateStudyFields();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStudyFields();
        }
        private void CBoxOrdBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStudyFields();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStudyFields();
            UpdateComboBoxes();
            cboxCurrentPageSelection.SelectedIndex = 0;
        }

        // Add + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudyFieldAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewStudyFields.SelectedItems.Cast<StudyField>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.StudyField.RemoveRange((IEnumerable<StudyField>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateStudyFields();
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
                NavigationService.Navigate(new StudyFieldAddEditPage((sender as ListViewItem).Content as StudyField));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateStudyFields()
        {
            var studyfield = App.Context.StudyField.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    studyfield = studyfield.OrderBy(p => p.StudyFieldName).ToList();
                    break;
                case 2:
                    studyfield = studyfield.OrderByDescending(p => p.StudyFieldName).ToList();
                    break;
                default:
                    studyfield = studyfield.OrderBy(p => p.StudyFieldId).ToList();
                    break;
            }
            studyfield = studyfield.Where(p => p.StudyFieldName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            tbkItemCounter.Text = studyfield.Count.ToString() + " из " + App.Context.StudyField.Count().ToString();
            if (studyfield.Count % maxItemShow == 0)
            {
                PagesCount = studyfield.Count / maxItemShow;
            }
            else
            {
                PagesCount = (studyfield.Count / maxItemShow) + 1;
            }
            if (cboxOrdBy.SelectedIndex != 0)
            {
                studyfield = studyfield.Where(p => p.Department1 == cboxOrdBy.SelectedValue).ToList();
            }
            LViewStudyFields.ItemsSource = studyfield.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (studyfield.Count < 1)
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
            UpdateStudyFields();
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