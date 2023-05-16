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

namespace EducationalDesigner.Pages.DataBase.Authors
{
    /// <summary>
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        public AuthorsPage()
        {
            InitializeComponent();
            cmbByOrd.SelectedIndex = 0;
        }

        private void cmbByOrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrders();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOrders();
        }

/*        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentOrder = button.DataContext as Entities.Order;
            NavigationService.Navigate(new EditOrderPage(currentOrder));
        }*/

        private void UpdateOrders()
        {
            var orders = App.Context.Authors.ToList();
                orders = orders.OrderBy(p => p.OrderID).ToList();
            lViewAuthorsList.ItemsSource = null;
            lViewAuthorsList.ItemsSource = orders;
            int countFind = lViewAuthorsList.Items.Count;
            tbItemCounter.Text = countFind.ToString() + " из " + App.Context.Order.Count().ToString();
            if (countFind < 1)
                tbItemCounter.Text += "\nПо вашему запросу ничего не найдено. Измените фильтры.";
        }
    }
}
