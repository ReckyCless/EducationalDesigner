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
using System.Text.RegularExpressions;
using EducationalDesigner.Models;

namespace EducationalDesigner.Pages.Views
{
    /// <summary>
    /// Логика взаимодействия для CurriculumPage.xaml
    /// </summary>
    public partial class CurriculumPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 4;
        List<Curriculum> curriculum = new List<Curriculum>();
        public CurriculumPage()
        {
            InitializeComponent();

            var educationalprogram = App.Context.EducationalProgram.ToList();
            educationalprogram.Insert(0, new Models.EducationalProgram
            {
                ProgramName = "Без сортировки"
            });
            cboxOrdByEducationalProgram.ItemsSource = educationalprogram;

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateCurriculum();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCurriculum();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCurriculum();
        }
        private void CBoxOrdByEducationalProgram_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCurriculum();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCurriculum();
            UpdateComboBoxes();
            cboxCurrentPageSelection.SelectedIndex = 0;
        }

        // Add + Edit + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CurriculumAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewCurriculum.SelectedItems.Cast<Curriculum>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Curriculum.RemoveRange((IEnumerable<Curriculum>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateCurriculum();
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
                NavigationService.Navigate(new CurriculumAddEditPage((sender as ListViewItem).Content as Curriculum));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateCurriculum()
        {
            var curriculum = App.Context.Curriculum.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    curriculum = curriculum.OrderBy(p => p.EducationalProgram1.ProgramName).ToList();
                    break;
                case 2:
                    curriculum = curriculum.OrderByDescending(p => p.EducationalProgram1.ProgramName).ToList();
                    break;
                case 3:
                    curriculum = curriculum.OrderBy(p => p.StartDate).ToList();
                    break;
                case 4:
                    curriculum = curriculum.OrderByDescending(p => p.StartDate).ToList();
                    break;
                case 5:
                    curriculum = curriculum.OrderBy(p => p.MinScore).ToList();
                    break;
                case 6:
                    curriculum = curriculum.OrderByDescending(p => p.MinScore).ToList();
                    break;
                default:
                    curriculum = curriculum.OrderBy(p => p.СurriculumId).ToList();
                    break;
            }
            if (cboxOrdByEducationalProgram.SelectedIndex != 0)
            {
                curriculum = curriculum.Where(p => p.EducationalProgram1 == cboxOrdByEducationalProgram.SelectedValue).ToList();
            }
            curriculum = curriculum.Where(p => p.EducationalProgram1.ProgramName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            tbkItemCounter.Text = curriculum.Count.ToString() + " из " + App.Context.Curriculum.Count().ToString();

            if (curriculum.Count % maxItemShow == 0)
            {
                PagesCount = curriculum.Count / maxItemShow;
            }
            else
            {
                PagesCount = (curriculum.Count / maxItemShow) + 1;
            }

            LViewCurriculum.ItemsSource = curriculum.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (curriculum.Count < 1)
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
            UpdateCurriculum();
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
