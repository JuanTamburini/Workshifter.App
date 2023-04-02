using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshifter.Model
{
    public class Workshift
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public bool IsHoliday { get; private set; }

        public double TotalHours => (EndTime - StartTime).TotalHours;
        public decimal NormalHourlyRate { get; set; }
        public decimal NightHourlyRate { get; set; }
        public decimal TotalEarning { get; set; }

        public string Notes { get; private set; }

        public Workshift(DateTime startTime, DateTime endTime, decimal normalHourlyRate, decimal nightHourlyRate, string notes, bool isHoliday = false)
        {
            StartTime = startTime;
            EndTime = endTime;
            NormalHourlyRate = normalHourlyRate;
            NightHourlyRate = nightHourlyRate;
            Notes = notes;
            IsHoliday = isHoliday;

            var nightHours = CountNightHours(startTime, endTime);
            var normalHours = TotalHours - nightHours;
            TotalEarning = ((decimal)nightHours * NightHourlyRate) + ((decimal)normalHours * NormalHourlyRate);

            if (isHoliday)
            {
                TotalEarning *= 2; // Double the total earnings for holidays
            }
        }

        private static double CountNightHours(DateTime start, DateTime end)
        {
            DateTime eightPm = start.Date.AddHours(20);
            DateTime sixAm = start.Date.AddDays(1).AddHours(6);

            if (end < eightPm || start > sixAm)
            {
                return 0;
            }

            if (start < eightPm)
            {
                start = eightPm;
            }

            if (end > sixAm)
            {
                end = sixAm;
            }

            TimeSpan duration = end - start;
            return duration.TotalHours;
        }

    }

}
