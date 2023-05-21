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
    /// Логика взаимодействия для EducationalProgramPage.xaml
    /// </summary>
    public partial class EducationalProgramPage : Page
    {
        private int PagesCount;
        private int NumberOfPage = 0;
        private int maxItemShow = 4;
        List<Models.EducationalProgram> educationalprogram = new List<Models.EducationalProgram>();
        public EducationalProgramPage()
        {
            InitializeComponent();

            var studyfield = App.Context.StudyField.ToList();
            studyfield.Insert(0, new StudyField
            {
                StudyFieldName = "Без сортировки"
            });
            cboxOrdByStudyField.ItemsSource = studyfield;

            var qualification = App.Context.Qualification.ToList();
            qualification.Insert(0, new Qualification
            {
                QualificationName = "Без сортировки"
            });
            cboxOrdByQualification.ItemsSource = qualification;

            var authors = App.Context.Authors.ToList();
            authors.Insert(0, new Authors
            {
                Name = "Без сортировки"
            });
            cboxOrdByAuthor.ItemsSource = authors;

            if (App.CurrentUser.Role == 1 || App.CurrentUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
            UpdateEducationalProgram();
            UpdateComboBoxes();
        }

        // Updating GridView on Events
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateEducationalProgram();
        }
        private void CBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEducationalProgram();
        }
        private void CBoxOrdByStudyField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEducationalProgram();
        }
        private void CBoxOrdByQualification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEducationalProgram();
        }
        private void CBoxOrdByAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEducationalProgram();
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEducationalProgram();
            UpdateComboBoxes();
            cboxCurrentPageSelection.SelectedIndex = 0;
        }

        // Add + Edit + Delete buttons controls
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EducationalProgramAddEditPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var elemsToDelete = LViewEducationalProgram.SelectedItems.Cast<Models.EducationalProgram>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {elemsToDelete.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.EducationalProgram.RemoveRange((IEnumerable<Models.EducationalProgram>)elemsToDelete);
                    App.Context.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateEducationalProgram();
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
                NavigationService.Navigate(new EducationalProgramAddEditPage((sender as ListViewItem).Content as Models.EducationalProgram));
            }
        }

        // Function of GridView update + Sorting
        private void UpdateEducationalProgram()
        {
            var educationalprogram = App.Context.EducationalProgram.ToList();
            switch (cboxSortBy.SelectedIndex)
            {
                case 1:
                    educationalprogram = educationalprogram.OrderBy(p => p.ProgramName).ToList();
                    break;
                case 2:
                    educationalprogram = educationalprogram.OrderByDescending(p => p.ProgramName).ToList();
                    break;
                case 3:
                    educationalprogram = educationalprogram.OrderBy(p => p.CreationDate).ToList();
                    break;
                case 4:
                    educationalprogram = educationalprogram.OrderByDescending(p => p.CreationDate).ToList();
                    break;
                default:
                    educationalprogram = educationalprogram.OrderBy(p => p.EducationalProgramId).ToList();
                    break;
            }
            if (cboxOrdByStudyField.SelectedIndex != 0)
            {
                educationalprogram = educationalprogram.Where(p => p.StudyField == cboxOrdByStudyField.SelectedValue).ToList();
            }
            if (cboxOrdByQualification.SelectedIndex != 0)
            {
                educationalprogram = educationalprogram.Where(p => p.Qualification1 == cboxOrdByQualification.SelectedValue).ToList();
            }
            if (cboxOrdByAuthor.SelectedIndex != 0)
            {
                educationalprogram = educationalprogram.Where(p => p.Authors == cboxOrdByAuthor.SelectedValue).ToList();
            }
            educationalprogram = educationalprogram.Where
                (p => (p.Authors.Name.ToLower() + " " + p.Authors.Surname.ToLower() + " " + p.Authors.Patronymic.ToLower()).Contains(tbSearch.Text.ToLower()) ||
                p.StudyField.StudyFieldName.ToLower().Contains(tbSearch.Text.ToLower()) ||
                p.Qualification1.QualificationName.ToLower().Contains(tbSearch.Text.ToLower()) ||
                p.ProgramName.ToLower().Contains(tbSearch.Text.ToLower()) ||
                p.CreationDate.ToString().ToLower().Contains(tbSearch.Text.ToLower())
                ).ToList();

            tbkItemCounter.Text = educationalprogram.Count.ToString() + " из " + App.Context.EducationalProgram.Count().ToString();

            if (educationalprogram.Count % maxItemShow == 0)
            {
                PagesCount = educationalprogram.Count / maxItemShow;
            }
            else
            {
                PagesCount = (educationalprogram.Count / maxItemShow) + 1;
            }

            LViewEducationalProgram.ItemsSource = educationalprogram.Skip(maxItemShow * NumberOfPage).Take(maxItemShow).ToList();
            CheckPages();
            if (educationalprogram.Count < 1)
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
            UpdateEducationalProgram();
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
