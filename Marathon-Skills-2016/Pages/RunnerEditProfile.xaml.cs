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
    /// Логика взаимодействия для RunnerEditProfile.xaml
    /// </summary>
    public partial class RunnerEditProfile : Page
    {
        private static User _user;
        private string _photoPath;

        public RunnerEditProfile(User user)
        {
            _user = user;
            InitializeComponent();
            CBoxGender.ItemsSource = DatabaseContext.db.Gender.ToList();
            CBoxCountry.ItemsSource = DatabaseContext.db.Country.ToList();
            DataContext = _user.Runner.First();
            BitmapImage bitmapImage = new BitmapImage() { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(String.Format($@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\Photos\Runner\{_user.Runner.First().PhotoPath}"), UriKind.Absolute);
            bitmapImage.EndInit();
            ImageRunner.Source = bitmapImage;
            
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
        private bool CheckPassword(string password)
        {
            if (password == null)
                return false;
            if (password.Length < 6)
                return false;
            if (!password.Any(c => char.IsDigit(c)))
                return false;
            if (!password.Any(c => char.IsUpper(c)))
                return false;
            if (!password.Contains('!'))
                return false;
            if (!password.Contains('@'))
                return false;
            if (!password.Contains('#'))
                return false;
            if (!password.Contains('$'))
                return false;
            if (!password.Contains('%'))
                return false;
            if (!password.Contains('^'))
                return false;
            return true;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxName.Text == "" ||
                TBoxSurName.Text == "" ||
                TBoxPhotoPath.Text == "" ||
                DatePickBirth.Text == ""
                )
            {
                MessageBox.Show("Укажите все данные!");
                return;
            }
            if (TBoxPass.Text != "")
            {
                if (!CheckPassword(TBoxPass.Text))
                {
                    MessageBox.Show("Пароль должен содержать хотя бы одну прописную букву, хотя бы одну цифру и хотя бы один из этих символов: \n ! @ # $ % ^");
                    return;
                }
                if (TBoxPass.Text != TBoxPassRepeat.Text)
                {
                    MessageBox.Show("Повторите пароль");
                    return;
                }
            }
            if (DatePickBirth.DisplayDate > DateTime.Now.AddYears(-10))
            {
                MessageBox.Show("Укажите правильный возраст");
                return;
            }

            if (TBoxPhotoPath.Text != _user.Runner.First().PhotoPath)
            {
                File.Copy(_photoPath, String.Format($@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\Photos\Runner\{TBlockEmail.Text}.{TBoxPhotoPath.Text.Split('.')[1]}"), true);
                _user.Runner.First().PhotoPath = $"{TBlockEmail.Text}.{TBoxPhotoPath.Text.Split('.')[1] }";
            }
            DatabaseContext.db.SaveChanges();
            Manager.MainFrame.Navigate(new RunnerUIPage(_user));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Manager.MainFrame.Navigate(new RunnerUIPage(_user));
    }
}
