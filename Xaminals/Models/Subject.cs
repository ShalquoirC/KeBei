using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SQLite;
namespace KeBei.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique] [NotNull] public string Name { get; set; }
        public string Detail { get; set; }
        public int CurLenth { get; set; }
        //public Curriculum Curricula { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}