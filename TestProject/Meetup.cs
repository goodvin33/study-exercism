using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public enum Schedule
    {
        Teenth,
        First,
        Second,
        Third,
        Fourth,
        Last
    }

    public class Meetup
    {
        private int _monthOfMetuup;
        private int _yearOfMetuup; 
        public Meetup(int month, int year)
        {
            _monthOfMetuup = month;
            _yearOfMetuup = year;
        }

        public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
        {
            List<DateTime> daysMonthOfMetuup = GetDateTimes();

            int indexElement = schedule switch
            {
                Schedule.Teenth => 10,
                Schedule.First => 1,
                Schedule.Second => 2,
                Schedule.Third => 3,
                Schedule.Fourth => 4,
                Schedule.Last => daysMonthOfMetuup.Count - 1,
            };

            return new DateTime();
                //daysMonthOfMetuup.Where(d => d.DayOfWeek == dayOfWeek)
        }

        public List<DateTime> GetDateTimes ()
        {
            List<DateTime> result = new List<DateTime>();
            
            for(int i = 1; i <= DateTime.DaysInMonth(_yearOfMetuup, _monthOfMetuup); i++)
            {
                result.Add(new DateTime(_yearOfMetuup, _monthOfMetuup, i));
            }

            return (result);
        }
    }
    
}
