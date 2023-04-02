using SQLite;

namespace workshifter.Model
{
    public class WorkshiftItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsHoliday { get; set; }

        public decimal NormalHourlyRate { get; set; }
        public decimal NightHourlyRate { get; set; }
        public decimal TotalEarning { get; set; }
    }
}
