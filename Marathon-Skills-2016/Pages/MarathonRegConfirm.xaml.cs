using Marathon_Skills_2016.DBModel;
using Marathon_Skills_2016.Utils;
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
    /// Логика взаимодействия для MarathonRegConfirm.xaml
    /// </summary>
    public partial class MarathonRegConfirm : Page
    {
        private static User _user;
        public MarathonRegConfirm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RunnerUIPage(_user));
        }
    }
}
