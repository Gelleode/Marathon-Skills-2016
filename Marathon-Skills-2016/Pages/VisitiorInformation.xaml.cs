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
    /// Логика взаимодействия для VisitiorInformation.xaml
    /// </summary>
    public partial class VisitiorInformation : Page
    {
        public VisitiorInformation()
        {
            InitializeComponent();
        }

        private void BtnMarathonLength_Click(object sender, RoutedEventArgs e) { }

        private void BtnCharitiesList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMarathonInfo_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new MarathonInfo());

        private void BtnBMRCalc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBMICalc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
