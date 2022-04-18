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
    /// Логика взаимодействия для MarathonLengthPage.xaml
    /// </summary>
    public partial class MarathonLengthPage : Page
    {
            //F1 Car  f1-car.jpg	345km/h
            //Slug    slug.jpg	0.01km/h
            //Horse   horse.png	15km/h
            //Sloth   sloth.jpg	0.12km/h
            //Capybara    capybara.jpg	35km/h
            //Jaguar  jaguar.jpg	80km/h
            //Worm    worm.jpg	0.03km/h

            //Bus bus.jpg	10m
            //Pair of Havaianas pair-of-havaianas.jpg	0.245m
            //Airbus A380 airbus-a380.jpg	73m
            //Football Field  football-field.jpg	105m
            //Ronaldinho ronaldinho.jpg  1.81m

        public MarathonLengthPage()
        {
            InitializeComponent();
            BtnF1_Click(TBlockTitle, new RoutedEventArgs());
        }
        private void BtnF1_Click(object sender, RoutedEventArgs e)
        {
            TBlockTitle.Text = "F1 Car";
            byte[] imageInfo = File.ReadAllBytes(String.Format($@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\Photos\MarathonHowLong\f1-car.jpg"));
            BitmapImage image;
            using (MemoryStream imageStream = new MemoryStream(imageInfo))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = imageStream;
                image.EndInit();
            }
            ImgItem.Source = image;
            TBlockText.Text = "An F1 car travels at 345 km/h speed so would complete the marathon in 7 minutes 20 seconds";
        }

        private void BtnWorm_Click(object sender, RoutedEventArgs e)
        {
            TBlockTitle.Text = "F1 Car";
            byte[] imageInfo = File.ReadAllBytes(String.Format($@"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\Photos\MarathonHowLong\worm.jpg"));
            BitmapImage image;
            using (MemoryStream imageStream = new MemoryStream(imageInfo))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = imageStream;
                image.EndInit();
            }
            ImgItem.Source = image;
            TBlockText.Text = "A worm travels at 0.01 km/h speed so would complete the marathon in 48 days, 20 hours and 5 minutes";
        }
    }
}
