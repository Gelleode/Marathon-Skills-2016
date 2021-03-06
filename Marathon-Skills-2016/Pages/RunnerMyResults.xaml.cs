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
    /// Логика взаимодействия для RunnerMyResults.xaml
    /// </summary>
    public partial class RunnerMyResults : Page
    {
        private static User _user;
        public RunnerMyResults(User user)
        {
            // 17-
            // 18-29
            // 30-29
            // 40-55
            // 56-70
            // 71+
            _user = user;
            RunnerCat curRunner = new RunnerCat() { Runner = _user.Runner.First(), Gender = _user.Runner.First().Gender1 };

            List<Registration> allRegistrations = DatabaseContext.db.Registration.ToList();
            List<RegistrationEvent> allRegistrationEvents = DatabaseContext.db.RegistrationEvent.ToList();
            List<RunnerCat> listRunners = new List<RunnerCat>(DatabaseContext.db.Runner.Select(s => new RunnerCat { Runner = s, Gender = s.Gender1 }));
            
            List<Registration> registrations = new List<Registration>(DatabaseContext.db.Registration.Where(r => r.RunnerId.Equals(curRunner.Runner.RunnerId)));
            List<RegistrationEvent> registrationEvents = allRegistrationEvents.Where(re => registrations.All(r2 => r2.RegistrationId == re.RegistrationId)).ToList();
            
            List<RunnerMarathonResult> runnerMarathonResults = new List<RunnerMarathonResult>(registrationEvents.Select(s => new RunnerMarathonResult
            {
                Country = s.Event.Marathon.Country.CountryName,
                EventType = s.Event.EventType.EventTypeName,
                Year = s.Event.Marathon.YearHeld.Value,
                RaceTime = s.RaceTime.Value,
                TotalPlace = allRegistrationEvents.Where(re => re.EventId.Equals(s.EventId) && re.RaceTime > 0).OrderBy(re => re.RaceTime).ToList().FindIndex(re => re.RaceTime.Equals(s.RaceTime)) + 1,
                CatPlace = allRegistrationEvents.Join(allRegistrations.Join(listRunners.Where(c => c.Gender.Equals(curRunner.Gender) && c.Category.Equals(curRunner.Category)), r => r.RunnerId, lr => lr.Runner.RunnerId, (r, lr) => r), re => re.RegistrationId, r => r.RegistrationId, (re, r) => re).Where(re => re.EventId.Equals(s.EventId) && re.RaceTime > 0).OrderBy(o => o.RaceTime).ToList().FindIndex(f => f.RaceTime.Equals(registrationEvents.First().RaceTime)) + 1,
            }));

            InitializeComponent();
            TBlockGender.Text = curRunner.Gender.Gender1;
            switch (curRunner.Category)
            {
                case 1: TBlockAgeCat.Text = "младше 18"; break;
                case 2: TBlockAgeCat.Text = "18-29"; break;
                case 3: TBlockAgeCat.Text = "30-39"; break;
                case 4: TBlockAgeCat.Text = "40-55"; break;
                case 5: TBlockAgeCat.Text = "56-70"; break;
                case 6: TBlockAgeCat.Text = "старше 70"; break;
            }

            LViewMarathon.ItemsSource = runnerMarathonResults;

        }
    }
}