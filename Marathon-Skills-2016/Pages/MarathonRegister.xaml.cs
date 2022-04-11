using Marathon_Skills_2016.DBModel;
using Marathon_Skills_2016.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MarathonRegister.xaml
    /// </summary>
    public partial class MarathonRegister : Page
    {
        private User _user;
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        public MarathonRegister(User user)
        {
            _user = user;
            InitializeComponent();
            RButtonA.IsChecked = true;
            CBoxCharity.ItemsSource = DatabaseContext.db.Charity.ToList();
            CBoxCharity.SelectedIndex = 0;
        }
        private void UpdatePrice()
        {
            try
            {
                int price = 0;
                if (RButtonA.IsChecked == true)
                    price += 0;
                if (RButtonB.IsChecked == true)
                    price += 20;
                if (RButtonC.IsChecked == true)
                    price += 45;
                if (CheckFM.IsChecked == true)
                    price += 145;
                if (CheckHM.IsChecked == true)
                    price += 75;
                if (CheckFR.IsChecked == true)
                    price += 20;
                if (TBoxCharityMoney.Text != "")
                    price += Convert.ToInt32(TBoxCharityMoney.Text);

                TBlockCost.Text = price.ToString();
            }
            catch
            {
                TBlockCost.Text = 0.ToString();
            }
        }
        private void Checked(object sender, RoutedEventArgs e) => UpdatePrice();
        private void TBoxCharityMoney_TextChanged(object sender, TextChangedEventArgs e) => UpdatePrice(); 
        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new RunnerUIPage(_user));
        private void CBoxCharity_SelectionChanged(object sender, SelectionChangedEventArgs e) => TTipCharity.Content = (CBoxCharity.SelectedItem as Charity).CharityDescription;
        private static bool IsTextAllowed(string text) => !_regex.IsMatch(text);
        private void TBoxCharityMoney_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = !IsTextAllowed(e.Text);
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!(CheckFR.IsChecked == true || CheckHM.IsChecked == true || CheckFM.IsChecked == true))
            {
                MessageBox.Show("Выберите тип марафона");
                return;
            }

            string raceKitOptionId = "A";
            if (RButtonB.IsChecked == true)
                raceKitOptionId = "B";
            if (RButtonC.IsChecked == true)
                raceKitOptionId = "C";
            int price = 0;
            int sponsor = 0;
            if (RButtonB.IsChecked == true)
                price = 20;
            if (RButtonC.IsChecked == true)
                price = 45;
            if (TBoxCharityMoney.Text != "")
                sponsor = Convert.ToInt32(TBoxCharityMoney.Text);

            TBlockCost.Text = price.ToString();
            Registration registration = new Registration()
            {
                RegistrationId = 0,
                RunnerId = _user.Runner.First().RunnerId,
                RegistrationDateTime = DateTime.Now,
                RaceKitOptionId = raceKitOptionId,
                RegistrationStatusId = 1,
                Cost = price,
                CharityId = (CBoxCharity.SelectedItem as Charity).CharityId,
                SponsorshipTarget = sponsor
            };
            DatabaseContext.db.Registration.Add(registration);
            DatabaseContext.db.SaveChanges();

            Manager.MainFrame.Navigate(new MarathonRegConfirm(_user));
        }
       
    }
}
