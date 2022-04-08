using Marathon_Skills_2016.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        private MainWindow _window;
        public StartingPage()
        {
            _window = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(w => w is MainWindow) as MainWindow;
            InitializeComponent();
            DateTime curDate = DateTime.Now;
            _window.TBlockCurrentDate.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(curDate.DayOfWeek) + " " + curDate.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(curDate.Month).ToLower() + " " + curDate.Year;

        }

        private void BtnRunner_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RunnerCheckPage());
        }

        private void BtnRunnerSponsor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVisitor_Click(object sender, RoutedEventArgs e)
        {
            _window.BtnLogin.Visibility = Visibility.Hidden;
            Manager.MainFrame.Navigate(new VisitiorInformation());
        }
    }
}
