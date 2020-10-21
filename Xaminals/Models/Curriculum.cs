using System;
using System.Collections.Generic;
using SQLite;

namespace KeBei.Models
{
    public class Curriculum
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique] [NotNull] public string Name { get; set; }
        public string Detail { get; set; }

    }
}
