using SQLite;

namespace workshifter.Model
{
    public class Workshift
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
