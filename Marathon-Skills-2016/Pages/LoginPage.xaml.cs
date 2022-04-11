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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow _window;
        public LoginPage()
        {
            _window = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(w => w is MainWindow) as MainWindow;
            InitializeComponent();
        }
        // ADMIN - leila.azedeva@mskills.com    MvTQ3itX
        // COORDINATOR - w.bubash@manda.com    eWq16ALB
        // RUNNER - dean.ames@seeley.net	PQgE0K0a

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxEmail.Text == "" || TBoxPassword.Text == "")
            {
                MessageBox.Show("Необходимо ввести почту и пароль!");
                return;
            }
            User user = DatabaseContext.db.User.Find(TBoxEmail.Text);
            if (user == null || TBoxPassword.Text != user.Password)
            {
                MessageBox.Show("Wrong email or password!");
                return;
            }
            if (user.RoleId == "R")
                Manager.MainFrame.Navigate(new RunnerUIPage(user));
            if (user.RoleId == "C")
                Manager.MainFrame.Navigate(new CoordinatorUIPage(user));
            if (user.RoleId == "A")
                Manager.MainFrame.Navigate(new AdministratorUIPage(user));
            _window.BtnLogOut.Visibility = Visibility.Visible;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StartingPage());
        }
    }
}
