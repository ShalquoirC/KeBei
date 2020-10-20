using System;
using SQLite;
namespace KeBei.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

    }
}