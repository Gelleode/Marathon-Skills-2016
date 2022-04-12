using Marathon_Skills_2016.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon_Skills_2016.Utils
{
    class RunnerCat
    {
        public Runner Runner { get; set; }
        public Gender Gender { get; set; }
        public int Category
        {
            get
            {
                var age = Convert.ToInt32((DateTime.Now - Runner.DateOfBirth).Value.TotalDays / 365);
                if (age < 18)
                {
                    return 1;
                }
                if (18 <= age && age <= 29)
                {
                    return 2;
                }
                if (30 <= age && age <= 39)
                {
                    return 3;
                }
                if (40 <= age && age <= 55)
                {
                    return 4;
                }
                if (56 <= age && age <= 70)
                {
                    return 5;
                }
                return 6;
            }
        }
    }
}
