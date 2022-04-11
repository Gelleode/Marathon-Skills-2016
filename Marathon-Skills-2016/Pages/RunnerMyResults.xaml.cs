using Marathon_Skills_2016.DBModel;
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

namespace Marathon_Skills_2016.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerMyResults.xaml
    /// </summary>
    public partial class RunnerMyResults : Page
    {
        private static User _user;
        public RunnerMyResults(User user)
        {
            _user = user;
            InitializeComponent();
            TBlockGender.Text = _user.Runner.First().Gender;
        }
    }
}
