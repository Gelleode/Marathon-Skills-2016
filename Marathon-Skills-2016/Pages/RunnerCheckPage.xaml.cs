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
    /// Логика взаимодействия для RunnerCheckPage.xaml
    /// </summary>
    public partial class RunnerCheckPage : Page
    {
        private MainWindow _window;
        public RunnerCheckPage()
        {
            _window = Application.Current.Windows
                   .Cast<Window>()
                   .FirstOrDefault(w => w is MainWindow) as MainWindow;
            InitializeComponent();
        }

        private void BtnRunnerExists_Click(object sender, RoutedEventArgs e)
        {
            _window.BtnLogin.Visibility = Visibility.Hidden;
            Manager.MainFrame.Navigate(new LoginPage());
        }

        private void BtnRunnerNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
