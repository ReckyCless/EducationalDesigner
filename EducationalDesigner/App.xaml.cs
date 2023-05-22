using EducationalDesigner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EducationalDesigner
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EducationalProgramDBEntities Context { get; } = new EducationalProgramDBEntities();
        public static Users CurrentUser = null;
    }
}
