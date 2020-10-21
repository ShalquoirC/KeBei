using System;
using System.Dynamic;
using SQLite;

namespace KeBei.Models
{
    public class Idea
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Unique] [NotNull] public string Name { get; set; }

    }
}
