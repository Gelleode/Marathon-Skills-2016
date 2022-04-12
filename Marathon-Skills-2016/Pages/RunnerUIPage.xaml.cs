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
    /// Логика взаимодействия для RunnerUIPage.xaml
    /// </summary>
    public partial class RunnerUIPage : Page
    {
        private User _user;
        public RunnerUIPage(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void BtnRegisterToMarathon_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new MarathonRegister(_user));

        private void BtnMyResults_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new RunnerMyResults(_user));

        private void BtnEditProfile_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new RunnerEditProfile(_user));

        private void BtnMyCharity_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
