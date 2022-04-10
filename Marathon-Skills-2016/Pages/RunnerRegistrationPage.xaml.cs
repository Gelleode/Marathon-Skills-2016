using Marathon_Skills_2016.DBModel;
using Marathon_Skills_2016.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для RunnerRegistrationPage.xaml
    /// </summary>
    public partial class RunnerRegistrationPage : Page
    {
        private MainWindow _window;
        private string _photoPath;
        public RunnerRegistrationPage()
        {
            _window = Application.Current.Windows
                   .Cast<Window>()
                   .FirstOrDefault(w => w is MainWindow) as MainWindow;
            InitializeComponent();
            CBoxGender.ItemsSource = DatabaseContext.db.Gender.ToList();
            CBoxCountry.ItemsSource = DatabaseContext.db.Country.ToList();
            CBoxGender.SelectedIndex = 1;
            CBoxCountry.SelectedIndex = 0;
        }

        private void BtnChosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"c:\";
            if (openFileDialog.ShowDialog() == true)
            {
                TBoxPhotoPath.Text = openFileDialog.SafeFileName;
                ImageRunner.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                _photoPath = openFileDialog.FileName;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            _window.BtnLogin.Visibility = Visibility.Visible;
            Manager.MainFrame.GoBack();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User()
            {
                Email = TBoxEmail.Text,
                Password = TBoxPassword.Text,
                FirstName = TBoxName.Text,
                LastName = TBoxSurName.Text,
                RoleId = "R"
            };
            Runner newRunner = new Runner()
            {
                RunnerId = 0,
                Email = newUser.Email,
                Gender = CBoxGender.Text,
                DateOfBirth = DatePickBirth.DisplayDate,
                CountryCode = (CBoxCountry.SelectedItem as Country).CountryCode,
                PhotoPath = $"{TBoxEmail.Text}.{TBoxPhotoPath.Text.Split('.')[1]}"
            };

            File.Copy(_photoPath, String.Format($@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\Photos\Runner\{TBoxEmail.Text}.{TBoxPhotoPath.Text.Split('.')[1]}", true));

            DatabaseContext.db.User.Add(newUser);
            DatabaseContext.db.Runner.Add(newRunner);
            DatabaseContext.db.SaveChanges();
        }
    }
}
