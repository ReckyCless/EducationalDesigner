﻿using EducationalProgram;
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
    /// Логика взаимодействия для DepartmentAddEditPage.xaml
    /// </summary>
    public partial class DepartmentAddEditPage : Page
    {
        private Department currentElem = new Department();
        public DepartmentAddEditPage(Department elemData)
        {
            InitializeComponent();
            if (elemData != null)
            {
                Title = "Факультеты. Редактирование";
                currentElem = elemData;
            }
            DataContext = currentElem;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentElem.DepartmentName))
                err.AppendLine("Укажите название");
            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString());
                return;
            }

            currentElem.DepartmentName = currentElem.DepartmentName.Trim();

            if (currentElem.DepartmentId == 0)
            {
                App.Context.Department.Add(currentElem);
            }

            try
            {
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
