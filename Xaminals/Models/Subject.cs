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
        [Unique][NotNull] public string Name { get; set; }
        public string Detail { get; set; }
        [NotNull] public int CurLenth { get; set; }
        public List<Curriculum>  Curriculum { get; set; }
        [NotNull] public DateTime StartDate { get; set; }
        [NotNull] public DateTime EndDate { get; set; }

    }
}