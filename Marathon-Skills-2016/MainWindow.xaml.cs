using Marathon_Skills_2016.Pages;
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

namespace Marathon_Skills_2016
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Бразильский зелёный - #00903E
            // Бразильский жёлтый - #FDC100
            // Бразильский синий - #241D70
            // Белый - #FFFFFF
            // Светло серый - #EBEBEB
            // Серый - #B4B4B4
            // Тёмно серый - #505050
            // Чёрный - #000000
            InitializeComponent();
            TBlockMarathon.Visibility = Visibility.Hidden;
            BtnLogOut.Visibility = Visibility.Hidden;
            BtnBack.Visibility = Visibility.Hidden;
            Manager.MainFrame = MainFrame;
            Manager.MainFrame.Navigate(new StartingPage());
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.GoBack();
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Manager.MainFrame.Content is StartingPage)
            {
                TBlockMarathon.Visibility = Visibility.Hidden;
                StackPanelStart.Visibility = Visibility.Visible;
                BtnLogin.Visibility = Visibility.Visible;
            }
            else
            {
                TBlockMarathon.Visibility = Visibility.Visible;
                StackPanelStart.Visibility = Visibility.Hidden;
            }

            if (Manager.MainFrame.Content is RunnerCheckPage)
                BtnLogin.Visibility = Visibility.Visible;

            if (MainFrame.CanGoBack && 
                !(Manager.MainFrame.Content is StartingPage) && 
                !(Manager.MainFrame.Content is AdministratorUIPage) && 
                !(Manager.MainFrame.Content is CoordinatorUIPage) && 
                !(Manager.MainFrame.Content is RunnerUIPage))
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            BtnLogin.Visibility = Visibility.Hidden;
            Manager.MainFrame.Navigate(new LoginPage());
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            BtnLogOut.Visibility = Visibility.Hidden;
            Manager.MainFrame.Navigate(new StartingPage());
        }
    }
}
